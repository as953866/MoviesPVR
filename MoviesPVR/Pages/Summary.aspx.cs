using MoviesPVR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MoviesPVR
{
    public partial class Summary : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["purchaseid"]!=null)
            {
                int purchaseid = int.Parse(Session["purchaseid"].ToString());
                MovieDbContext context = new MovieDbContext();
                // Fetch the Details of Purchase using Purchase ID
                TicketPurchaseHistory purchase = context.TicketPurchaseHistories.FirstOrDefault(p => p.PurchaseID == purchaseid);
                if(purchase!=null)
                {
                    // Prepare the Result
                    string result = "";
                    result += "<h1> Movie Name : " + purchase.Movie.MovieName + "</h1>";
                    result += "<h1> Show Date : " + purchase.MovieShowDate.ToLongDateString() + "</h1>";
                    string showTime = "";
                    showTime = (purchase.MovieShowTime / 60).ToString();
                    int minute = (purchase.MovieShowTime % 60);
                    if( minute < 10)
                    {
                        showTime += ":0" + minute.ToString(); 
                    }
                    else
                    {
                        showTime += ":" + minute.ToString();
                    }
                    result += "<h1> Show Time : " + showTime + "</h1>";
                    result += "<h1> Number of Ticket : " + purchase.NoOfTicket.ToString() + "</h1>";
                    result += "<h1> Ticket Price : $" + purchase.TicketPrice.ToString() + "</h1>";
                    float total = purchase.NoOfTicket * purchase.TicketPrice;
                    result += "<h1> Total Amount : $" + total.ToString() + "</h1>";
                    if( purchase.Discount > 0 )
                    {
                        total = total - (total / 100 * purchase.Discount);
                        result += "<h1> After getting Member discount, Total Amount Payble : $" + total +"</h1>";
                    }
                    LiteralSummary.Text = result;
                }
                // Remove purchase id from Session
                Session.Remove("purchaseid");
            }
        }
    }
}