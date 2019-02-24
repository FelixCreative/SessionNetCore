using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SessionNetCore.Models;
using Newtonsoft.Json;

namespace SessionNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            var account = new User();

            //HttpContext.Session.SetString("User", JsonConvert.SerializeObject(account));
            HttpContext.Session.Set("User", account);

            var value = HttpContext.Session.Get<User>("User");
            return RedirectToAction("Index");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Index");
        }

    }

    public class User
    {
        public User()
        {
            UserName = "Felix";
            Email = "felix@inxvn.com";
        }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
