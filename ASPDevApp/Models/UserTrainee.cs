using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASPDevApp.Models
{
    public class UserTrainee
    {
        [Key]
        public int TraineeId { get; set; }
        [Required]
        public string Id { get; set; }
        [ForeignKey("Id")]
        public ApplicationUser ApplicationUser { get; set; }
        public string TraineeName { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public string CourseName { get; set; }
    }
}