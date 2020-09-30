using MoviesPVR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviesPVR
{
    public partial class MovieOperations : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is Valid or not
            if (!(Session["rolename"] != null && Session["rolename"].ToString().Equals("administrator")))
            {
                Response.Redirect("Default.aspx");
            }
        }

        // Collect All Details of Genre
        public IQueryable GetGenres()
        {
            var _db = new MovieDbContext();
            IQueryable query = _db.Genres;
            return query;
        }

        // Collect All information of Movies
        public IQueryable GetMovies()
        {
            var _db = new MovieDbContext();
            IQueryable query = _db.Movies;
            return query;
        }

        protected void BtnUpdateMovie_Click(object sender, EventArgs e)
        {
            string error_message = "";
            bool error_status = false;
            try
            {
                int movieid = int.Parse(DropDownMovie.SelectedValue);
                string movieName = TxtMovieName.Text.Trim();
                string movieDescription = TxtDescription.Text.Trim();
                string running_status = DropDownRunningStatus.SelectedValue;
                int genreid = int.Parse(DropDownGenre.SelectedValue);
                if (movieName.Length == 0)
                {
                    error_message += "Please Enter Some Text in Movie Name Box<br>";
                    error_status = true;
                }
                if (movieDescription.Length == 0)
                {
                    error_message += "Please Enter Some Text in Movie Description Box<br>";
                    error_status = true;
                }
                if (!error_status)
                {
                    MovieDbContext context = new MovieDbContext();
                    Movie movie = context.Movies.FirstOrDefault(p => p.MovieID == movieid);
                    if (movie != null)
                    {
                        movie.MovieName = movieName;
                        movie.Description = movieDescription;
                        movie.GenreID = genreid;
                        movie.RunningStatus = running_status.Equals("true") ? true : false;
                        context.SaveChanges();
                        error_message = "Movie Record is Updated";
                    }
                }

            }
            catch (Exception ex)
            {
                error_status = true;
                error_message = "There is Failure in Movie Insertion due to " + ex.Message;
            }

            string style = "color:green;font-size:20px;";
            if (error_status)
            {
                style = "color:red;font-size:20px;";
            }
            LiteralError.Text = "<p style=\"" + style + "\">" + error_message + "</p>";
        }


        protected void BtnView_Click(object sender, EventArgs e)
        {
            try
            {
                MovieDbContext context = new MovieDbContext();
                int movieID = int.Parse(DropDownMovie.SelectedValue);
                Movie movie = context.Movies.FirstOrDefault(p => p.MovieID == movieID);
                if (movie != null)
                {
                    TxtMovieName.Text = movie.MovieName;
                    TxtDescription.Text = movie.Description;
                    if (movie.RunningStatus)
                    {
                        DropDownRunningStatus.SelectedIndex = 0;
                    }
                    else
                    {
                        DropDownRunningStatus.SelectedIndex = 1;
                    }
                    DropDownGenre.SelectedValue = movie.GenreID.ToString();
                }
                LiteralError.Text = "";
            }
            catch (Exception ex)
            {
                LiteralError.Text = ex.Message;
            }
        }

        protected void BtnDeleteMovie_Click(object sender, EventArgs e)
        {
            string error_message = "";
            bool error_status = false;
            try
            {
                MovieDbContext context = new MovieDbContext();
                int movieID = int.Parse(DropDownMovie.SelectedValue);
                Movie movie = context.Movies.FirstOrDefault(p => p.MovieID == movieID);
                if (movie != null)
                {
                    context.Movies.Remove(movie);
                    context.SaveChanges();
                    error_message = "Movie Detail is Removed From Database";
                }
                else
                {
                    error_status = true;
                    error_message = "There is No Movie Details";
                }
            }
            catch (Exception ex)
            {
                error_status = true;
                error_message = "Movie Details is not deleted due to " + ex.Message;
            }
            string style = "color:green;font-size:20px;";
            if (error_status)
            {
                style = "color:red;font-size:20px;";
            }
            LiteralError.Text = "<p style=\"" + style + "\">" + error_message + "</p>";
        }
    }
}