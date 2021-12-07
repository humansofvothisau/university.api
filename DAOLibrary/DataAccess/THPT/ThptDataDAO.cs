using DTOLibrary.THPT;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DAOLibrary.DataAccess.THPT
{
    internal class ThptDataDAO
    {
        private static ThptDataDAO instance = null;
        private static object instanceLock = new object();

        private static string apiUri = "https://diemthi.vnanet.vn";

        private ThptDataDAO()
        {

        }

        internal static ThptDataDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new ThptDataDAO();
                    }
                    return instance;
                }
            }
        }

        private string GenerateParameters(string code, int year)
        {
            string parameter = string.Empty;

            try
            {
                List<KeyValuePair<string, string>> allInputParams = new List<KeyValuePair<string, string>>();

                allInputParams.Add(new KeyValuePair<string, string>("code", code));
                allInputParams.Add(new KeyValuePair<string, string>("nam", year.ToString()));

                // URL request Query param
                parameter = new FormUrlEncodedContent(allInputParams).ReadAsStringAsync().Result;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return parameter;
        }

        internal async Task<ThptData> GetThptData(string code, int year)
        {
            ThptData data = null;

            try
            {
                using (var client = new HttpClient())
                {
                    // Base Address
                    client.BaseAddress = new Uri(apiUri);

                    // Content type : JSON
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    // Initialization
                    HttpResponseMessage response = new HttpResponseMessage();

                    // Generate Params
                    string parameters = GenerateParameters(code, year);

                    // GET
                    response = await client.GetAsync("Home/SearchBySobaodanh?" + parameters).ConfigureAwait(false);

                    // Verification
                    if (response.IsSuccessStatusCode)
                    {
                        // Reading Response
                        string result = response.Content.ReadAsStringAsync().Result;
                        ApiResult _data = JsonConvert.DeserializeObject<ApiResult>(result);

                        if (_data.Result.Any())
                        {
                            data = _data.Result.First();

                            List<KeyValuePair<string, double>> groups = new List<KeyValuePair<string, double>>();

                            Newtonsoft.Json.Linq.JArray array = JsonConvert.DeserializeObject<dynamic>(data.ResultGroup);
                            foreach (var group in array.ToList())
                            {
                                dynamic _group = JsonConvert.DeserializeObject<dynamic>(group.ToString());
                                groups.Add(new KeyValuePair<string, double>(_group.g.ToString(), double.Parse(_group.p.ToString())));
                            }

                            data.ResultGroupConvert = groups;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return data;
        }
    }

    class ApiResult
    {
        public ThptData[] Result { get; set; }
    }
}
