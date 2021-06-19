using ASPDevApp.Models;
using ASPDevApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPDevApp.Controllers
{
    public class DecentralizationTraineeController : Controller
    {
        // GET: DecentralizationTrainee
        private ApplicationDbContext _context;

        public DecentralizationTraineeController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index(int id)
        {
            var traineeInCourse = _context.TraineeProfiles.Where(c => c.CourseId == id).ToList();
            var traineeList = new ListTraineeCoursesViewModel
            {
                TraineeProfiles = traineeInCourse,
                Course = _context.Courses.SingleOrDefault(c => c.Id == id)
            };
            return View(traineeList);
        }


    }
}