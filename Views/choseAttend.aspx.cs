using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTravel.DAL;

namespace iTravel.Views
{
    public partial class choseAttend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Only for Student
                    if (Session["whoWho"].ToString() != "Student")
                    {
                        Response.Redirect("home.aspx");
                    }
                }
                catch (NullReferenceException)
                {
                    Response.Redirect("login.aspx");
                }

                // Check if got Query String
                try
                {
                    if (Request.QueryString["id"].ToString() != null)
                    {
                        string id = Request.QueryString["id"].ToString();
                        string attending = Request.QueryString["attend"].ToString();
                        string adminNo = Request.QueryString["adminno"].ToString();

                        runAFunction(id, attending, adminNo);
                    }
                }
                catch (NullReferenceException)
                {
                    Response.Redirect("home.aspx");
                }
            }
        }

        void runAFunction(string id, string attending, string adminNo)
        {
            HomeInformation dao = new HomeInformation();
            dao.attendingOrNo(id, adminNo, attending);
            Response.Redirect("home.aspx");
        }
    }
}