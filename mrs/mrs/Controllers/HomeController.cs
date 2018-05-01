using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mrs.ApplicationCore.Entities;
using mrs.ApplicationCore.Interfaces.Repository;
using mrs.Infrastructure.Data;
using mrs.Models;

namespace mrs.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            using(MrsContext mrs=new MrsContext())
            {
                var usr = mrs.Users.Where(u=>u.EmailAddress == user.EmailAddress && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    HttpContext.Session.SetString("Id",usr.Id.ToString());
                    HttpContext.Session.SetString("EmailAddress", usr.EmailAddress.ToString());
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Email ili password nisu korektni.");
                }
            }
            return View();
        }
        public IActionResult LoggedIn()
        {
            if (HttpContext.Session.GetString("Id")!=null)
            {
                return View();
            }
            return Login();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using(MrsContext mrs=new MrsContext())
                {
                    mrs.Users.Add(user);
                    mrs.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = user.FirstName + " " + user.LastName + " successfully registered.";
            }
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
