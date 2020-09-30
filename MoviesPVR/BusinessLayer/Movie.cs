using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesPVR.Models
{
    /// <summary>
    /// Represent Movie Information 
    /// </summary>
    public class Movie
    {
        // represent Movie ID
        [ScaffoldColumn(false)]
        public int MovieID { get; set; }

        // represent name of movie
        [Required, StringLength(100), Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        // represent movie description
        [Required, StringLength(10000), Display(Name = "Movie Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        // represnt image path of movie poster
        public string ImagePath { get; set; }

        // represent genre id
        public int? GenreID { get; set; }

        // running status of movie
        public bool RunningStatus { get; set; }

        public virtual Genre Genre { get; set; }

        public virtual ICollection<TicketPurchaseHistory> TicketPurchaseHistories { get; set; }
    }
}