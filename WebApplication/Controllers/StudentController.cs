using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Read()
        {
            DemoEntities2 db = new DemoEntities2();
            var list = db.Student_Details.ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student_Details model)
        {
            DemoEntities2 db = new DemoEntities2();
            //Student_Details data = new Student_Details();
            //data.First_Name = model.First_Name;
            //data.Last_Name = model.Last_Name;
            //data.Phone_number = model.Phone_number;
            //data.Student_Address_Details.Street_Address = model.Student_Address_Details.Street_Address;
            //data.Student_Address_Details.City = model.Student_Address_Details.City;

            db.Student_Details.Add(model);
            db.SaveChanges();
            string message = "Created the record successfully";

            // To display the message on the screen
            // after the record is created successfully
            ViewBag.Message = message;
            return RedirectToAction("Read");
            // write @Viewbag.Message in the created
            // view at the place where you want to
            // display the message
        }
        public ActionResult Edit(int id)
        {
            DemoEntities2 db = new DemoEntities2();
            var data = db.Student_Details.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Student_Details model)
        {
            DemoEntities2 db = new DemoEntities2();
            var data = db.Student_Details.Find(model.id);
            if (data != null)
            {
                data.First_Name = model.First_Name;
                data.Last_Name = model.Last_Name;
                data.Phone_number = model.Phone_number;
                data.Student_Address_Details.Street_Address = model.Student_Address_Details.Street_Address;
                data.Student_Address_Details.City = model.Student_Address_Details.City;
                db.Entry(data).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                string message = "Updated the record successfully";
                ViewBag.Message = message;

                return RedirectToAction("Read");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            DemoEntities2 db = new DemoEntities2();
            var data = db.Student_Address_Details.Find(id);
            var data1 = db.Student_Details.Find(id);
            db.Student_Address_Details.Remove(data);
            db.Student_Details.Remove(data1);
            db.SaveChanges();
            return RedirectToAction("Read");
        }
    }
}