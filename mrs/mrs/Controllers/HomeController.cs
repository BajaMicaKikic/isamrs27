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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            using(MrsContext mrs=new MrsContext())
            {
                var usr = mrs.Users.Where(u=>u.EmailAddress == user.EmailAddress && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    TempData["Id"] = usr.Id.ToString();
                    TempData["EmailAddress"] = usr.EmailAddress.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Email ili password nisu korektni.");
                }
            }
            return View();
        }
        public ActionResult LoggedIn()
        {
            if (HttpContext.Session.GetString("Id")!=null)
            {
                return View();
            }
            return Login();
        }
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.AccountId = 1;
                using(MrsContext mrs=new MrsContext())
                {
                    mrs.Users.Add(user);
                    mrs.SaveChanges();
                }
                ModelState.Clear();
                // ViewBag.Message = user.FirstName + " " + user.LastName + " successfully registered.";
                TempData["Id"]= user.Id.ToString();
                TempData["EmailAddress"]= user.EmailAddress.ToString();
                return RedirectToAction("LoggedIn");
            }
            return View();
        }

        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
