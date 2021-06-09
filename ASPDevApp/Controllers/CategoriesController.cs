using ASPDevApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPDevApp.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;
        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == id);
            return View(categoryInDb);
        }

    }
}