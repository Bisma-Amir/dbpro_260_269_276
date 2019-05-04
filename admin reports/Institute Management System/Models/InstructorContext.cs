using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Institute_Management_System.Models
{
    public class InstructorContext:DbContext
    {
        public void DBContext()
        {
            Database.SetInitializer<DbContext>(new DropCreateDatabaseIfModelChanges<DbContext>());
        }
        public DbSet<InstructorViewModel> TbInstructor { get; set; }

    }
}