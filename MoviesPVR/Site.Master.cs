using MoviesPVR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviesPVR
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check User is Already Login or Not
            if(Session["firstname"]!=null)
            {
                PlaceForAnonymous.Visible = false;
                PlaceForUser.Visible = true;
                HeadLoginName.Text = Session["firstname"].ToString();
            }
            else
            {
                PlaceForAnonymous.Visible = true;
                PlaceForUser.Visible = false;
            }
            // Check User is in Adminstrator Authority or not
            if (Session["rolename"]!=null && Session["rolename"].ToString().Equals("administrator"))
            {
                PlaceForAdmin.Visible = true;
            }
            else
            {
                PlaceForAdmin.Visible = false;
            }
        }

        // Generate Genere List
        public IQueryable<Genre> GetGenres()
        {
            var _db = new MovieDbContext();
            IQueryable<Genre> query = _db.Genres;
            return query;
        }

        // Logout Action
        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Session.RemoveAll();
        }
    }
}