using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeoMatrix_App.Models;



namespace NeoMatrix_App.Controllers
{
    public class HomeController : Controller
    {
        public static string name;
        public static string color;
        public static string text;
        
        [HttpGet("/Output")]
        public IActionResult Output()
        {
            return Json(new {Name = name, Color = color, Text = text});
        }

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
        public IActionResult Name(string Name)
        {
            name = $"Welcome, {Name}";
            return RedirectToAction("LED");
        }

        [HttpPost("Print")]
        public IActionResult Print(string print, string C)
        {
            @ViewBag.Name = HttpContext.Session.GetString("UserName");
            color = C;
            text = print;
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
