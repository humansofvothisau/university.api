using DTOLibrary.CrawlDiemChuan;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAOLibrary.DataAccess.DiemChuan
{
    internal class UniversityDAO
    {
        private static UniversityDAO instance = null;
        private static readonly object instanceLock = new object();

        private UniversityDAO()
        {

        }

        internal static UniversityDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UniversityDAO();
                    }
                    return instance;
                }
            }
        }

        internal List<University> GetUniversities()
        {
            List<University> universities = new List<University>();
            try
            {
                HtmlWeb htmlWeb = new HtmlWeb()
                {
                    AutoDetectEncoding = false,
                    OverrideEncoding = Encoding.UTF8
                };

                // Load website
                HtmlDocument document = htmlWeb.Load("https://diemthi.tuyensinh247.com/diem-chuan.html");
                var threadItems = document.DocumentNode.QuerySelectorAll("ul#benchmarking > li").ToList();

                foreach (var item in threadItems)
                {
                    var linkNode = item.QuerySelector("a");
                    var link = "https://diemthi.tuyensinh247.com" + linkNode.Attributes["href"].Value;
                    var uniName = linkNode.Attributes["title"].Value;
                    var uniCode = linkNode.QuerySelector("strong.clblue2").InnerText;

                    universities.Add(new University
                    {
                        UniCode = uniCode,
                        UniName = uniName,
                        Url = link
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return universities;
        }
    }
}
