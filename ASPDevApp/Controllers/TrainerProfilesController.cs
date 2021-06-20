using ASPDevApp.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ASPDevApp.Controllers
{
    [Authorize]
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
    }
}