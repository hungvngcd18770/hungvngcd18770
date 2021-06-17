using ASPDevApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDevApp.ViewModels
{
    public class ChangeTrainersViewModel
    {
        public IEnumerable<Course> Courses { get; set; }
        //  public IEnumerable<Category> Courses { get; set; }
        public TrainerProfile TrainerProfile { get; set; }
    }
}