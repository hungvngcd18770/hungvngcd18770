using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPDevApp.Models
{
    public class TrainerProfile
    {
        public int Id {get;set;}
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DateOfBirth { get; set; }
        public string Gmail { get; set; }
        public int PhoneNumber { get; set; }

    }
}