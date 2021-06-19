using ASPDevApp.Models;
using ASPDevApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPDevApp.Controllers
{
    public class DecentralizationTrainerController : Controller
    {
        private ApplicationDbContext _context;
        public DecentralizationTrainerController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: DecentralizationTrainer
        public ActionResult Index(int id)
        {
            var trainerInCourse = _context.TrainerProfiles.Where(c => c.CourseId == id).ToList();
            var trainerList = new ListTrainerCoursesViewModel
            {
                TrainerProfiles = trainerInCourse,
                Course = _context.Courses.SingleOrDefault(c => c.Id == id)
            };
            return View(trainerList);
        }

    }
}