using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Institute_Management_System
{
    public class AddInstructor
    {
        private String fullname;
        private String cnic;
        private String emailiD;
        private String phonenumber;
        private String homeaddress;
        private String password;

        public string Fullname { get => fullname; set => fullname = value; }
        public string Cnic { get => cnic; set => cnic = value; }
        public string EmailiD { get => emailiD; set => emailiD = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public string Homeaddress { get => homeaddress; set => homeaddress = value; }
        public string Password { get => password; set => password = value; }
    }
}