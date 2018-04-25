using CarServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace CarServices.Controllers
{
    public class ServiceController : Controller
    {

        //Db instance

        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Service
        public ActionResult OurServices()
        {

            var services = db.Services.ToList();

            return View(services);
        }



        // service Detail
        public ActionResult Details(int? id)
        {

            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

           var servicDetail= db.Services.Where(s => s.ServiceID == id).SingleOrDefault();


            return View(servicDetail);
        }



        //get
        public ActionResult CheckOut(int id)
        {

            ViewBag.serviceId = id;

            return View();
        }

        [HttpPost]
        public ActionResult CheckOut([Form] ServiceOrder model, int id)
            {


            if (!ModelState.IsValid)
            {

                ViewBag.serviceId = id;


                return View(model);

               
            }

            TempData["Message"] = "We are approaching you";

            db.Orders.Add(model);
            db.SaveChanges();

            return RedirectToAction("Thanks");

        }


        public ActionResult Thanks()
        {

            return View();
        }


      [HttpPost]
        public ActionResult Thanks(Feedback model)
        {


            db.Feedbacks.Add(model);
                db.SaveChangesAsync();

            return RedirectToAction("OurServices");
        }





    }
}