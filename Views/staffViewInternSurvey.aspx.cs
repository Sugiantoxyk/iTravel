using iTravel.DAL;
using iTravel.models;
using iTravel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iTravel.Views
{
    public partial class staffViewInternSurvey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string CS = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;
                using (SqlConnection con = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Id, jobTitle from InternshipInfo", con);
                    con.Open();

                    ddlInternships.DataSource = cmd.ExecuteReader();
                    ddlInternships.DataTextField = "jobTitle";
                    ddlInternships.DataValueField = "Id";
                    ddlInternships.DataBind();
                }
            }
        }

        protected void btnViewResults_Click(object sender, EventArgs e)
        {
            internSurveyDAO intDAO = new internSurveyDAO();
            List<internSurveyResults> intList = new List<internSurveyResults>();
            intList = intDAO.getSuresultsById(ddlInternships.SelectedValue.ToString());
            gvInternResults.DataSource = intList;
            gvInternResults.DataBind();

            interviewDAO idDAO = new interviewDAO();
            List<interview> idList = new List<interview>();
            idList = idDAO.getInterviewByTripId(ddlInternships.SelectedValue.ToString());
            gvAccepted.DataSource = idList;
            gvAccepted.DataBind();

            pResults.Visible = true;
        }

        protected void gvInternResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvInternResults.SelectedRow;
            Response.Redirect("InternSurveyDetails.aspx?sAdminNo=" + row.Cells[2].Text);
        }

        protected void gvInternResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "accept")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                string selectedAdminNo = gvInternResults.Rows[index].Cells[2].Text;

                internSurveyDAO objDAO = new internSurveyDAO();
                internSurveyResults srObj = new internSurveyResults();
                srObj = objDAO.getSRbyAdminNo(selectedAdminNo);

                internshipInfo intObj = new internshipInfo();
                internshipDAO intDAO = new internshipDAO();
                intObj = intDAO.getInternshipById(srObj.isIntId);

                string tripId = srObj.isIntId;

                Response.Redirect("addInterview.aspx?sAdminNo=" + selectedAdminNo + "&sLogo=" + intObj.intImageName + "&sStaffNo=" + Session["username"].ToString() + "&sTripId=" + tripId);

            }
            if (e.CommandName == "decline")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                string selectedAdminNo = gvInternResults.Rows[index].Cells[2].Text;

                internSurveyDAO objDAO = new internSurveyDAO();
                objDAO.deleteSurvey(selectedAdminNo);

                Response.Redirect(Request.RawUrl);
            }
            if (e.CommandName == "downloadResume")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                string selectedAdminNo = gvInternResults.Rows[index].Cells[2].Text;

                internSurveyDAO objDAO = new internSurveyDAO();
                internSurveyResults srObj = new internSurveyResults();
                srObj = objDAO.getSRbyAdminNo(selectedAdminNo);

                Response.ContentType = "application/octet-stream";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + srObj.isResume);
                Response.TransmitFile(Server.MapPath("~/Images/resumeFiles/" + srObj.isResume));
                Response.End();
            }
        }

        protected void gvAccepted_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "approve")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                string selectedAdminNo = gvAccepted.Rows[index].Cells[0].Text;

                interviewDAO idDAO = new interviewDAO();
                idDAO.deleteInterview(selectedAdminNo);

                ProfileInformation studDAO = new ProfileInformation();
                studDAO.updateAppStatus(selectedAdminNo);

                Response.Redirect(Request.RawUrl);
            }
            if (e.CommandName == "reject")
            {
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                string selectedAdminNo = gvAccepted.Rows[index].Cells[0].Text;

                interviewDAO idDAO = new interviewDAO();
                idDAO.deleteInterview(selectedAdminNo);

                Response.Redirect(Request.RawUrl);
            }
        }
    }
}