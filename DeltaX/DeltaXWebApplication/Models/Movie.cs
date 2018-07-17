using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace DeltaXWebApplication.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Display(Name ="Name")]
        [Required(ErrorMessage ="Name is the required field")]
        public string MovieName { get; set; }

        [Display(Name = "Poster image Link")]
        public string MoviePoster { get; set; }

        [Display(Name = "Producer Name")]
        [Required(ErrorMessage = "Producer is a required field")]
        public Nullable<int> ProducerId { get; set; }

        [Display(Name = "Plot")]
        public string MoviePlot { get; set; }

        [Display(Name = "Year of Release")]
        public int MovieYearOfRelease { get; set; }

        [Display(Name = "Producer Name")]
        [Required(ErrorMessage ="Producer is a required field")]
        public string ProducerName { get; set; }

        [Required(ErrorMessage = "Atleast one Actor is required")]
        public string ActorList { get; set; }
        public virtual List<string> Actors { get; set; }
    }
}