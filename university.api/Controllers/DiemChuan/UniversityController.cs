using DAOLibrary.Repository.DiemChuan;
using DTOLibrary.CrawlDiemChuan;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace university.api.Controllers.DiemChuan
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityController : ControllerBase
    {
        private IUniversityRepository universityRepository;

        public UniversityController()
        {
            universityRepository = new UniversityRepository();
        }

        // GET: api/<UniversityController>
        [HttpGet]
        [ProducesResponseType(typeof(List<University>), 200)]
        [ProducesResponseType(500)]
        public IActionResult Get()
        {
            try
            {
                List<University> universities = universityRepository.GetUniversities();
                return StatusCode(200, universities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
