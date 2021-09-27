using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTravel.DAL;

namespace iTravel.Views
{
    public partial class login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Session["whoWho"] = null;
                Session["name"] = null;
                Session["username"] = null;
            }
        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            errorDiv.InnerHtml = "";
            var result = true;
            if (inputUsername.Text == "")
            {
                errorDiv.InnerHtml += "<p>Username is empty!<p>";
                result = false;
            }
            if (inputPassword.Text == "")
            {
                errorDiv.InnerHtml += "<p>Password is empty!<p>";
                result = false;
            }
            if (result)
            {
                // Student?
                CheckLogin checkLogin = new CheckLogin();
                string pass = encryption(inputPassword.Text);
                List<String> returnVal = checkLogin.checkForStudentLogin(inputUsername.Text, pass);
                if (returnVal[1] != null)
                {
                    // Success
                    errorDiv.InnerHtml = "";
                    Session["whoWho"] = returnVal[0];
                    Session["name"] = returnVal[1];
                    Session["username"] = inputUsername.Text;
                    Response.Redirect("studyTrips.aspx");
                }
                else
                {
                    // Staff?
                    returnVal = checkLogin.checkForStaffLogin(inputUsername.Text, pass);
                    if (returnVal[1] != null)
                    {
                        // Success
                        errorDiv.InnerHtml = "";
                        Session["whoWho"] = returnVal[0];
                        Session["name"] = returnVal[1];
                        Session["pemgroup"] = returnVal[2];
                        Session["username"] = inputUsername.Text;
                        Response.Redirect("home.aspx");
                    }
                    else
                    {
                        // Admin?
                        returnVal = checkLogin.checkForAdminLogin(inputUsername.Text, pass);
                        if (returnVal[1] != null)
                        {
                            // Success
                            errorDiv.InnerHtml = "";
                            Session["whoWho"] = returnVal[0];
                            Session["name"] = returnVal[1];
                            Session["username"] = inputUsername.Text;
                            Response.Redirect("home.aspx");
                        }
                        else
                        {
                            // Parent?
                            returnVal = checkLogin.checkForParentLogin(inputUsername.Text, pass);
                            if (returnVal[1] != null)
                            {
                                // Success
                                errorDiv.InnerHtml = "";
                                Session["whoWho"] = returnVal[0];
                                Session["name"] = returnVal[1];
                                Session["username"] = inputUsername.Text;
                                Response.Redirect("home.aspx");
                            }
                            else
                            {
                                errorDiv.InnerHtml += "<p>Please check your username and password.<p>";
                            }
                        }
                    }
                }

            }
            errorDiv.Style.Add("visibility", "visible");
        }

        public string encryption(string str)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[str.Length];
            encode = Encoding.UTF8.GetBytes(str);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
    }
}