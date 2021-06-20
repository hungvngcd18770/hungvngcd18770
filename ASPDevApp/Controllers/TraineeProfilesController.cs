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
    [Authorize]
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
    }
};