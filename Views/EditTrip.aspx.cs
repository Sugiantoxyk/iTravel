using iTravel.DAL;
using iTravel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iTravel.Views
{
    public partial class EditTrip : System.Web.UI.Page
    {
        string imgName;
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
                            tbUpdTrip.Text = tripObj.tripName;
                            tbUpdStaff.Text = tripObj.staffNo;
                            tbUpdLocation.Text = tripObj.location;
                            tbUpdDescription.Text = tripObj.description;
                            tbUpdCost.Text = Convert.ToString(tripObj.cost);
                            tbUpdStartDate.Text = Convert.ToDateTime(tripObj.startDate).ToString("yyyy-MM-dd");
                            tbUpdEndDate.Text = Convert.ToDateTime(tripObj.EndDate).ToString("yyyy-MM-dd");
                            tbUpdDdl.ClearSelection();
                            string tripType = tripObj.typeOfTrip.ToString();
                            tbUpdTripSummary.Text = tripObj.tripSummary;
                            tbUpdTripAirline.Text = tripObj.tripAirline;
                            tbUpdTripItinerary.Text = tripObj.tripItinerary;
                            tbUpdTripSelection.Text = tripObj.tripSelection;
                            tbUpdDdl.Items.FindByValue(tripType).Selected = true;
                            imgName = tripObj.tripIMG;
                            lbTripImg.Text = tripObj.tripIMG;
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
                string currentDate = DateTime.Today.ToShortDateString();
                CompareValidator1.ValueToCompare = currentDate;

                string comapareDate = tbUpdStartDate.ToString();
                CompareValidator2.ValueToCompare = comapareDate;
            }
            
                

                
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {

                try
                {
                    imgName = Path.GetFileName(FileUploadControl.FileName);
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/Images/tripIMG/") + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
            else
            {
                imgName = lbTripImg.Text;
            }
            createTrip selTrip = new createTrip();
            CreateTripDAO updTrip = new CreateTripDAO();
            int updCnt;
            //int updRenewMode = 0;

            updCnt = updTrip.updateTrip(tbUpdTrip.Text, tbUpdStaff.Text, tbUpdLocation.Text, tbUpdDescription.Text, Convert.ToDouble(tbUpdCost.Text), Convert.ToDateTime(tbUpdStartDate.Text), Convert.ToDateTime(tbUpdEndDate.Text), Convert.ToString(tbUpdDdl.SelectedValue), Request.QueryString["tripId"].ToString(),tbUpdTripSummary.Text,tbUpdTripAirline.Text,tbUpdTripItinerary.Text,tbUpdTripSelection.Text,imgName);

            if(updCnt == 1)
            {
                lbSucess.Text = "Trip Update Sucessful";
            }
            else
            {
                lbSucess.Text = "Trip Update Unsucessful";
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewTrip.aspx");
        }
    }
}