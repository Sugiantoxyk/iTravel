using iTravel.DAL;
using iTravel.models;
using iTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iTravel.Views
{
    public partial class PEMEditSurveyResults : System.Web.UI.Page
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
                            surveyResults Survobj = new surveyResults();
                            surveyResultsDAO surveyDAO = new surveyResultsDAO();
                            Survobj = surveyDAO.retrieveInfo(Request.QueryString["Id"].ToString());
                            tbUpdTrip.Text = Survobj.surPEMnote;
                            Label25.Text = "Add a Note for " + Survobj.surFullName ;
                           
                           

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
            surveyResults selTrip = new surveyResults();
             surveyResultsDAO updTrip = new surveyResultsDAO();
            int updCnt;
            //int updRenewMode = 0;

            updCnt = updTrip.updateSurvey(tbUpdTrip.Text,Request.QueryString["Id"].ToString());
            lbSucess.Visible = false;
            if (updCnt == 1)
            {
                lbSucess.Text = "PEM note added Sucessfully";
                lbSucess.Visible = true;
            }
            else
            {
                lbSucess.Text = "PEM note added Unsucessfully";
                lbSucess.Visible = true;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("PEMViewSurveyResults.aspx");
        }

        protected void tbUpdTrip_TextChanged(object sender, EventArgs e)
        {

        }
    }
}