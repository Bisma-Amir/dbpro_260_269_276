//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Institute_Management_System
{
    using System;
    using System.Collections.Generic;
    
    public partial class CourseAnnounment
    {
        public int AnnouncementId { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public int CourseID { get; set; }
    
        public virtual Cours Cours { get; set; }
    }
}