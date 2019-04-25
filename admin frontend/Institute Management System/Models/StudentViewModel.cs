﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Institute_Management_System.Models
{
    public class StudentViewModel
    {
        private string name;
        private string cNIC;
        private string email;
        private string phonenumber;
        private string address;
        private string department;

        public string Name { get => name; set => name = value; }
        public string CNIC { get => cNIC; set => cNIC = value; }
        public string Email { get => email; set => email = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string Address { get => address; set => address = value; }
        public string Department { get => department; set => department = value; }
    }
}