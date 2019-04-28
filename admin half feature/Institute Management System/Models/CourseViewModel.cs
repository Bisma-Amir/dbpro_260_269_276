using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Institute_Management_System
{
    public class CourseViewModel
    {
        private string title;
        private string instructor;
        private DateTime start_date;
        private string course_duration;
        private int fee;
        private string department;
        public string Title { get => title; set => title = value; }
        public string Instructor { get => instructor; set => instructor = value; }
        public DateTime Start_date { get => start_date; set => start_date = value; }
        public string Course_duration { get => course_duration; set => course_duration = value; }
        public int Fee { get => fee; set => fee = value; }
        public string Department { get => department; set => department = value; }
        
    }
}