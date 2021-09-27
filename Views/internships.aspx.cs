using iTravel.DAL;
using iTravel.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace iTravel.Views
{
    public partial class internships : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Only for Student and Parent
                    if (Session["whoWho"].ToString() == "Student" || Session["whoWho"].ToString() == "Parent")
                    {

                        internshipDAO intDAO = new internshipDAO();
                        List<internshipInfo> intList = new List<internshipInfo>();

                        intList = intDAO.getInternshipName();
                        foreach (internshipInfo obj in intList)
                        {
                            HtmlGenericControl newDiv = new HtmlGenericControl("div");
                            newDiv.Attributes.Add("class", "internDiv");
                            HtmlGenericControl newA = new HtmlGenericControl("a");
                            newA.Attributes.Add("href", "viewInternship.aspx?QSintId=" + obj.intId.ToString());
                            newA.Attributes.Add("class", "newA");
                            newA.Attributes.Add("style", "text-decoration:none;");
                            HtmlGenericControl newImg = new HtmlGenericControl("img");
                            newImg.Attributes.Add("src", "../Images/companyLogos/" + obj.intImageName.ToString());
                            newImg.Attributes.Add("width", "200px");
                            HtmlGenericControl newh3 = new HtmlGenericControl("h3");
                            newh3.InnerHtml = obj.intJobTitle;
                            newh3.Attributes.Add("class", "col-md-2");
                            HtmlGenericControl newBr = new HtmlGenericControl("br");
                            HtmlGenericControl newP = new HtmlGenericControl("p");
                            newP.InnerHtml = obj.intOverview;
                            newP.Attributes.Add("class", "col-md-9 overview");
                            newDiv.Controls.Add(newh3);
                            newDiv.Controls.Add(newBr);
                            newDiv.Controls.Add(newP);
                            newDiv.Controls.Add(newImg);
                            newA.Controls.Add(newDiv);
                            jobTitle.Controls.Add(newA);
                            jobTitle.Controls.Add(new HtmlGenericControl("br"));
                        }
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