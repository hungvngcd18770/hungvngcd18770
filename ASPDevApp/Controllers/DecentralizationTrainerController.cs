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
        [HttpGet]
        public ActionResult DecentralizationTrainer(int id)
        {
            var trainerNotInCourse = _context.TrainerProfiles.Where(c => c.CourseId == null).ToList();
            var trainerList = new ListTrainerCoursesViewModel
            {   
                TrainerProfiles = trainerNotInCourse,
                Course = _context.Courses.SingleOrDefault(c => c.Id == id)
            };
            return View(trainerList);
        }
        [HttpPost]
        public ActionResult AssignTrainerForCourse(string courseId, string trainerId)
        {
            int CourseId = Convert.ToInt32(courseId);
            var trainer = _context.TrainerProfiles.SingleOrDefault(t => t.TrainerId == trainerId);
            trainer.CourseId = CourseId;
            _context.SaveChanges();
            return RedirectToAction("Index/", new { id = courseId });
        }

        [HttpGet]
        public ActionResult ChangeTrainer(int courseId, string trainerId)
        {
            var trainerChange = _context.TrainerProfiles.SingleOrDefault(t => t.TrainerId == trainerId);
            var CoursesExclude = _context.Courses.Where(c => c.Id != courseId);
            var changeTrainer = new ChangeTrainersViewModel()
            {
                Courses = CoursesExclude,
                TrainerProfile = trainerChange,
            };
            return View(changeTrainer);
        }

        [HttpPost]
        public ActionResult ChangeTrainer(string courseId, string trainerId)
        {
            int CourseId = Convert.ToInt32(courseId);
            var trainerProfile = _context.TrainerProfiles.SingleOrDefault(t => t.TrainerId == trainerId);
            trainerProfile.CourseId = CourseId;
            _context.SaveChanges();
            return RedirectToAction("Index/", new { Id = CourseId });
        }

        [HttpPost]
        public ActionResult DeleteTrainer(string courseId, string trainerId)
        {
            int CourseId = Convert.ToInt32(courseId);
            var trainer = _context.TrainerProfiles.SingleOrDefault(t => t.TrainerId == trainerId);
            trainer.CourseId = null;
            _context.SaveChanges();
            return RedirectToAction("Index/" + courseId);
        }
    }
}