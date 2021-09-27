using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iTravel.Views
{
    public partial class StaffViewSurveyResults : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Only for Staff
                    if (Session["whoWho"].ToString() != "Admin")
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
            Response.Redirect("DecisionSurveyResults.aspx?Id=" + GridView1.SelectedRow.Cells[0].Text);
        }
        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView2.SelectedRow;
            Response.Redirect("DecisionSurveyResults.aspx?Id=" + GridView2.SelectedRow.Cells[0].Text);
        }

    }
}