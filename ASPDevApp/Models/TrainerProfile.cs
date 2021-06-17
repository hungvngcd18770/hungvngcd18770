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
        public string TrainerId { get; set; }
        [Required(ErrorMessage = "Name should not be Empty !!!")]
        [StringLength(255)]
        [DisplayName("Trainer Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Education should not be Empty !!!")]
        [StringLength(255)]
        [DisplayName("Trainer Education")]
        public string Education { get; set; }
        [Required(ErrorMessage = "Working Place should not be Empty !!!")]
        [StringLength(255)]
        [DisplayName("Working Place")]
        public string WorkingPlace { get; set; }

        [Required(ErrorMessage = "Telephone should not be Empty !!!")]
        [StringLength(255)]
        [DisplayName("Telephone")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Email Address should not be Empty !!!")]
        [StringLength(255)]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        public enum TypeTrainer
        {
            External = 1,
            Internal = 2
        }
        [Required(ErrorMessage = "Type should not be Empty !!!")]

        [DisplayName("Email Address")]
        public TypeTrainer Type { get; set; }
        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public int Id { get; internal set; }
    }
}