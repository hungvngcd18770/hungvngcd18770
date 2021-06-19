using ASPDevApp.Models;
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
        public ActionResult Index()
        {
            return View();
        }
    }
}