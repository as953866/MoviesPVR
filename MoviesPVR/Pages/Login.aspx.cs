using MoviesPVR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviesPVR
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string error_message = "";
            bool error_status = false;
            string userid = TxtUserID.Text.Trim();
            string password = TxtPassword.Text;

            // If User ID is Empty 
            if (userid.Length == 0)
            {
                error_status = true;
                error_message += " * Please Enter Any Value in User ID Box<br>";
            }

            // If Password is Empty 
            if (password.Length == 0)
            {
                error_status = true;
                error_message += " * Please Enter Any Value in Password Box<br>";
            }
            if(!error_status)
            {
                // Check Movie Details based upon user id
                MovieDbContext context = new MovieDbContext();
                MoviesPVR.Models.User user = context.Users.FirstOrDefault(p => p.UserID.Equals(userid));
                if(user != null )
                {
                    if(user.Password.Equals(password))
                    {
                        Session["rolename"] = user.RoleName;
                        Session["firstname"] = user.FirstName;
                        Session["lastname"] = user.LastName;
                        Session["accountid"] = user.AccountID;
                        FormsAuthentication.RedirectFromLoginPage(user.UserID, true);
                    }
                    else
                    {

                        error_status = true;
                        error_message = "Invalid User Name and Password";
                    }
                }
                else
                {
                    error_status = true;
                    error_message = "Invalid User Name and Password";
                }
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