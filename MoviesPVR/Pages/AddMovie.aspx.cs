using MoviesPVR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviesPVR
{
    public partial class AddMovie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is Login or NOt 
            if (!(Session["rolename"] != null && Session["rolename"].ToString().Equals("administrator")))
            {
                // Jump to Home Page
                Response.Redirect("Default.aspx");
            }
        }

        // Fetch all Genre Details
        public IQueryable GetGenres(
            )
        {
            var _db = new MovieDbContext();
            IQueryable query = _db.Genres;
            return query;
        }


        // This Event Handler perform the new movie insertion action
        protected void BtnNewMovie_Click(object sender, EventArgs e)
        {
            string error_message = "";
            bool error_status = false;
            try
            {
                string movieName = TxtMovieName.Text.Trim();
                string movieDescription = TxtDescription.Text.Trim();
                string running_status = DropDownRunningStatus.SelectedValue;
                int genreid = int.Parse(DropDownGenre.SelectedValue);

                // If Movie Name is Empty
                if (movieName.Length == 0)
                {
                    error_message += "Please Enter Some Text in Movie Name Box<br>";
                    error_status = true;
                }

                // If MOvie Description is EMpty
                if(movieDescription.Length == 0 )
                {
                    error_message += "Please Enter Some Text in Movie Description Box<br>";
                    error_status = true;
                }

                // Check user is Upload a Poste 
                bool fileOK = false;
                string path = Server.MapPath("~/Posters/");
                if (PosterImage.HasFile)
                {
                    string fileExtension = System.IO.Path.GetExtension(PosterImage.FileName).ToLower();
                    string[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
                    for (int i = 0; i < allowedExtensions.Length; i++)
                    {
                        if (fileExtension.Equals(allowedExtensions[i])) // Extension Check
                        {
                            fileOK = true;
                            break;
                        }
                    }
                }
                if(fileOK)
                {
                    // Save Poste at Given Location
                    PosterImage.PostedFile.SaveAs(path + PosterImage.FileName);
                    Movie movie = new Movie
                    {
                        MovieName = movieName,
                        Description = movieDescription,
                        GenreID = genreid,
                        RunningStatus = running_status.Equals("true") ? true : false,
                        ImagePath = PosterImage.FileName
                    };
                    // Save the Movie
                    MovieDbContext context = new MovieDbContext();
                    context.Movies.Add(movie);
                    context.SaveChanges();
                    error_message = "New Movie is Added in System";
                }
                else
                {
                    error_status = true;
                    error_message += "Invalid Format of Image is not allowed as Poster Image<br>";
                }
            }
            catch(Exception ex)
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
    }
}