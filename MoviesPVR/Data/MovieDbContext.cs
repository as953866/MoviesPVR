using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MoviesPVR.Models
{
    // DB Context File For Project Data
    public class MovieDbContext:DbContext
    {
        public MovieDbContext():base("MoviesPVRConnection")
        {

        }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<TicketPurchaseHistory> TicketPurchaseHistories { get; set; }
    }
}