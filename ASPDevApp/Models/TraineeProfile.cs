﻿using System;
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
        public string TraineeId { get; set; }
        public ApplicationUser User { get; set; }
        [Required(ErrorMessage = "Name should not be Empty !!!")]
        [StringLength(255)]
        [DisplayName("Trainee Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Education should not be Empty !!!")]
        [StringLength(255)]
        [DisplayName("Trainee Education")]
        public string Education { get; set; }
        [Required(ErrorMessage = "Age should not be Empty !!!")]
        [DisplayName("Trainee Age")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Date of birth should not be Empty !!!")]
        [DisplayName("Date of Birth")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Primary Programing Language should not be Empty !!!")]
        [StringLength(255)]
        [DisplayName("Primary Programing Language")]
        public string ProgramingLanguage { get; set; }
        [Required(ErrorMessage = "TOEIC score should not be Empty !!!")]
        [DisplayName("TOEIC Score")]
        public int CourseId { get; set; }

    }
}