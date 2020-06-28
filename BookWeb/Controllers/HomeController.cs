using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookWebApi.Tools;
using Microsoft.Extensions.Configuration;
using BookWeb.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Book.Core.EntityFramWork.Database;
using Book.Core.IRepository;
using System;
using Book.Core.IServices;
using System.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using BookWebApi.AuthHelper.Policys;
using Book.Core.Model;
using Book.Comment;

namespace BookWeb.Controllers
{
  
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController()
        {

        }
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
         
        }
  
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
      
        /// <summary>
        /// 注销登录的用户
        /// </summary>
        [HttpPost]
        public IActionResult Logout()
        {
            Task.Run(async () =>
            {
                //注销登录的用户，相当于ASP.NET中的FormsAuthentication.SignOut
                await HttpContext.SignOutAsync();
            }).Wait();
            return View();
        }
        [HttpGet]

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [HttpGet]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
