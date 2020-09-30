using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesPVR.Models
{
    /// <summary>
    /// Represent a Movie Genre
    /// </summary>
    public class Genre
    {
        // ID of Genre
        [ScaffoldColumn(false)]
        public int GenreID { get; set; }


        // Represent Genre Name
        [Required, StringLength(100), Display(Name = "Name")]
        public string GenreName { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}