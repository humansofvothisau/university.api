using DTOLibrary.CrawlDiemChuan;
using System.Collections.Generic;

namespace DAOLibrary.Repository.DiemChuan
{
    public interface IBenchmarkRepository
    {
        public List<Benchmark> GetBenchmarks(string uniUrl);
    }
}
