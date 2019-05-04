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
        public ActionResult CourseDetails(int id)
        {
            DB41Entities db = new DB41Entities();
            CourseViewModel m = new CourseViewModel();
            var list = db.Courses.ToList();
            foreach (var i in list)
            {
                if (i.CourseID == id)
                {
                    m.Title = i.Title;
                    m.Start_date= i.Starttime;
                    m.Fee = i.Fee;
                    m.Course_duration = i.Duration;
                    m.Department = i.Department;
                    var Id = db.Instructors
                   .Where(x => x.InstructorID == i.InstructorID)
                   .Select(x => x.Name)
                   .FirstOrDefault();
                    m.Instructor = Id;



                }
            }



            return View(m);
        }
      
        public ActionResult EnrolledStudents(CourseViewModel m)
        {
            try
            {

                DB41Entities db = new DB41Entities();
                StudentViewModel s = new StudentViewModel();
                EnrolledStudent n = new EnrolledStudent();
                var Id = db.Courses
                      .Where(x => x.Title == m.Title)
                      .Select(x => x.CourseID)
                      .FirstOrDefault();
                n.CourseID = Id;
                n.StartDate = m.Start_date;
                n.Duration = m.Course_duration;
                n.Department = m.Department;
                n.Fee = m.Fee;
                var Ide = db.Instructors
                      .Where(x => x.Name == m.Instructor)
                      .Select(x => x.InstructorID)
                      .FirstOrDefault();

                n.InstructorID = Ide;
                string userid = User.Identity.GetUserId();
                int g = Convert.ToInt32(userid);
                var person = db.Students.Where(y => y.StudentID == g).First();
                n.StudentName = person.Name;
                n.CNIC = person.CNIC;
                n.Address = s.Address;
                n.Email = s.Email;
                n.StudentID = person.StudentID;
                db.EnrolledStudents.Add(n);
                db.SaveChanges();



                return View("Index");
            }
            catch(Exception e)
            {
                throw e;

            }
        }
            public ActionResult ViewAllCourses(SearchViewModel collection)
        {
            try
            {
                DB41Entities db = new DB41Entities();
                List<CourseViewModel> list = new List<CourseViewModel>();
                var dblist = db.Courses.ToList();
                foreach (var i in dblist)
                {

                    if (i.Department == collection.Type)
                    {
                        CourseViewModel mp = new CourseViewModel();

                        mp.CourseId = i.CourseID;
                        mp.Title = i.Title;
                        mp.Start_date = i.Starttime;
                        mp.Course_duration = i.Duration;
                        mp.Fee = i.Fee;
                        mp.Department = i.Department;
                        var Id = db.Instructors
                   .Where(x => x.InstructorID == i.InstructorID)
                   .Select(x => x.Name)
                   .FirstOrDefault();
                        mp.Instructor = Id;


                        list.Add(mp);
                    }

                }
                return View(list);
            }
            catch(Exception e)
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
                        return RedirectToAction("ViewAllCourses");
                    }
                    else
                    {


                        IdentityMessage m = new IdentityMessage();
                        m.Body = "Please Enter register yourself";

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
        public ActionResult viewAnnouncement()
        {


            return View();
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
