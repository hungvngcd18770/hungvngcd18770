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
        [HttpGet]
        public ActionResult DecentralizationTrainee(int id)
        {
            var traineeNotInCourse = _context.TraineeProfiles.Where(c => c.CourseId == null).ToList();
            var trainerList = new ListTraineeCoursesViewModel
            {
                TraineeProfiles = traineeNotInCourse,
                Course = _context.Courses.SingleOrDefault(c => c.Id == id)
            };
            return View(trainerList);
        }

        [HttpPost]
        public ActionResult DecentralizationTrainee(string courseId, string traineeId)
        {
            int CourseId = Convert.ToInt32(courseId);
            var trainee = _context.TraineeProfiles.SingleOrDefault(t => t.TraineeId == traineeId);
            trainee.CourseId = CourseId;
            _context.SaveChanges();
            return RedirectToAction("Index/", new { id = courseId });
        }
        [HttpGet]
        public ActionResult ChangeTrainee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteTrainee(string courseId, string traineeId)
        {
            int CourseId = Convert.ToInt32(courseId);
            var trainee = _context.TraineeProfiles.SingleOrDefault(t => t.TraineeId == traineeId);
            trainee.CourseId = null;
            _context.SaveChanges();
            return RedirectToAction("Index/" + courseId);
        }
    }
}