using MoviesPVR.Logic;
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
    public partial class ShowTimings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            if(!Page.IsPostBack)
            {
                // Bind The Movie Dated
                DropDownMovieDate.Items.Add("Choose Movie Date");
                DateTime date = DateTime.Now;
                for(int i = 0; i < 4; i++)
                {
                    DropDownMovieDate.Items.Add(date.ToLongDateString());
                    date = DateTime.Now.AddDays(i + 1);
                }

                // Bind the Movie Show Timings
                DropDownMovieTime.Items.Add("Choose Show Time");
                DropDownMovieTicketCategory.Items.Add("Choose Movie Ticket Category");
            }
            if(Session["firstname"] != null )
            {
                TxtFirstName.Text = Session["firstname"].ToString();
            }
            if (Session["lastname"] != null)
            {
                TxtLastName.Text = Session["lastname"].ToString();
            }
        }

        // Collect Information based upon Movie ID
        public IQueryable<Movie> GetMovie([QueryString("movieID")] int? movieID)
        {
            var _db = new MovieDbContext();
            IQueryable<Movie> query = _db.Movies;
            if (movieID.HasValue && movieID > 0)
            {
                query = query.Where(p => p.MovieID == movieID);
                LabelMovieID.Text = movieID.ToString();
            }
            else
            {
                query = null;
                LabelMovieID.Text = "";
            }
            return query;
        }

        // On Change on Movie Date Display Available Show Timing and their Ticket Category
        protected void DropDownMovieDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownMovieTime.Items.Clear();
            DropDownMovieTime.Items.Add("Choose Show Time");
            DropDownMovieTicketCategory.Items.Clear();
            DropDownMovieTicketCategory.Items.Add("Choose Movie Ticket Category");
            if (DropDownMovieDate.SelectedIndex > 0)
            {
                LabelTotalSeats.Text = "100";
                DateTime selected_date = DateTime.Parse(DropDownMovieDate.SelectedValue.ToString());
                List<ShowTime> times = ShowTime.GetShowTimes();
                foreach(ShowTime time in times)
                {
                    if(selected_date.Day == DateTime.Now.Day && selected_date.Year == DateTime.Now.Year 
                        && selected_date.Month == DateTime.Now.Month)
                    {
                        if (DateTime.Now.TimeOfDay.TotalMinutes < time.Time)
                        {
                            DropDownMovieTime.Items.Add(new ListItem(time.TimeName, time.Time.ToString()));
                        }
                    }
                    else 
                    {                        
                        DropDownMovieTime.Items.Add(new ListItem(time.TimeName, time.Time.ToString()));
                    }
                    
                }
                var tickets = MovieTicket.GetMovieTickets().Where(p => p.SpecialTicket == false);
                if(selected_date.DayOfWeek == DayOfWeek.Tuesday)
                {
                    tickets = MovieTicket.GetMovieTickets().Where(p => p.SpecialTicket == true);
                }
                foreach(var ticket in tickets)
                {
                    DropDownMovieTicketCategory.Items.Add(new ListItem(ticket.TicketName, ticket.TicketPrice.ToString()));
                }
            }
        }

        // On Change on Movie Time Calculate Total Number of Ticke Present 
        protected void DropDownMovieTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownMovieTime.SelectedIndex>0)
            {
                int movietime = int.Parse(DropDownMovieTime.SelectedValue);
                int movieID = int.Parse(LabelMovieID.Text.Trim());
                DateTime selected_date = DateTime.Parse(DropDownMovieDate.SelectedValue.ToString());
                var context = new MovieDbContext();
                IQueryable<TicketPurchaseHistory> purchases = context.TicketPurchaseHistories.Where( p => ( p.MovieID == movieID 
                    && p.MovieShowTime == movietime && p.MovieShowDate == selected_date ));
                int purchase_ticket = 0;
                if(purchases != null )
                {
                    foreach(TicketPurchaseHistory purchase in purchases)
                    {
                        purchase_ticket += purchase.NoOfTicket;
                    }
                }
                int available_ticket = 100 - purchase_ticket;
                LabelTotalSeats.Text = available_ticket.ToString();
            }
        }

        // On Click on Process Button save the details of Purchase Ticket
        protected void BtnProcess_Click(object sender, EventArgs e)
        {
            string error_message = "";
            bool error_status = false;
            string firstName = TxtFirstName.Text.Trim();
            string lastName = TxtLastName.Text.Trim();
            if(firstName.Length == 0 )
            {
                error_status = true;
                error_message += " * Please Enter Some Value in First Name Box<br>";
            }
            if (lastName.Length == 0)
            {
                error_status = true;
                error_message += " * Please Enter Some Value in Last Name Box<br>";
            }
            if(DropDownMovieDate.SelectedIndex == 0 )
            {
                error_status = true;
                error_message += " * Please Choose Any Movie Date<br>";
            }
            if (DropDownMovieTime.SelectedIndex == 0)
            {
                error_status = true;
                error_message += " * Please Choose Any Show Time<br>";
            }
            if (DropDownMovieTicketCategory.SelectedIndex == 0)
            {
                error_status = true;
                error_message += " * Please Choose Any Ticket Category<br>";
            }
            if (DropDownNumberOfTicket.SelectedIndex == 0)
            {
                error_status = true;
                error_message += " * Please Choose Any Movie Date<br>";
            }
            if( ! error_status )
            {
                int noOfTicket = int.Parse(DropDownNumberOfTicket.SelectedValue);
                int availableTicket = int.Parse(LabelTotalSeats.Text.Trim());
                if( availableTicket >= noOfTicket)
                {
                    int movieID = int.Parse(LabelMovieID.Text.Trim());
                    int movieTime = int.Parse(DropDownMovieTime.SelectedValue);
                    float ticketPrice = float.Parse(DropDownMovieTicketCategory.SelectedValue);
                    TicketPurchaseHistory purchase = new TicketPurchaseHistory
                    {
                        MovieID = movieID,
                        MovieShowDate = DateTime.Parse(DropDownMovieDate.SelectedValue),
                        MovieShowTime = movieTime,
                        NoOfTicket = noOfTicket,
                        FirstName= firstName,
                        LastName = lastName,
                        TicketPrice = ticketPrice,
                        AccountID = "",
                        Discount = 0.0F
                    };
                    if(Session["accountid"]!=null)
                    {
                        purchase.AccountID = Session["accountid"].ToString();
                        purchase.Discount = 20.0F;
                    }
                    var context = new MovieDbContext(); 
                    try
                    {
                        context.TicketPurchaseHistories.Add(purchase);
                        context.SaveChanges();
                        error_message = "Your Movie Ticket Are Booked " + purchase.PurchaseID.ToString();
                        Session["purchaseid"] = purchase.PurchaseID;
                        Response.Redirect("Summary.aspx");
                    }
                    catch(Exception ex)
                    {
                        error_status = true;
                        error_message = ex.Message;
                    }
                }
                else
                {
                    error_status = true;
                    error_message += "There is No Enough Ticket Avaiable<br>";
                }
            }
            string style = "color:green;font-size:20px;";
            if(error_status)
            {
                style = "color:red;font-size:20px;";
            }
            LiteralError.Text = "<p style=\"" + style + "\">" + error_message + "</p>";
        }
    }
}