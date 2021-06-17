﻿using ASPDevApp.Models;
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
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(TrainerProfile trainerProfile)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var newTrainerProfile = new TrainerProfile();


            newTrainerProfile.Name = trainerProfile.Name;
            newTrainerProfile.Education = trainerProfile.Education;
            newTrainerProfile.WorkingPlace = trainerProfile.WorkingPlace;
            newTrainerProfile.Telephone = trainerProfile.Telephone;
            newTrainerProfile.Email = trainerProfile.Email;
            newTrainerProfile.Type = trainerProfile.Type;

            _context.TrainerProfiles.Add(newTrainerProfile);
            _context.SaveChanges();
            return RedirectToAction("Index");
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