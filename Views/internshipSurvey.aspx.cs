using iTravel.DAL;
using iTravel.models;
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
    public partial class internshipSurvey : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Only for Student
                    if (Session["whoWho"].ToString() == "Student")
                    {
                        string intId = Request.QueryString["QSIntId"].ToString();
                        tbIntId.Text = intId;
                        internshipInfo intObj = new internshipInfo();
                        internshipDAO intDAO = new internshipDAO();
                        intObj = intDAO.getInternshipById(intId);
                        lbTitle.Text = intObj.intJobTitle;
                        lbSpecialQn.Text = intObj.intSpecialQn;
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

        protected void submitSurveyBtn(object sender, EventArgs e)
        {
            if (fuResume.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fuResume.FileName);
                    fuResume.SaveAs(Server.MapPath("~/Images/resumeFiles/") + filename);
                    lblFile.Text = "File uploaded!";
                }
                catch (Exception ex)
                {
                    lblFile.Text = "The file could not be uploaded." + ex.Message;
                }
            }
            string intId = tbIntId.Text;
            string diploma = ddlDiploma.SelectedValue.ToString();
            string PEMGroup = tbPEMGroup.Text;
            string adminNo = tbAdminNo.Text;
            string fullName = tbFullName.Text;
            string gender = rblGender.SelectedValue.ToString();
            string DOB = tbDOB.Text;
            string contact = tbContact.Text;
            string address = tbAddress.Text;
            string citizenship = ddlCitizenship.SelectedValue.ToString();
            string passportNo = tbPassportNo.Text;
            string passportExp = tbPassportExp.Text;
            string waitList = rblWaitList.SelectedValue.ToString();
            string GPA = tbGPA.Text;
            string CCA = tbCCA.Text;
            string leadership = tbLeadership.Text;
            string offence = tbOffence.Text;
            string PSEABalance = tbPSEABalance.Text;
            string fundingScheme = rblFundingScheme.Text;
            string fasopHist = rblFasopHist.Text;
            string medCondition = tbMedCondition.Text;
            string partTimeExp = tbPartTimeExp.Text;
            string overseasStay = ddlOverseasStay.Text;
            string independence = tbIndependence.Text;
            string specialAns = tbSpecialAns.Text;
            string resume = Path.GetFileName(fuResume.FileName);

            internSurveyDAO newSurvey = new internSurveyDAO();
            int intSurvey = newSurvey.addSurvey(intId, diploma, PEMGroup, adminNo, fullName, gender, DOB, contact, address, citizenship, passportNo, passportExp, waitList, GPA, CCA, leadership, offence, PSEABalance, fundingScheme, fasopHist, medCondition, partTimeExp, overseasStay, independence, specialAns, resume);
            if (intSurvey == 1)
            {
                lblResult.Text = "Not Failed";
                Response.Redirect("viewInternship.aspx?QSintId=" + tbIntId.Text);
            }
            else
            {
                lblResult.Text = "Failed";
            }
        }

        protected void btnAutoFill_Click(object sender, EventArgs e)
        {
            ProfileInformation studentDAO = new ProfileInformation();
            StudentInformation studObj = studentDAO.retrieveStudentInformation(Session["username"].ToString());
            ddlDiploma.SelectedItem.Text = studObj.studentCourse;
            tbPEMGroup.Text = studObj.PEMGroup;
            tbAdminNo.Text = studObj.adminNo;
            tbFullName.Text = studObj.studentName;
            if (studObj.studentGender == "Male")
                rblGender.SelectedValue = "M";
            else
                rblGender.SelectedValue = "F";
            tbDOB.Text = studObj.DOB;
            tbContact.Text = studObj.studentHP;
            tbAddress.Text = studObj.studentAddress;
            string SN = studObj.studentNationality;
            if (SN != "Singapore" && SN != "Permanent Resident" && SN != "Malaysia" && SN != "Indonesia" && SN != "China" && SN != "India")
                ddlCitizenship.SelectedValue = "Other";
            else
                ddlCitizenship.SelectedValue = SN;
            tbPassportNo.Text = studObj.passportNo;
            tbPassportExp.Text = studObj.passportExpDate;
            rblWaitList.SelectedIndex = 0;
            tbGPA.Text = studObj.studentGPA;
            tbCCA.Text = studObj.studentCCA;
        }
        
    }
}