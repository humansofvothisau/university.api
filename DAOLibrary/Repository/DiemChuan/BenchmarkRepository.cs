using DAOLibrary.DataAccess.DiemChuan;
using DTOLibrary.CrawlDiemChuan;
using System.Collections.Generic;

namespace DAOLibrary.Repository.DiemChuan
{
    public class BenchmarkRepository : IBenchmarkRepository
    {
        public List<Benchmark> GetBenchmarks(string uniUrl)
            => BenchmarkDAO.Instance.GetBenchmarks(uniUrl);
    }
}
