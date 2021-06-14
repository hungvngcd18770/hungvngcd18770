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
        [Foreingnkey("ApplicationUser")]
        [Key]
        public int TraineeId { get; set; }
        [Required]
        [DisplayName("Trainee First Name")]
        public string FristName { get; set; }
        [Required]
        [DisplayName("Trainee Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Trainee Phone Number")]
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("Trainee Date Of Birth")]

        public string DateOfBirth { get; set; }
        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}