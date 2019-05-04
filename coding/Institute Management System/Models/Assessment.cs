using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Institute_Management_System.Models
{
    public class Assessment
    {
        private int id;
        private string detail;
        private int instructorId;

        private int marks;

        private int courseId;
        private string department;


        public string Detail { get => detail; set => detail = value; }
        public int InstructorId { get => instructorId; set => instructorId = value; }
        public int Marks { get => marks; set => marks = value; }
        public int CourseId { get => courseId; set => courseId = value; }
        public string Department { get => department; set => department = value; }
        public int Id { get => id; set => id = value; }
    }

}