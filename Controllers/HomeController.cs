using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
            @ViewBag.Name = HttpContext.Session.GetString("UserName");
            return View();
        }

        [HttpPost("Name")]
        public IActionResult Name(string name)
        {
            HttpContext.Session.SetString("UserName", name); 
            @ViewBag.Name = HttpContext.Session.GetString("UserName");
            return RedirectToAction("LED");
        }


        [HttpPost("Print")]
        public IActionResult Print(string print, string color)
        {
            @ViewBag.Name = HttpContext.Session.GetString("UserName");
            System.Console.WriteLine("+++++++++++++++++++++++++++");
            System.Console.WriteLine(print);
            System.Console.WriteLine(color);
            @ViewBag.Name = HttpContext.Session.GetString("UserName");
            return RedirectToAction("LED");
        }

        [HttpGet("Restart")]
        public IActionResult Restart()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
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
