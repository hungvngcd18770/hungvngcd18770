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
        public ActionResult ChangePassword()
        {
            return View();
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