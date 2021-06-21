using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPDevApp.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASPDevApp.Controllers
{
    [Authorize(Roles = "staff")]
    public class TraineeProfilesController : Controller
    {
        private ApplicationDbContext _context;

        public TraineeProfilesController()
        {
            _context = new ApplicationDbContext();

        }
        
        public ActionResult Index(string searchString)
        {
            var userId = User.Identity.GetUserId();
            var profile = _context.TraineeProfiles.ToList();
            if (!searchString.IsNullOrWhiteSpace())
            {
                profile = _context.TraineeProfiles
                    
                    .Where(t => t.Name.Contains(searchString))
                    .ToList();
            }
            return View(profile);
        }
        [HttpGet]
         public ActionResult Create()
         {

             return View();
         }

        [HttpPost]
        public ActionResult Create(TraineeProfile traineeProfile)
        {
            if (!ModelState.IsValid)
            {
                return View(traineeProfile);
            }
            var userId = User.Identity.GetUserId();
            var newTraineeProfile = new TraineeProfile();
            newTraineeProfile.Name = traineeProfile.Name;
            newTraineeProfile.Age = traineeProfile.Age;
            newTraineeProfile.Education = traineeProfile.Education;
            newTraineeProfile.Birthday = traineeProfile.Birthday;
            newTraineeProfile.ProgramingLanguage = traineeProfile.ProgramingLanguage;
            newTraineeProfile.Toeic = traineeProfile.Toeic; 
             _context.TraineeProfiles.Add(newTraineeProfile);
             _context.SaveChanges();
             return RedirectToAction("Index");
         }
         public ActionResult Delete(string traineeId)
         {
             var profileInDb = _context.TraineeProfiles.SingleOrDefault(t => t.TraineeId == traineeId);

             if (profileInDb == null) return HttpNotFound();

             _context.TraineeProfiles.Remove(profileInDb);
             _context.SaveChanges();
             return RedirectToAction("Index");
         }

         [HttpGet]
         public ActionResult Update(int id)
         {

            var viewModel = new ChangePasswordViewModel();
            
            return View(viewModel);
        }

         [HttpPost]
         public ActionResult Update(TraineeProfile traineeProfile)
         {
             if (!ModelState.IsValid)
             {
                 return View();
             }
             var profileInDb = _context.TraineeProfiles.SingleOrDefault(t => t.TraineeId == traineeProfile.TraineeId);

             profileInDb.Name = traineeProfile.Name;
             profileInDb.Age = traineeProfile.Age;
             profileInDb.Education = traineeProfile.Education;
             profileInDb.Birthday = traineeProfile.Birthday;
             profileInDb.ProgramingLanguage = traineeProfile.ProgramingLanguage;
             profileInDb.Toeic = traineeProfile.Toeic;


             _context.SaveChanges();
             return RedirectToAction("Index");
         }
    }
};