using DAOLibrary.Repository.THPT;
using DTOLibrary.THPT;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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

        // GET api/<TotNghiepTHPTController>/quotes
        [HttpGet("quotes")]
        [ProducesResponseType(typeof(List<Quotes>), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetQuotes()
        {
            try
            {
                List<Quotes> quotes = thptDataRepository.GetQuotes();
                return StatusCode(200, quotes);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<TotNghiepThptController>/schedule
        [HttpGet("schedule")]
        [ProducesResponseType(typeof(ScheduleJson), 200)]
        [ProducesResponseType(500)]
        public IActionResult GetSchedule()
        {
            try
            {
                ScheduleJson schedule = thptDataRepository.GetSchedule();
                return StatusCode(200, schedule);
            } catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
