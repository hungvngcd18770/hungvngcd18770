using ASPDevApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDevApp.ViewModel
{
    public class ListTraineeCoursesViewModel
    {
        public Course Course { get; set; }
        public IEnumerable<TraineeProfile> TraineeProfiles { get; set; }
    }
}