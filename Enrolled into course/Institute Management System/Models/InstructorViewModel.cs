using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel;
using System.Web;

namespace Institute_Management_System
{
    public class InstructorViewModel
    {
        private string iD;
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
        public string ID { get => iD; set => iD = value; }
        public static List<InstructorViewModel> GetCategoryList()
        {
            DB41Entities db = new DB41Entities();

            List<InstructorViewModel> Roles = new List<InstructorViewModel>();
            var table = db.Instructors.ToList();

            foreach (var item in table)
            {
                InstructorViewModel m = new InstructorViewModel();
                m.fullname = item.Name;
                m.salary = item.Salary;
                m.department = item.Department;
                m.EmailiD = item.Email;
                m.Cnic = item.CNIC;
                m.homeaddress = item.Address;
                m.phonenumber = item.PhoneNumber;
                m.password = item.Password;
                Roles.Add(m);
            }
            return Roles;

        }
    }
}