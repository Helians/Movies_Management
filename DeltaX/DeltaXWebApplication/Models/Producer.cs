using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace DeltaXWebApplication.Models
{
    public class Producer
    {
        public int ProducerId { get; set; }

        [Display(Name ="Name")]
        [Required(ErrorMessage = "Name is a required field")]
        public string ProducerName { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is a required field")]
        public string ProducerSex { get; set; }

        [Display(Name = "Bio")]
        public string ProducerBio { get; set; }

        [Display(Name = "Date of Birth")]
        public System.DateTime ProducerDOB { get; set; }
    }
}