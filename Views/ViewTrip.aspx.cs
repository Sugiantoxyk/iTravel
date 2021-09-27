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
    public partial class ViewTrip : System.Web.UI.Page
    {
        
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
            }
            //createTrip tripObj = new createTrip();

            //CreateTripDAO tripsObjs = new CreateTripDAO();
            //List<createTrip> tripObjList = tripsObjs.getUpdatedTrip();

            //foreach (creat obj in intList)
            //{
            //    HtmlGenericControl newLabel = new HtmlGenericControl("Label");
            //    newLabel.InnerText = obj.intJobTitle;
            //    div1.Controls.Add(newLabel);
            //}





            //lbGetTrip.Text = tripObj.tripName;
            //lbGetStaffNo.Text = tripObj.staffNo;
            //lbGetLocation.Text = tripObj.location;
            //lbGetDescription.Text = tripObj.description;
            //lbGetCost.Text = Convert.ToString(tripObj.cost);
            //lbGetStartDate.Text = Convert.ToString(tripObj.startDate);
            //lbGetEndDate.Text = Convert.ToString(tripObj.EndDate);
            //lbGetTypeOfTrip.Text = tripObj.typeOfTrip;
            //tripObjs.getUpdatedTrip(tripObj.tripName, tripObj.staffNo, tripObj.location, tripObj.description, tripObj.cost, tripObj.startDate, tripObj.EndDate, tripObj.typeOfTrip);


        }

        protected void GridViewTD_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridViewTD.SelectedRow;
            Response.Redirect("ViewTripDetails.aspx?tripId=" + GridViewTD.SelectedRow.Cells[0].Text);
            
            //Response.Redirect("EditTrip.aspx?tripId=" + GridViewTD.SelectedRow.Cells[0].Text);
        }

        //protected void btnViewAll_Click(object sender, EventArgs e)
        //{
        //  teacherView teacherObj = new teacherView();
        //teacherViewDAO viewDAO = new teacherViewDAO();
        //teacherObj = viewDAO.getTripByName();
        //if (teacherObj != null)
        //{
        //PanelErrorResult.Visible = false;
        //PanelView.Visible = true;
        //lbGetTripName.Text = teacherObj.getTripName;
        //lbGetStaffNo.Text = teacherObj.getStaffNo;
        //lbGetLocation.Text = teacherObj.getLocation;
        //lbGetDescription.Text = teacherObj.getDescription;
        //LbGetCost.Text =  Convert.ToString(teacherObj.getCost);
        //lbGetStartDate.Text = Convert.ToString(teacherObj.getStartDate);
        //lbGetEndDate.Text = Convert.ToString(teacherObj.getEndDate);
        //lbGetTypeOfTrip.Text = teacherObj.getTypeOfTrip;

        //Session["SScustId"] = tbCustId.Text;
        //Session["SScustName"] = cusObj.customerName; // OR Lbl_custname.Text

        //}
        //else
        //{
        //Lbl_err.Text = "Customer record not found!";
        //PanelErrorResult.Visible = true;
        //  PanelView.Visible = false;
        // lbGetTripName.Text = String.Empty;
        //lbGetStaffNo.Text = String.Empty;
        //lbGetLocation.Text = String.Empty;
        //lbGetDescription.Text = String.Empty;
        //LbGetCost.Text = String.Empty;
        //lbGetStartDate.Text = String.Empty;
        //lbGetEndDate.Text = String.Empty;
        //lbGetTypeOfTrip.Text = String.Empty;

        //}

    }

    
}