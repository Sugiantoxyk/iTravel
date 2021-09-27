using iTravel.DAL;
using iTravel.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iTravel.Views
{
    public partial class CreateTrip : System.Web.UI.Page
    {
        string imgName;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                try
                {
                    // Only for Staff
                    if (Session["whoWho"].ToString() != "Staff")
                    {
                        Response.Redirect("home.aspx");
                    }
                }
                catch (NullReferenceException)
                {
                    Response.Redirect("login.aspx");
                }
                if (Request.QueryString["tripId"] != null)
                {
                    
                    createTrip tripObj = new createTrip();
                    CreateTripDAO tripDAO = new CreateTripDAO();
                    tripObj = tripDAO.retrieveInfo(Request.QueryString["tripId"].ToString());
                    tbTrip.Text = tripObj.tripName;
                    tbStaff.Text = tripObj.staffNo;
                    tbLocation.Text = tripObj.location;
                    tbDescription.Text = tripObj.description;
                    tbCost.Text = Convert.ToString(tripObj.cost);
                    tbStartDate.Text = Convert.ToDateTime(tripObj.startDate).ToString("yyyy-MM-dd");
                    tbEndDate.Text = Convert.ToDateTime(tripObj.EndDate).ToString("yyyy-MM-dd");
                    tbDdl.ClearSelection();
                    string tripType = tripObj.typeOfTrip.ToString();
                    tbTripSummary.Text = tripObj.tripSummary;
                    tbTripAirline.Text = tripObj.tripAirline;
                    tbTripItinerary.Text = tripObj.tripItinerary;
                    tbTripSelection.Text = tripObj.tripSelection;
                    tbDdl.Items.FindByValue(tripType).Selected = true;
                    imgName = tripObj.tripIMG;
                    lbTripImg.Text = tripObj.tripIMG;

                }
                string currentDate = DateTime.Today.ToShortDateString();
                CompareValidator1.ValueToCompare = currentDate;

                string comapareDate = tbStartDate.ToString();
                CompareValidator2.ValueToCompare = comapareDate;

            }
        }
        
        

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (FileUploadControl.HasFile)
            {
                
                try
                {
                    imgName = Path.GetFileName(FileUploadControl.FileName);
                    string filename = Path.GetFileName(FileUploadControl.FileName);
                    FileUploadControl.SaveAs(Server.MapPath("~/Images/tripIMG/") + filename);
                    StatusLabel.Text = "Upload status: File uploaded!";
                    //Bitmap newImage = new Bitmap(400, 800);
                    //using (Graphics gr = Graphics.FromImage(newImage))
                    //{
                    //    gr.SmoothingMode = SmoothingMode.HighQuality;
                    //    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    //    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    //    gr.DrawImage(imgName, new Rectangle(0, 0, 400, 800));
                    //}
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
            System.Diagnostics.Debug.WriteLine(tbTrip.Text);
            
            String TripName = tbTrip.Text;
            String StaffNo = tbStaff.Text.ToString();
            String Location = tbLocation.Text.ToString();
            String Description = tbDescription.Text.ToString();
            double Cost = Convert.ToDouble(tbCost.Text.ToString());
            DateTime StartDate = Convert.ToDateTime(tbStartDate.Text.ToString());
            DateTime EndDate = Convert.ToDateTime(tbEndDate.Text.ToString());
            String TypeOfTrip = Convert.ToString(tbDdl.SelectedValue);
            String TripSummary = tbTripSummary.Text.ToString();
            String TripAirline = tbTripAirline.Text.ToString();
            String TripItinerary = tbTripItinerary.Text.ToString();
            String TripSelection = tbTripSelection.Text.ToString();
            //String TripIMG = Path.GetFileName(FileUploadControl.FileName).ToString();

            CreateTripDAO dao = new CreateTripDAO();
            int result = dao.InsertTrip(TripName, StaffNo, Location, Description, Cost, StartDate, EndDate, Convert.ToString(tbDdl.SelectedValue),TripSummary,TripAirline,TripItinerary,TripSelection,imgName);

            Response.Redirect("ViewTrip.aspx");

        }

        
    }
}