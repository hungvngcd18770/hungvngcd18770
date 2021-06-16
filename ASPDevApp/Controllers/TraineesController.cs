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
        private TraineeProfile _traineeProfile = new TraineeProfile()
        {
            TraineeId = 1,
            FristName = "Quang",
            LastName = "Tran",
            PhoneNumber = 1234556,
            DateOfBirth = 22/03/2000,
            Gmail = "trandangquang@gmail.com",
        };
 
        // GET: Trainees
        public ActionResult Index()
        {
            return View(_traineeProfile);
        }
    }
}