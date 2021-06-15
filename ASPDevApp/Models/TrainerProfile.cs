using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASPDevApp.Models
{
    public class TrainerProfile
    {
        [Foreingnkey("ApplicationUser")]
        [Key]
        public int TrainerId {get;set;}
        [DisplayName("Trainer First Name")]
        public string FirstName { get; set; }
        [DisplayName("Trainer Last Name")]
        public string LastName { get; set; }
        [DisplayName("Trainer Date Of Birth")]
        public int DateOfBirth { get; set; }
        [DisplayName("Trainer Gmail")]
        public string Gmail { get; set; }
        [DisplayName("Trainer Phone Number")]
        public int PhoneNumber { get; set; }
      
        
    }
}