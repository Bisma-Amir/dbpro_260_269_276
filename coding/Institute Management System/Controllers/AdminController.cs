using Institute_Management_System.Models;
using Institute_Management_System.Report;
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
    public class AdminController : Controller
    {
        public static string dep;
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

     
        [HttpPost]
        public ActionResult Index(SearchViewModel form)
        {
            dep = form.Type.ToString();


            return View();
        }
        public ActionResult Addinstructor()
        {
            return View();
        }

        // GET: Admin
        [HttpPost]
        public ActionResult Addinstructor(InstructorViewModel collection, SearchViewModel search)
        {
            try
            {

                DB41Entities db = new DB41Entities();
                Instructor s = new Instructor();
                s.Name = collection.Fullname;
                s.CNIC= collection.Cnic;
                s.Address= collection.Homeaddress;
                s.Department = search.Type;
                s.Email = collection.EmailiD;
                s.PhoneNumber = collection.Phonenumber;
                s.Password = collection.Password;
                s.Salary = collection.Salary;
                db.Instructors.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            catch (Exception e)
            {
                throw e;


            }

        }

        public ActionResult instructorcrud(SearchViewModel collection)
        {
            DB41Entities db = new DB41Entities();
            List<InstructorViewModel> list = new List<InstructorViewModel>();
            var dblist = db.Instructors.ToList();
            foreach (var i in dblist)
            {

                if (i.Department == collection.Type)
                {
                    InstructorViewModel mp = new InstructorViewModel();
                    mp.Fullname = i.Name;
                    mp.Cnic = i.CNIC;
                    mp.EmailiD = i.Email;
                    mp.Homeaddress = i.Address;
                    mp.Department = i.Department;
                    mp.Phonenumber = i.PhoneNumber;
                    mp.Salary = i.Salary;
                    list.Add(mp);


                    
                }
            }
                    return View(list);
        }
        public void instructorFromDatabase()
        {
            
        }
        public ActionResult AddCourse()
        {
            return View();

        }

        [HttpPost]

        public ActionResult AddCourse(CourseViewModel c, SearchViewModel collection,string ddlCustomers)
        {

            //InstructorContext dbContext = new InstructorContext();
            //var getinstructorlist = dbContext.TbInstructor.ToList();
            //IEnumerable<SelectListItem> items = new SelectList(getinstructorlist, "Name");
            //ViewBag.JobTitle = items;






            DB41Entities db = new DB41Entities();
            //var getinstructorlist = db.Instructors.ToList();
            //SelectList list = new SelectList(getinstructorlist, "Name");
            //ViewBag.instructorlist = list;
            try
            {
                
                
                Cours m = new Cours();
                m.Title = c.Title ;
                m.Starttime =  c.Start_date.Date;
                m.Duration = c.Course_duration;
                m.Fee = c.Fee;
                m.Department = collection.Type;
              
                string a = collection.Type1;
               

                var Id = db.Instructors
               .Where(x => x.Name == a)
               .Select(x => x.InstructorID)
               .FirstOrDefault();
                m.InstructorID = Id;
                   
                
                db.Courses.Add(m);
                db.SaveChanges();

                return View();

                //string q = ("SELECT Id FROM Instructors WHERE Name ='" + collection.Type1 + "'");
                //SqlCommand edit = new SqlCommand(q);
                //object result = edit.ExecuteScalar();
                //result = (result == DBNull.Value) ? null : result;
                //int a = Convert.ToInt32(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public ActionResult coursecrud(SearchViewModel collection)
        {
            DB41Entities db = new DB41Entities();
            List<CourseViewModel> list = new List<CourseViewModel>();
            var dblist = db.Courses.ToList();
            foreach (var i in dblist)
            {

                if (i.Department == collection.Type)
                {
                    CourseViewModel mp = new CourseViewModel();
                    mp.Title = i.Title;
                    mp.Start_date = i.Starttime;
                    mp.Course_duration = i.Duration;
                    mp.Fee = i.Fee;
                    mp.Department = i.Department;


                    list.Add(mp);
                }

            }
            return View(list);
        }
        public ActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]

        public ActionResult AddAnnouncement(AnnouncementViewModel c, SearchViewModel collection, string ddlCustomers)
        {
            try
            {
                DB41Entities db = new DB41Entities();
                CourseAnnounment m = new CourseAnnounment();
                m.Title = c.Title;
                m.Details = c.Detail;
                string a = collection.Type1;
                var Id = db.Courses
               .Where(x => x.Title == a)
               .Select(x => x.CourseID)
               .FirstOrDefault();
                m.CourseID = Id;
                db.CourseAnnounments.Add(m);
                db.SaveChanges();
                return View();


            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public ActionResult announcementcrud()
        {
            return View();
        }
       
        
        public ActionResult instructorreport()
        {
            DB41Entities db = new DB41Entities();
            var c = (from b in db.Instructors select b).ToList();
           
            InstructorList rpt = new InstructorList();
            rpt.Load(Path.Combine(Server.MapPath("~/Report"),"InstructorList.rpt"));
            rpt.SetDataSource(db.Instructors.ToList());
            Response.Buffer = false;
            Response.ClearContent();

            Response.ClearHeaders();
            try
            {
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                s.Seek(0, SeekOrigin.Begin);
                return File(s, "application/pdf","Instructors.pdf");

            }
           catch
            {
                throw;
                    }
            


        }
        public ActionResult studentreport()
        {
            DB41Entities db = new DB41Entities();
            var c = (from b in db.Students select b).ToList();

            InstructorList rpt = new InstructorList();
            rpt.Load(Path.Combine(Server.MapPath("~/Report"), "StudentList.rpt"));
            rpt.SetDataSource(db.Students.ToList());
            Response.Buffer = false;
            Response.ClearContent();

            Response.ClearHeaders();
            try
            {
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                s.Seek(0, SeekOrigin.Begin);
                return File(s, "application/pdf", "Students.pdf");

            }
            catch
            {
                throw;
            }



        }
        public ActionResult coursereport()
        {
            DB41Entities db = new DB41Entities();
            var c = (from b in db.Courses select b).ToList();

            AllCourses rpt = new AllCourses();
            rpt.Load(Path.Combine(Server.MapPath("~/Report"), "AllCourses.rpt"));
            rpt.SetDataSource(db.Courses.ToList());
            Response.Buffer = false;
            Response.ClearContent();

            Response.ClearHeaders();
            try
            {
                Stream s = rpt.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                s.Seek(0, SeekOrigin.Begin);
                return File(s, "application/pdf", "Courses.pdf");

            }
            catch
            {
                throw;
            }



        }
        public ActionResult announcementcrud(SearchViewModel m)
        {
            try
            {
                DB41Entities db = new DB41Entities();
                List<AnnouncementViewModel> list = new List<AnnouncementViewModel>();
                var dblist = db.CourseAnnounments.ToList();
                var b = db.Courses
                         .Where(x => x.Title==m.Type1)
                        .Select(x => x.CourseID)
                           .FirstOrDefault();

                foreach (var i in dblist)
                {

                    if (i.CourseID == b)
                    {
                        AnnouncementViewModel mp = new AnnouncementViewModel();
                        mp.Title = i.Title;
                        mp.Detail = i.Details;
                        var bb=  db.Courses
                         .Where(x => x.CourseID == b)
                        .Select(x => x.Title)
                           .FirstOrDefault();
                        mp.Course = bb;
                        mp.ID = Convert.ToString(i.AnnouncementId);
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


        public ActionResult StudentCrud(SearchViewModel collection)
        {
            DB41Entities db = new DB41Entities();
            List<StudentViewModel> list = new List<StudentViewModel>();
            var dblist = db.Students.ToList();
            foreach (var i in dblist)
            {

                if (i.Department == collection.Type)
                {
                    StudentViewModel mp = new StudentViewModel();
                    mp.Name = i.Name;
                    mp.CNIC = i.CNIC;
                    mp.Email = i.Email;
                    mp.Address = i.Address;
                    mp.Department = i.Department;


                    list.Add(mp);
                }
                
            }
            return View(list);
        }
        public ActionResult MainPage()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        [HttpGet]
        public ActionResult DeleteStudent()
        {
            return View();
        }

        // GET: Admin/Delete/5
        [HttpPost]
        public ActionResult DeleteStudent(string Cnic)
        {
            DB41Entities db = new DB41Entities();
            StudentViewModel s = new StudentViewModel(); ;
            s.CNIC = Cnic;
          
            //var item = db.Students.Where(x => x.CNIC == Cnic).SingleOrDefault();        
            db.Students.Remove(db.Students.Where(x => x.CNIC == Cnic).SingleOrDefault());
            db.SaveChanges();
            string message = "Student Record has been deleted!";
            return RedirectToAction("StudentCrud", "Admin", new { Message = message });
           
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(string C, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                DB41Entities db = new DB41Entities();
                var item = db.Students.Where(x => x.CNIC == C).SingleOrDefault();
                db.Students.Remove(item);
                db.SaveChanges();
                string message = "Student Record has been deleted!";
                return RedirectToAction("StudentCrud", "Admin", new { Message = message });
            }
            catch
            {
                return View();
            }
        }
    }
}
