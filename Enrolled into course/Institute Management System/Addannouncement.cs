using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Institute_Management_System
{
    public class Addannouncement
    {
        private String title;
        private String detail;

        public string Title { get => title; set => title = value; }
        public string Detail { get => detail; set => detail = value; }
    }
}