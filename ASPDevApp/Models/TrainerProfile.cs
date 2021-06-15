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
        [Foreingnkey("User")]
        [Key]
        public string TrainerId {get;set;}
        public ApplicationUser User { get; set; }
        [Required]
        [DisplayName("Trainer First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Trainer Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Trainer Date Of Birth")]
        public int DateOfBirth { get; set; }
        [Required]
        [DisplayName("Trainer Gmail")]
        public string Gmail { get; set; }
        [Required]
        [DisplayName("Trainer Phone Number")]
        public int PhoneNumber { get; set; }
        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}