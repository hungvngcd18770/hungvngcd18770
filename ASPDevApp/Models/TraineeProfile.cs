using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ASPDevApp.Models
{
    public class TraineeProfile
    {
        [Foreingnkey("User")]
        [Key]
        public int TraineeId { get; set; }
        [DisplayName("Trainee First Name")]
        public string FristName { get; set; }
        [DisplayName("Trainee Last Name")]
        public string LastName { get; set; }
        [DisplayName("Trainee Phone Number")]
        public int PhoneNumber { get; set; }
        [DisplayName("Trainee Date Of Birth")]
        public int DateOfBirth { get; set; }
        [DisplayName("Trainee Gmail")]
        public string Gmail { get; set; }
        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}