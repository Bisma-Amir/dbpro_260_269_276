using Institute_Management_System.Models;
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
        [HttpPost]
        public ActionResult addquestions(int id , MCQ_S a)
        {
            try
            {
                DB41Entities db = new DB41Entities();
                QuestionPaper s = new QuestionPaper();
                
                s.QuestionID =id;
                s.Title = a.Title;
                s.Option1 = a.Option1;
                s.Option2 = a.Option2;
                s.Option3 = a.Option3;
                s.Option4 = a.Option4;
  
                db.QuestionPapers.Add(s);
                db.SaveChanges();
                return RedirectToAction("ViewAssessment", "Instructor");

            }
            catch(Exception e)
            {
                throw e;

            }



            
        }
        public ActionResult viewstudentspage()
        {
            return View();
        }
        public ActionResult AddAssessment()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddAssessment(SearchViewModel collection,Assessment question)
        {
           try
            {
                DB41Entities db = new DB41Entities();
                Question s = new Question();
                string d = collection.Type;
                s.Name = question.Detail;
                s.Marks = question.Marks;
          
                //var Id = db.Courses
                //  .Where(x => x.Title== collection.Type)
                //  .Select(x => x.CourseID)
                //  .FirstOrDefault();
                string userid = User.Identity.GetUserId();
                int g = Convert.ToInt32(userid);
                var person = db.Instructors.Where(y => y.InstructorID == g).First();
                var per = db.Courses.Where(y => y.InstructorID == g).First();
                // var person = db.Courses.Where(y => y.Title == collection.Type).SingleOrDefault();
                s.CourseID = per.CourseID;
                s.Department = person.Department;
                s.InstructorID = g;

                //var Idee= db.Courses
                //  .Where(x => x.CourseID == Id)
                //  .Select(x => x.InstructorID)
                //  .FirstOrDefault();
              
                ////string userid = User.Identity.GetUserId();
                ////int g = Convert.ToInt32(userid);
                //s.InstructorID = Idee;
                
                db.Questions.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index", "Instructor");
            }
            catch (Exception e)
            {
                throw e;


            }
  
         
        }
        public ActionResult Result()
        {
            
            return View();
        }
        public ActionResult ViewAssessment()
        {
            DB41Entities db = new DB41Entities();
            List<Assessment> list = new List<Assessment>();
            var dblist = db.Questions.ToList();
            foreach (var i in dblist)
            {

                    Assessment mp = new Assessment();
                    mp.Detail = i.Name;
                    mp.Marks = i.Marks;
                mp.Id = i.QuestionID;
                    mp.Department = i.Department;
                    mp.InstructorId = i.InstructorID;
                     list.Add(mp);



                }
            
            return View(list);

        }
        //public ActionResult Showpaper()
        //{
        //    return View();
        //}
       
        public ActionResult Showpaper(int id)
        {
            DB41Entities db = new DB41Entities();
            List<MCQ_S> list = new List<MCQ_S>();
            var dblist = db.QuestionPapers.ToList();
            foreach (var i in dblist)
            {
                if (i.QuestionID == id)
                {

                    MCQ_S mp = new MCQ_S();
                    mp.Title = i.Title;
                    mp.Option1 = i.Option2;

                    mp.Option2 = i.Option2;
                    mp.Option3 = i.Option3;
                    mp.Option4 = i.Option4;

                    list.Add(mp);
                }



            }

            return View(list);
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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(InstructorViewModel objUser, SearchViewModel se)
        {
            if (ModelState.IsValid)
            {
                using (DB41Entities db = new DB41Entities())
                {
                    var obj = db.Instructors.Where(a => a.Email.Equals(objUser.EmailiD) && a.Password.Equals(objUser.Password) && a.Department.Equals(se.Type)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserID"] = obj.InstructorID.ToString();
                        Session["UserName"] = obj.Name.ToString();
                        return RedirectToAction("Index");
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
    }
}
