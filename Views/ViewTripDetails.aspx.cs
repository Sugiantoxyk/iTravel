using iTravel.DAL;
using iTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iTravel.Views
{
    public partial class ViewTripDetials : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!IsPostBack)
                {
                    try
                    {
                        // Only for Staff
                        if (Session["whoWho"].ToString() == "Staff")
                        {
                            createTrip tripObj = new createTrip();
                            CreateTripDAO tripDAO = new CreateTripDAO();
                            tripObj = tripDAO.retrieveInfo(Request.QueryString["tripId"].ToString());
                            lbGetTripName.Text = tripObj.tripName;
                            lbGetStaffNo.Text = tripObj.staffNo;
                            lbGetLocation.Text = tripObj.location;
                            lbGetDescription.Text = tripObj.description;
                            lbGetTotalCost.Text = Convert.ToString(tripObj.cost);
                            lbGetStartDate.Text = Convert.ToDateTime(tripObj.startDate).ToString("yyyy-MM-dd");
                            lbGetEndDate.Text = Convert.ToDateTime(tripObj.EndDate).ToString("yyyy-MM-dd");
                            string tripType = tripObj.typeOfTrip.ToString();
                            lbGetTypeOfTrip.Text.ToString();
                            lbGetTripSummary.Text = tripObj.tripSummary;
                            lbGetTripAirline.Text = tripObj.tripAirline;
                            lbGetTripItinerary.Text = tripObj.tripItinerary;
                            lbGetTripSelection.Text = tripObj.tripSelection;
                            lbGetTypeOfTrip.Text = tripType;
                            lbId.Text = tripObj.tripId.ToString();
                            lbGetImg.Attributes["src"] = "../Images/tripIMG/" + tripObj.tripIMG.ToString();


                        }
                        else
                        {
                            Response.Redirect("home.aspx");
                        }
                    }
                    catch (NullReferenceException)
                    {
                        Response.Redirect("login.aspx");
                    }
                }
            }


        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditTrip.aspx?tripId=" + lbId.Text );
        }

        
    }
}