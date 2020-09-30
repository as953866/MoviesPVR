using MoviesPVR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviesPVR
{
    public partial class AllUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check user is valid or not
            if (!(Session["rolename"] != null && Session["rolename"].ToString().Equals("administrator")))
            {
                Response.Redirect("Default.aspx");
            }
        }

        // Display All Genre Details
        public IQueryable GetUsers()
        {
            var context = new MovieDbContext();
            var query = context.Users;
            return query;
        }
    }
}