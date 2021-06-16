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
        private List<TraineeProfile> _traineeProfiles = new List<TraineeProfile >();
        
        public TraineesController()
        {
            _traineeProfiles.Add(new TraineeProfile()
            {
                TraineeId = 1,
                FristName = "Quang",
                LastName = "Tran",
                PhoneNumber = 12312412,
                Gmail = "trandangquang@gmail.com",
            });

            _traineeProfiles.Add(new TraineeProfile()
            {
                TraineeId = 2,
                FristName = "Hung",
                LastName = "Kim",
                PhoneNumber = 12444555,
                Gmail = "kimvongochung@gmail.com",
                
            });
        }
        // GET: Trainees
        public ActionResult Index()
        {
            return View(_traineeProfiles);
        }
        public ActionResult Create()
        {
            return View();
        }
    }
};