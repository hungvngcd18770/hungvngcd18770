using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPDevApp.Models;
using Microsoft.Ajax.Utilities;

namespace ASPDevApp.Controllers
{
    public class TraineeProfilesController : Controller
    {
        private ApplicationDbContext _context;
         
        
        public TraineeProfilesController()
        {
            _context = new ApplicationDbContext();
           
        }
        // GET: Trainees
        public ActionResult Index(string searchString)
        {
            var profile = _context.TraineeProfiles.ToList();
            if (!searchString.IsNullOrWhiteSpace())
            {
                profile = _context.TraineeProfiles
                    .Where(t => t.Name.Contains(searchString))
                    .ToList();
            }
            return View(profile);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpGet]
         public ActionResult ChangePassword(int id)
         {

             return View();
         }

         [HttpPost]
         public ActionResult ChangePassword(TraineeProfile traineeProfile)
         {
             if (!ModelState.IsValid)
             {
                 return View();
             }
            var profileInDb = _context.TraineeProfiles.SingleOrDefault(t => t.Id == traineeProfile.Id);
             profileInDb.Name = traineeProfile.Name;
             profileInDb.Age = traineeProfile.Age;
             profileInDb.Education = traineeProfile.Education;
             profileInDb.Birthday = traineeProfile.Birthday;
             profileInDb.ProgramingLanguage = traineeProfile.ProgramingLanguage;
             profileInDb.Toeic = traineeProfile.Toeic;

             _context.SaveChanges();
             return RedirectToAction("Index");
         }
        public ActionResult Delete(int? traineeId)
        {
            if (traineeId == null) return HttpNotFound();
            var traineeProfile = _context.TraineeProfiles.SingleOrDefault(t => t.TraineeId == traineeId);
            if (traineeId == null) return HttpNotFound();
            _context.TraineeProfiles.Remove(traineeProfile);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
};