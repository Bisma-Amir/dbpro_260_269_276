﻿using Institute_Management_System.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace Institute_Management_System.Controllers
{
    public class InstructorController : Controller
    {
        // GET: Instructor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult addquestions()
        {


            return View();
        }
        public ActionResult viewstudentspage()
        {
            return View();
        }
        public ActionResult AddAssessment()
        {
            //try
            //{

            //    DB41Entities db = new DB41Entities();
            //    Student s = new Student();
            //    s.Name = collection.Name;
            //    s.CNIC = collection.CNIC;
            //    s.Address = collection.Address;
            //    s.Department = search.Type;
            //    s.Email = collection.Email;
            //    s.Password = collection.Password;
            //    db.Students.Add(s);
            //    db.SaveChanges();
            //    return RedirectToAction("Login", "Student");
            //}
            //catch (Exception e)
            //{
            //    throw e;


            //}
            return View();
         
        }
        public ActionResult Result()
        {
            
            return View();
        }
        public ActionResult Showpaper()
        {
           

            return View();
        }


        // GET: Instructor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Instructor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instructor/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Instructor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Instructor/Edit/5
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

        // GET: Instructor/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Instructor/Delete/5
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
