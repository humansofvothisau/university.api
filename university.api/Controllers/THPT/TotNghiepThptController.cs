using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace university.api.Controllers.THPT
{
    public class TotNghiepThptController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
