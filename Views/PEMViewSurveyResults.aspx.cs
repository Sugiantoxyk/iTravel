using iTravel.DAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iTravel.Views
{
    public partial class PEMViewSurveyResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                string pemid = Session["pemgroup"].ToString(); 
               
                try
                {
                    // Only for Staff
                    if (Session["whoWho"].ToString() == "Staff")
                    {

                        Label2.Text = "Immersion trip survey results [" + pemid +"]";
                        Label1.Text = "Study trip survey results [" + pemid + "]";
                       
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


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            Response.Redirect("PEMEditSurveyResults.aspx?Id=" + GridView1.SelectedRow.Cells[0].Text);
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            Response.Redirect("PEMEditSurveyResults.aspx?Id=" + GridView2.SelectedRow.Cells[0].Text);
        }
        
    }
}