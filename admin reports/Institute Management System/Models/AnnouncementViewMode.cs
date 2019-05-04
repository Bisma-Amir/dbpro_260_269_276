using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Institute_Management_System
{
    public class AnnouncementViewModel
    {
        private string iD;
        private string title;
        private string detail;
        private string course;

        public string ID { get => iD; set => iD = value; }
        public string Title { get => title; set => title = value; }
        public string Detail { get => detail; set => detail = value; }
        public string Course { get => course; set => course = value; }


        public static List<AnnouncementViewModel> GetCategoryList()
        {
            DB41Entities db = new DB41Entities();

            List<AnnouncementViewModel> Roles = new List<AnnouncementViewModel>();
            var table = db.CourseAnnounments.ToList();

            foreach (var item in table)
            {
                AnnouncementViewModel m = new AnnouncementViewModel();
                m.title = item.Title;
                m.detail = item.Details;
                var Id = db.Courses
                  .Where(x => x.CourseID == item.CourseID)
                  .Select(x => x.Title)
                  .FirstOrDefault();
                m.course = Id;

                Roles.Add(m);
            }
            return Roles;

        }
    }
}