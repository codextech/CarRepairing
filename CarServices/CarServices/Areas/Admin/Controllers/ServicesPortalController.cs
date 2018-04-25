using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarServices.Models;
using System.IO;
using System.Web.Hosting;

namespace CarServices.Areas.Admin.Controllers
{




    [Authorize(Roles ="Admin")]
    public class ServicesPortalController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/ServicesPortal
        public ActionResult Index()
        {
            return View(db.Services.ToList());
        }

        // GET: Admin/ServicesPortal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: Admin/ServicesPortal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ServicesPortal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase file, Service service)
        {



            string path;


            if (file != null)
            {
                var filename = Path.GetFileName(file.FileName);
                var extension = Path.GetExtension(filename).ToLower();
                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    path = HostingEnvironment.MapPath(Path.Combine("~/Areas/Admin/Images/", filename));
                    file.SaveAs(path);
                    service.ImageUrl = "~/Areas/Admin/Images/" + filename;
                }
                else
                {
                    ModelState.AddModelError("", "Document size must be less then 5MB");
                    return View(service);
                }


                if (ModelState.IsValid)
                {
                    db.Services.Add(service);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }

            return View(service);

        }
        // GET: Admin/ServicesPortal/Edit/5
        public ActionResult Edit(int? id)
        {


            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Admin/ServicesPortal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase file, Service service)
        {

            string path;


            if (file != null)
            {
                var filename = Path.GetFileName(file.FileName);
                var extension = Path.GetExtension(filename).ToLower();
                if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                {
                    path = HostingEnvironment.MapPath(Path.Combine("~/Areas/Admin/Images/", filename));
                    file.SaveAs(path);
                    service.ImageUrl = "~/Areas/Admin/Images/" + filename;
                }
                else
                {
                    ModelState.AddModelError("", "Document size must be less then 5MB");
                    return View(service);
                }



                if (ModelState.IsValid)
                {
                    db.Entry(service).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(service);
        }

        // GET: Admin/ServicesPortal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: Admin/ServicesPortal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }





        // ================= Service Order ===================




        public ActionResult NewOrder()
        {

            var orders = db.Orders.ToList();

            return View(orders);
        }


        // order Detail

        public ActionResult OrderDetails(int id)
        {
            //var services = db.Services.ToList();

            ViewBag.serviceId = id;

            var employeeId = db.Employees.Select(p =>
                new
                {

                    EmployeeId = p.EmployeeId,
                    EmployeeName = p.EmployeeName

                }).ToList();

            //ViewBag.MyId = new SelectList(serviceId, "ServiceID", "ServiceName");

            ViewBag.employeeId = new SelectList(employeeId, "EmployeeId", "EmployeeName");

           
            var orderDetail = db.Orders.Find(id);

            return View(orderDetail);
        }



        [HttpPost]
        public ActionResult OrderDetails(ServiceOrder model)
        {


           var order = db.Orders.Find(model.ServiceOrderID);

            order.EmployeeId = model.EmployeeId;

            db.Entry(order).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("TotalOrders");
        }




        public ActionResult TotalOrders()
        {

            var orders = db.Orders.Include("Employee").ToList();

            return View(orders);
        }


        public ActionResult TotalOrdersDetail(int id)
        {


            var orderDetail = db.Orders.Include("Employee").Where(o=>o.ServiceOrderID == id).SingleOrDefault();

            return View(orderDetail);
        }


        //============ Feedback =================


        public ActionResult Feedback()
        {

            var feedBack = db.Feedbacks.ToList();

            return View(feedBack);
        }




        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
