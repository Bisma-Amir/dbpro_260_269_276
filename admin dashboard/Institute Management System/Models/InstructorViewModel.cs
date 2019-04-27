using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Institute_Management_System
{
    public class InstructorViewModel
    {
        private string fullname;
        private string cnic;
        private string emailiD;
        private string phonenumber;
        private string homeaddress;
        private string password;
        private string department;
        private int salary;

        public string Fullname { get => fullname; set => fullname = value; }
        public string Cnic { get => cnic; set => cnic = value; }
        public string EmailiD { get => emailiD; set => emailiD = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string Homeaddress { get => homeaddress; set => homeaddress = value; }
        public string Password { get => password; set => password = value; }
        public string Department { get => department; set => department = value; }
        public int Salary { get => salary; set => salary = value; }
    }
}