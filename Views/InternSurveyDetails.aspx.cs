using iTravel.DAL;
using iTravel.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iTravel.Views
{
    public partial class InternSurveyDetails : System.Web.UI.Page
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
                        internSurveyDAO objDAO = new internSurveyDAO();
                        internSurveyResults srObj = new internSurveyResults();
                        srObj = objDAO.getSRbyAdminNo(adminNo);

                        lbTitle.Text = srObj.isFullName;
                        lbFullName.Text = srObj.isFullName;
                        lbAdminNo.Text = srObj.isAdminNo;
                        lbDiploma.Text = srObj.isDiploma;
                        lbPEMGroup.Text = srObj.isPEMGroup;
                        lbGender.Text = srObj.isGender;
                        lbDOB.Text = srObj.isDOB;
                        lbContact.Text = srObj.isContact;
                        lbAddress.Text = srObj.isAddress;
                        lbCitizenship.Text = srObj.isCitizenship;
                        lbPassportNo.Text = srObj.isPassportNo;
                        lbPassportExp.Text = srObj.isPassportExp;
                        lbWaitList.Text = srObj.isWaitList;
                        lbGPA.Text = srObj.isGPA;
                        lbCCA.Text = srObj.isCCA;
                        lbLeadership.Text = srObj.isLeadership;
                        lbOffence.Text = srObj.isOffence;
                        lbPSEABalance.Text = srObj.isPSEABalance;
                        lbFundingScheme.Text = srObj.isFundingScheme;
                        lbFasopHist.Text = srObj.isFasopHist;
                        lbMedCondition.Text = srObj.isMedCondition;
                        lbPartTimeExp.Text = srObj.isPartTimeExp;
                        lbOverseasStay.Text = srObj.isOverseasStay;
                        lbIndependence.Text = srObj.isIndependence;
                        lbSpecialAns.Text = srObj.isSpecialAns;

                        internshipInfo intObj = new internshipInfo();
                        internshipDAO intDAO = new internshipDAO();
                        intObj = intDAO.getInternshipById(srObj.isIntId);
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
    }
}