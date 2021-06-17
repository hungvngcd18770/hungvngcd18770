using ASPDevApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDevApp.ViewModels
{
    public class ListTrainerCoursesViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<TrainerProfile> TrainerProfiles { get; set; }
    }
}