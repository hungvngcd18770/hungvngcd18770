﻿using ASPDevApp.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPDevApp.Controllers
{
    public class CoursesController : Controller
    {

        private ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(string searchString)
        {
            var courses = _context.Courses.Include(t => t.Category).ToList();

            if (!searchString.IsNullOrWhiteSpace())
            {
                courses = _context.Courses
                    .Where(t => t.Name.Contains(searchString))
                    .Include(t => t.Category)
                    .ToList();
            }
            return View(courses);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Delete(int id)
        {
            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);

            if (courseInDb == null) return HttpNotFound();
            var trainer = _context.TrainerProfiles.Where(t => t.CourseId == id);
            foreach (var item in trainer)
            {
                item.Course = null;
                item.CourseId = null;
            }
            var trainee = _context.TraineeProfiles.Where(t => t.CourseId == id);
            foreach (var item in trainee)
            {
                item.Course = null;
                item.CourseId = null;

            }
            _context.Courses.Remove(courseInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit()
        {
            return View();
        }

    }
}