﻿using ASPDevApp.Models;
using Microsoft.Ajax.Utilities;
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

        public ActionResult Index(string searchString)
        {

            var categories = _context.Categories.ToList();
            if (!searchString.IsNullOrWhiteSpace())
            {
                categories = _context.Categories.Where(t => t.Description.Contains(searchString)).ToList();
            }
            return View(categories);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            var newCategory = new Category()
            {
                Name = category.Name,
                Description = category.Description,
            };

            _context.Categories.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == id);
            return View(categoryInDb);
        }
        public ActionResult Delete(int id)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == id);
            if (categoryInDb == null) return HttpNotFound();
            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();

            var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == id);

            if (categoryInDb == null) return HttpNotFound();

            return View(categoryInDb);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            var categoryInDb = _context.Categories.SingleOrDefault(t => t.Id == category.Id);
            categoryInDb.Name = category.Name;
            categoryInDb.Description = category.Description;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}