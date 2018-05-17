using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mrs.ApplicationCore.Entities;
using mrs.Infrastructure.Data;

namespace mrs.Controllers
{
    public class ReservationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public AcceptedResult Reservate() {

        //}

        [HttpPost]
        public ActionResult Reservate(CultureObject co, Projection po, CultureObjectHall coh, Screening sc)
        {
            if (ModelState.IsValid)
            {
                MrsContext mrs = new MrsContext();
            }
            return View();
        }
    }
}