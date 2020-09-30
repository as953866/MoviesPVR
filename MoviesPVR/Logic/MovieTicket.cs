using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviesPVR.Logic
{
    /// <summary>
    /// Represent Movie Ticket and their Category
    /// </summary>
    public class MovieTicket

    {
        // Represent Price of Ticket
        public float TicketPrice { get; set; }

        // Represent Ticket Category
        public string TicketName { get; set; }

        // Represent Status of Special Ticket 
        public bool SpecialTicket { get; set; }

        // Generate List of Movie Tickets
        public static List<MovieTicket> GetMovieTickets()
        {
            List<MovieTicket> tickets = new List<MovieTicket>();
            tickets.Add(new MovieTicket { TicketPrice = 15.00F , TicketName = "General Admission" , SpecialTicket = false });
            tickets.Add(new MovieTicket { TicketPrice = 5.00F, TicketName = "Senior Citizen & Children (<13 years old) ", SpecialTicket = false });
            tickets.Add(new MovieTicket { TicketPrice = 5.00F, TicketName = "Tuesday special", SpecialTicket = true });
            return tickets;
        }

        // Prepare STring representation of Movie Ticket
        public override string ToString()
        {
            string result = TicketName + " ( $" + TicketPrice.ToString() + " )";
            return result;
        }
    }
}