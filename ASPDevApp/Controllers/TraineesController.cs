using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPDevApp.Models;

namespace ASPDevApp.Controllers
{
    public class TraineesController : Controller
    {
        private ApplicationDbContext _context;
         
        
        public TraineesController()
        {
            _context = new ApplicationDbContext();
           
        }
        // GET: Trainees
        public ActionResult Index()
        {
            var TraineeProfiles = _context.TraineeProfiles.ToList();
            return View(TraineeProfiles);
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