using Institute_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Institute_Management_System.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentViewModel collection, SearchViewModel search)
        {
            try
            {

                DB41Entities db = new DB41Entities();
                Student s = new Student();
                s.Name = collection.Name;
                s.CNIC = collection.CNIC;
                s.Address = collection.Address;
                s.Department = search.Type;
                s.Email = collection.Email;
                s.Password = collection.Password;
                db.Students.Add(s);
                db.SaveChanges();
                return RedirectToAction("Login", "Student");
            }
            catch (Exception e)
            {
                throw e;


            }
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(StudentViewModel objUser, SearchViewModel se)
        {
            if (ModelState.IsValid)
            {
                using (DB41Entities db = new DB41Entities())
                {
                    var obj = db.Students.Where(a => a.Email.Equals(objUser.Email) && a.Password.Equals(objUser.Password) && a.Department.Equals(se.Type)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.StudentID.ToString();
                        Session["UserName"] = obj.Name.ToString();
                        return RedirectToAction("Index");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["UserID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
