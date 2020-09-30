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
    public partial class MovieDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Fetch Movie Details According to Movie ID
        public IQueryable<Movie> GetMovie([QueryString("movieID")] int? movieID)
        {
            var _db = new MovieDbContext();
            IQueryable<Movie> query = _db.Movies;
            if (movieID.HasValue && movieID > 0)
            {
                query = query.Where(p => p.MovieID == movieID);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}