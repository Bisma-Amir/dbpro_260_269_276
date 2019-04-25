using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Institute_Management_System
{
    public class AddCourse
    {
        private String course;
        private String instructor;
        private DateTime start_date;
        private String course_duration;
        private int fee;

        public string Course { get => course; set => course = value; }
        public string Instructor { get => instructor; set => instructor = value; }
        public DateTime Start_date { get => start_date; set => start_date = value; }
        public string Course_duration { get => course_duration; set => course_duration = value; }
        public int Fee { get => fee; set => fee = value; }
    }
}