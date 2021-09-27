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
    public partial class DecisionSurveyResults : System.Web.UI.Page
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
                        if (Session["whoWho"].ToString() == "Admin")
                        {
                            surveyResults Survobj = new surveyResults();
                            surveyResultsDAO surveyDAO = new surveyResultsDAO();
                            Survobj = surveyDAO.retrieveInfo(Request.QueryString["Id"].ToString());
                            Label1.Text = Survobj.surAdminNo;
                            Label2.Text = Survobj.surAllergy;
                            Label3.Text = Survobj.surAddress;
                            Label4.Text = Survobj.surBuddy ;
                            Label5.Text = Survobj.surCCA;
                            Label6.Text = Survobj.surCitizenship;
                            Label7.Text = Survobj.surContact;
                            Label8.Text = Survobj.surDiploma;
                            Label9.Text = Survobj.surDOB;
                            Label10.Text = Survobj.surFasopApply;
                            Label11.Text = Survobj.surFasopHist;
                            Label12.Text = Survobj.surFullName;
                            Label13.Text = Survobj.surGender;
                            Label14.Text = Survobj.surGPA;
                            Label15.Text = Survobj.surLeadership;
                            Label16.Text = Survobj.surMedCondition;
                            Label17.Text = Survobj.surMedication;
                            Label18.Text = Survobj.surOffence;
                            Label19.Text = Survobj.surPassportExp;
                            Label20.Text = Survobj.surPassportNo;
                            Label21.Text = Survobj.surPEMGroup;
                            Label22.Text = Survobj.surPEMnote;
                           
                            Label25.Text = Survobj.surFullName + "'s Survey Submission";
                            Label26.Text = Survobj.surtripName;
                            Label27.Text = Survobj.surFullName;






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


            Session["test"] = "1";
            surveyResults Survobj = new surveyResults();
            surveyResultsDAO surveyDAO = new surveyResultsDAO();
         
            createTrip selTrip = new createTrip();
            CreateTripDAO updTrip = new CreateTripDAO();
            int updCnt;

            Survobj = surveyDAO.DeleteInfo(Request.QueryString["Id"].ToString());
            //int updRenewMode = 0;


            selTrip = updTrip.retrievestudlist(Label26.Text);

           updCnt = updTrip.updateStudentList(Label26.Text, Label27.Text + "," + selTrip.tripStudentList);
            lbSucess.Visible = false;
            if (updCnt == 1)
            {
                ProfileInformation profile = new ProfileInformation();
                profile.setTripStatusTo4(Label1.Text);

                lbSucess.Text = "Student was accepted";
                Response.Redirect("StaffViewSurveyResults.aspx");
            }
            else
            {
                lbSucess.Text = "Student accepted Unsucessfully";
                lbSucess.Visible = true;
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StaffViewSurveyResults.aspx");
        }

        protected void tbUpdTrip_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnDecline_Click(object sender, EventArgs e)
        {
            Session["test"] = "0";
            surveyResults Survobj = new surveyResults();
            surveyResultsDAO surveyDAO = new surveyResultsDAO();
            Survobj = surveyDAO.DeleteInfo(Request.QueryString["Id"].ToString());
           
            Response.Redirect("StaffViewSurveyResults.aspx");
        }
    }
}