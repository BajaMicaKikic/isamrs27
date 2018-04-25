using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using mrs.Models;
using System;
using System.Linq;
using System.Web;

namespace mrs.Controllers
{
    public class AccountController : Controller
    {
        //get: account
        public ActionResult Index()
        {
            using (MojDbContext db = new MojDbContext())
            {
                return View(db.UserAccount.ToList());
            }
        }

        //get metod
        public ActionResult Register() {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount account) {

            if (ModelState.IsValid)
            {
                using(MojDbContext db = new MojDbContext())
                {
                    db.UserAccount.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Ime + " " + account.Prezime+" successfully registered";
            }
            return View();
        }

        //login get metod
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            using(MojDbContext db = new MojDbContext())
            {
                var usr = db.UserAccount.Where(u => u.Email == user.Email && u.Password == user.Password).FirstOrDefault();
                if (usr != null)
                {
                    HttpContext.Session.SetString("IdKorisnika", usr.IdKorisnika.ToString());
                    HttpContext.Session.SetString("Email", usr.Email.ToString());
                    //Session ["IdKorisnika"] = usr.IdKorisnika.ToString();
                    //Session["Email"] = usr.Email.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Email ili lozinka nisu korektni.");
                }
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if(HttpContext.Session.GetString("IdKorisnika") != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}