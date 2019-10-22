using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeoMatrix_App.Models;

namespace NeoMatrix_App.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

[       HttpGet("LED")]
        public IActionResult LED()
        {
            return View();
        }

        [HttpPost("Print")]
        public IActionResult Print(string print, string color)
        {
            return RedirectToAction("LED");
        }

        [HttpGet("KK")]
        public IActionResult KK()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
