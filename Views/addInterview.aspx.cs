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
    public partial class addInterview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Only for Staff
                    if (Session["whoWho"].ToString() == "Staff")
                    {
                        string adminNo = Request.QueryString["sAdminNo"].ToString();
                        string staffNo = Request.QueryString["sStaffNo"].ToString();
                        string imgName = Request.QueryString["sLogo"].ToString();
                        string tripId = Request.QueryString["sTripId"].ToString();

                        lbTripId.Text = tripId;
                        imgLogo.Attributes["src"] = "../Images/companyLogos/" + imgName;
                        lbAdminNo.Text = adminNo;

                        interviewDAO staffDAO = new interviewDAO();
                        staff staffObj = new staff();
                        staffObj = staffDAO.getStaffNamebyStaffNo(staffNo);
                        lbStaffName.Text = staffObj.sStaffName;
                        lbStaffHP.Text = staffObj.sStaffHP;
                        
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

        protected void btnSubmit(object sender, EventArgs e)
        {
            string tripId = lbTripId.Text;
            string adminNo = lbAdminNo.Text;
            string staffName = lbStaffName.Text;
            string staffHP = lbStaffHP.Text;
            string meetDate = tbDateTime.Text;
            string meetTime = tbTime.Text;
            string meetLocation = tbLocation.Text;
            string additionalInfo = tbMoreInfo.Text;

            interviewDAO idDAO = new interviewDAO();
            int addInterview = idDAO.addInterview(tripId, adminNo, staffName, staffHP, meetDate, meetTime, meetLocation, additionalInfo);
            Response.Redirect("staffViewInternSurvey.aspx");
        }
    }
}