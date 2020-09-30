using MoviesPVR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviesPVR
{
    public partial class MovieList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Fetch All Movie Details based upon its Genre
        public IQueryable<Movie> GetMovies([QueryString("id")] int? genreId)
        {
            var _db = new MovieDbContext();
            IQueryable<Movie> query = _db.Movies.Where( p => p.RunningStatus == true );
            if (genreId.HasValue && genreId > 0)
            {
                query = query.Where(p => p.GenreID == genreId);
            }
            return query;
        }
    }
}