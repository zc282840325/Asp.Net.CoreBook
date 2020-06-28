using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BookManagerWeb.Controllers
{
    public class sysUserInfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddorUpdate(int ? uid)
        {
            if (uid==null)
            {
                ViewData["title"] = "新增";
                return View();
            }
            else
            {
                ViewData["title"] = "编辑";
                ViewData["uid"] = uid;
                return View();
            }
        }
        public IActionResult Details(int uid)
        {
            ViewData["uid"] = uid;
            return View();
        }
    }
}