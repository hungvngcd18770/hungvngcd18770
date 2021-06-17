using ASPDevApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDevApp.ViewModels
{
    public class ChangeTraineesViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
        public TraineeProfile TraineeProfile { get; set; }
    }
}