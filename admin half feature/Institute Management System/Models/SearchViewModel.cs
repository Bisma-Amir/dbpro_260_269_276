using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Institute_Management_System.Models
{
    public class SearchViewModel
    {

        private string type;
        private string type1;

        public string Type { get => type; set => type = value; }
        public string Type1 { get => type1; set => type1 = value; }
    }
}