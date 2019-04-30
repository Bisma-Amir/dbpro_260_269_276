using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace Institute_Management_System.Models
{
    public class MCQ_S
    {
        private string title;
        private int questionid;
        private string option1;
        private string option2;
        private string option3;
        private string option4;

        public string Title { get => title; set => title = value; }
        public int Questionid { get => questionid; set => questionid = value; }
        public string Option1 { get => option1; set => option1 = value; }
        public string Option2 { get => option2; set => option2 = value; }
        public string Option3 { get => option3; set => option3 = value; }
        public string Option4 { get => option4; set => option4 = value; }
    }
}