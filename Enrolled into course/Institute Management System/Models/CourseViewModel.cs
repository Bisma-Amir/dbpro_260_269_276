using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Institute_Management_System
{
    public class CourseViewModel
    {
        private int courseId;
        private string title;
        private string instructor;
        private DateTime start_date;
        private string course_duration;
        private int fee;
        private string department;

        public int CourseId { get => courseId; set => courseId = value; }
        public string Title { get => title; set => title = value; }
        public string Instructor { get => instructor; set => instructor = value; }
        public DateTime Start_date { get => start_date; set => start_date = value; }
        public string Course_duration { get => course_duration; set => course_duration = value; }
        public int Fee { get => fee; set => fee = value; }
        public string Department { get => department; set => department = value; }

        public static List<CourseViewModel> GetCategoryList()
        {
            DB41Entities db = new DB41Entities();

            List<CourseViewModel> Roles = new List<CourseViewModel>();
            var table = db.Courses.ToList();

            foreach (var item in table)
            {
                CourseViewModel m = new CourseViewModel();
                m.title= item.Title;
                m.start_date = item.Starttime;
                m.department = item.Department;
                m.course_duration = item.Duration;
                m.fee = item.Fee;
                var Id = db.Instructors
                  .Where(x => x.InstructorID == item.InstructorID)
                  .Select(x => x.Name)
                  .FirstOrDefault();
                m.instructor = Id;
           
                Roles.Add(m);
            }
            return Roles;

        }

    }
}