using ASPDevApp.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ASPDevApp.Controllers
{
    public class TrainerProfilesController : Controller
    {
        private ApplicationDbContext _context;

        public TrainerProfilesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(string searchString)
        {

            var profile = _context.TrainerProfiles.ToList();
            if (!searchString.IsNullOrWhiteSpace())
            {
                profile = _context.TrainerProfiles
                    .Where(t => t.Name.Contains(searchString))
                    .ToList();
            }
            return View(profile);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            var profileInDb = _context.TrainerProfiles.SingleOrDefault(t => t.Id == id);

            if (profileInDb == null) return HttpNotFound();

            _context.TrainerProfiles.Remove(profileInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}