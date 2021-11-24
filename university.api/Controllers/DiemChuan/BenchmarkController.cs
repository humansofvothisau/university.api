using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace university.api.Controllers.DiemChuan
{
    public class BenchmarkController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
