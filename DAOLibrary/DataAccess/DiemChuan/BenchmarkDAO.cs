using DTOLibrary.CrawlDiemChuan;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOLibrary.DataAccess.DiemChuan
{
    internal class BenchmarkDAO
    {
        private static BenchmarkDAO instance = null;
        private static readonly object instanceLock = new object();

        private static int[] Years;

        private BenchmarkDAO()
        {
            Years = new int[]
            {
                DateTime.Now.Year,
                DateTime.Now.Year - 1,
                DateTime.Now.Year - 2,
                DateTime.Now.Year - 3
            };
        }

        internal static BenchmarkDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BenchmarkDAO();
                    }
                    return instance;
                }
            }
        }

        internal List<Benchmark> GetBenchmarks(string uniUrl)
        {
            List<Benchmark> benchmarks = new List<Benchmark>();
            try
            {
                HtmlWeb htmlWeb = new HtmlWeb
                {
                    AutoDetectEncoding = false,
                    OverrideEncoding = Encoding.UTF8
                };
                foreach (var year in Years)
                {
                    List<BenchmarkDetail> benchmarkDetails = new List<BenchmarkDetail>();

                    HtmlDocument document = htmlWeb.Load(uniUrl + "?y=" + year);
                    var benchmarkItems = document.DocumentNode.QuerySelectorAll("div#one > table > tr.bg_white").ToList();
                    string[] benchmarkData;
                    if (benchmarkItems.Any())
                    {
                        foreach (var rowItem in benchmarkItems)
                        {
                            var benchmarkColumn = rowItem.QuerySelectorAll("td").ToList();
                            benchmarkData = new string[6];
                            var count = 0;
                            foreach (var item in benchmarkColumn)
                            {
                                benchmarkData[count++] = item.InnerText;
                            }
                            benchmarkDetails.Add(new BenchmarkDetail()
                            {
                                MajorCode = benchmarkData[1],
                                MajorName = benchmarkData[2],
                                SubjectGroup = benchmarkData[3],
                                Point = benchmarkData[4],
                                Note = benchmarkData[5]
                            });
                        }

                        benchmarks.Add(new Benchmark()
                        {
                            Year = year,
                            Data = benchmarkDetails.ToArray()
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return benchmarks;
        }
    }
}
