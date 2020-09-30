using MoviesPVR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviesPVR
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            string error_message = "";
            bool error_status = false;
            string userid = TxtUserID.Text.Trim();
            string firstName = TxtFirstName.Text.Trim();
            string lastName = TxtLastName.Text.Trim();
            string password = TxtPassword.Text;
            string confirmPassword = TxtConfirmPassword.Text;

            // If user ID is empty
            if(userid.Length == 0)
            {
                error_status = true;
                error_message += " * Please Enter Any Value in User ID Box<br>";
            }

            // If first Name is empty
            if (firstName.Length == 0)
            {
                error_status = true;
                error_message += " * Please Enter Any Value in First Name Box<br>";
            }

            // If last Name is empty
            if (lastName.Length == 0)
            {
                error_status = true;
                error_message += " * Please Enter Any Value in Last Name Box<br>";
            }

            // If password is empty
            if (password.Length == 0)
            {
                error_status = true;
                error_message += " * Please Enter Any Value in Password Box<br>";
            }
            else if( !password.Equals(confirmPassword)) // password and confirm password does not match
            {
                error_status = true;
                error_message += " * Confirm Password must be match with Password<br>";
            }
            if( ! error_status)
            {
                MoviesPVR.Models.User user = new Models.User
                {
                    UserID = userid,
                    Password = password,
                    RoleName = "user",
                    AccountID = DateTime.Now.TimeOfDay.TotalMilliseconds.ToString(),
                    FirstName = firstName,
                    LastName = lastName
                };
                try
                {
                    MovieDbContext context = new MovieDbContext();
                    // Save the User Details
                    context.Users.Add(user);
                    context.SaveChanges();
                    error_message = "New Account is Created. Now you can avail benefits by login in system";
                }
                catch(Exception ex)
                {
                    error_status = true;
                    error_message = "User Creation Failure Due to " + ex.Message;
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