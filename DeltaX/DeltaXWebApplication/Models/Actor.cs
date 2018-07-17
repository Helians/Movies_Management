using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DeltaXWebApplication.Models
{
    public class Actor
    {
        
        public int ActorId { get; set; }

        [Required(ErrorMessage = "Name is the required field")]
        [Display(Name ="Name")]
        public string ActorName { get; set; }

        [Required(ErrorMessage = "Gender is the required field")]
        [Display(Name = "Gender")]
        public string ActorSex { get; set; }

        [Display(Name = "Date Of Birth")]
        public System.DateTime ActorDOB { get; set; }

        [Display(Name = "Bio")]
        public string ActorBio { get; set; }
        
    }
}