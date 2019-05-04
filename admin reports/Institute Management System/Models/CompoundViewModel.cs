using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Institute_Management_System.Models
{
    public class CompoundViewModel
    {
        public IEnumerable<StudentViewModel> AllStudentss { get; set; }
        public Assessment Marks { get; set; }
    }
}