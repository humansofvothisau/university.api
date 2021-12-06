using DAOLibrary.Repository.THPT;
using DTOLibrary.THPT;
using Microsoft.AspNetCore.Mvc;
using System;

namespace university.api.Controllers.THPT
{
    [Route("api/[controller]")]
    [ApiController]
    public class TotNghiepThptController : ControllerBase
    {
        private int year = DateTime.Now.Year;
        private IThptDataRepository thptDataRepository;

        public TotNghiepThptController()
        {
            thptDataRepository = new ThptDataRepository();
        }

        //// GET: api/<TotNghiepTHPTController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<TotNghiepTHPTController>/5
        [HttpGet("{code}")]
        [ProducesResponseType(typeof(ThptData), 200)]
        [ProducesResponseType(500)]
        public IActionResult Get(string code)
        {
            try
            {
                if (string.IsNullOrEmpty(code))
                {
                    throw new Exception("Invalid student code!!");
                }

                // Get Data
                ThptData data = thptDataRepository.GetTHPTData(code, year).Result;
                return StatusCode(200, data);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
