using DAOLibrary.Repository.DiemChuan;
using DTOLibrary.CrawlDiemChuan;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace university.api.Controllers.DiemChuan
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenchmarkController : ControllerBase
    {
        private IBenchmarkRepository benchmarkRepository;

        public BenchmarkController()
        {
            benchmarkRepository = new BenchmarkRepository();
        }
        // GET: api/<BenchmarkController>
        [HttpGet]
        [ProducesResponseType(typeof(List<Benchmark>), 200)]
        [ProducesResponseType(500)]
        public IActionResult Get([FromQuery] string uniUrl)
        {
            try
            {
                List<Benchmark> benchmarks = benchmarkRepository.GetBenchmarks(uniUrl);
                return StatusCode(200, benchmarks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}