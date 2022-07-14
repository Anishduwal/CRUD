using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DemoController : Controller
    {
        DemoEntities2 db = new DemoEntities2();
        // GET: Demo
        public ActionResult Index()
        {
            var list = db.practices.ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(practice model)
        {
            if (ModelState.IsValid)
            {
                practice data = new practice();
                data.name = model.name;
                data.address = model.address;
                data.phone_number = model.phone_number;
                // Add data to the particular table
                db.practices.Add(data);

                // save the changes
                db.SaveChanges();
                string message = "Created the record successfully";

                // To display the message on the screen
                // after the record is created successfully
                ViewBag.Message = message;
                return RedirectToAction("Index");
                // write @Viewbag.Message in the created
                // view at the place where you want to
                // display the message
            }

            return View();

        }
        
        public ActionResult Delete(int id)
        {
            // Delete data to the particular table
            var del = db.practices.Find(id);
            db.practices.Remove(del);
            // save the changes
            db.SaveChanges();
            string message = "Deleted the record successfully";
            // To display the message on the screen
            // after the record is created successfully
            ViewBag.Message = message;

            // write @Viewbag.Message in the created
            // view at the place where you want to
            // display the message
            return RedirectToAction("Index");
        }
        public ActionResult Update(int id)
        {
            var data = db.practices.Find(id);

            return View(data);
        }
        [HttpPost]
        public ActionResult Update(practice model)
        {
            var data = db.practices.Find(model.id);
            if (data != null)
            {
                data.name = model.name;
                data.address = model.address;
                data.phone_number = model.phone_number;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();

                string message = "Updated the record successfully";
                ViewBag.Message = message;

                return RedirectToAction("Index");
            }
            else
                return View();
        }
    }
}