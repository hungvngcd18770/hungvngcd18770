using ASPDevApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDevApp.ViewModel
{
    public class TraineeUserCourseViewModel
    {
        public TraineeProfile TraineeProfile { get; set; }
        public ApplicationUser UserInfo { get; set; }
        public UserInfo UserId { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}