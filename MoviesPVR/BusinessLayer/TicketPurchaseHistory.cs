using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MoviesPVR.Models
{
    /// <summary>
    /// Reprsent Ticket Purchase History
    /// </summary>
    public class TicketPurchaseHistory
    {
        // represent Purchase ID 
        [ScaffoldColumn(false)]
        [Key]
        public int PurchaseID { get; set; }

        // First Name of Buyer
        [StringLength(100), Display(Name = "First Name")]
        public string FirstName { get; set; }

        // Last Name of Buyer
        [StringLength(100), Display(Name = "Last Name")]
        public string LastName { get; set; }

        // Represent Account ID
        [StringLength(100), Display(Name = "Account ID")]
        public string AccountID { get; set; }

        // Represent Total Number of Ticket Purchase
        [Required, Display(Name = "Number of Ticket")]
        public int NoOfTicket { get; set; }

        // Represent Movie Show Timing
        [Required,Display(Name ="Movie Show Time")]
        public int MovieShowTime { get; set; }

        // Represent Movie Show Date
        [Required,Display(Name ="Movie Show Date")]
        public DateTime MovieShowDate { get; set; }

        // Represent Ticket Price
        public float TicketPrice { get; set; }

        // Represent movie id
        public int? MovieID { get; set; }

        // Represent discount
        public float Discount { get; set; }

        public virtual Movie Movie { get; set; }
    }
}