using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookWebApi.Tools;
using Microsoft.AspNetCore.Http;
using BookWebApi;
using Microsoft.Extensions.Configuration;
using BookWebApi.Model;
using BookWeb.Models;

namespace BookWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public IConfiguration _configuration { get; }

        public HomeController(ILogger<HomeController> logger,IConfiguration Configuration)
        {
            _logger = logger;
            _configuration = Configuration;
        }
        public static string tokens { get; set; }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username,string userpwd)
        {
            TokenPayload tokenPayload = new TokenPayload(2, username, userpwd);

            var token =  JwtHelper.CreateToken(tokenPayload);
            tokens = token;
            return RedirectToAction("Privacy");
        }

        public IActionResult Privacy()
        {
            ViewBag.token = tokens;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
