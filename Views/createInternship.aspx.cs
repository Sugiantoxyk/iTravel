using iTravel.DAL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iTravel.Views
{
    public partial class createInternship : System.Web.UI.Page
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
        }

        protected void createInternBtn_Click(object sender, EventArgs e)
        {
            if (fuLogo.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(fuLogo.FileName);
                    fuLogo.SaveAs(Server.MapPath("~/Images/companyLogos/") + filename);
                    lblUploadImage.Text = "Image uploaded!";
                }
                catch (Exception ex)
                {
                    lblUploadImage.Text = "The image could not be uploaded." + ex.Message;
                }
            }
            string imageName = Path.GetFileName(fuLogo.FileName).ToString();
            string imageType = Path.GetExtension(fuLogo.FileName).ToString();
            string jobTitle = tbJobTitle.Text;
            string country = tbCountry.Text;
            string Salary = tbSalary.Text;
            string website = tbWebsite.Text;
            string contact = tbContact.Text;
            string industry = tbIndustry.Text;
            string duration = tbDuration.Text;
            string workingHrs = tbWorkingHrs.Text;
            string company = tbCompany.Text;
            string overview = tbOverview.Text;
            string jobScope = tbJobScope.Text;
            string eligibility = tbEligibility.Text;
            string specialQn = tbSpecialQn.Text;

            internshipDAO newInternship = new internshipDAO();
            int intSurvey = newInternship.addInternship(imageName, imageType, jobTitle,country, Salary, website, contact, industry, duration, workingHrs, company, overview, jobScope, eligibility, specialQn);
            if (intSurvey == 1)
            {
                lblResult.Text = "Not Failed";
            }
            else
            {
                lblResult.Text = "Failed";
            }
        }
    }
}