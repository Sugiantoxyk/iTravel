using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iTravel.views
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                try
                {
                    FORPRESENTATION.InnerText = Session["whoWho"].ToString();

                    if (Session["whoWho"].ToString() == "Student")
                    {
                        whenStudentLogIn.Visible = true;
                        onlyStudent.Visible = true;
                        if (Session["test"] == "-1")
                        {
                            whenStudentLogIn.Visible = false;
                            onlyStudent.Visible = true;
                            whenStudentawaits.Visible = true;
                        }
                        if (Session["test"] == "1")
                        {
                            whenStudentLogIn.Visible = false;
                            onlyStudent.Visible = true;
                            whenStudentLogInAccept.Visible = true;
                        }

                        if (Session["test"] == "0")
                        {
                            whenStudentLogIn.Visible = false;
                            onlyStudent.Visible = true;
                            whenStudentLogInDecline.Visible = true;
                        }
                        if (Session["test"] == "99")
                        {
                            whenStudentLogIn.Visible = true;
                            onlyStudent.Visible = true;
                            whenStudentLogInDecline.Visible = false;
                        }
                        if(Session["test"] == "4")
                    {
                            whenStudentLogIn.Visible = false;
                            onlyStudent.Visible = true;
                            whenStudentPaid.Visible = true;
                        }
                    }
                    else if (Session["whoWho"].ToString() == "Staff")
                    {
                        whenStaffLogIn.Visible = true;
                    }
                    else if (Session["whoWho"].ToString() == "Admin")
                    {
                        whenAdminLogIn.Visible = true;
                    }
                    else if (Session["whoWho"].ToString() == "Parent")
                    {
                        whenParentLogIn.Visible = true;
                    }
                }
                catch (NullReferenceException)
                {
                    Response.Redirect("login.aspx");
                }

                myName.InnerText = Session["name"].ToString();
                alsoMyName.InnerText = Session["name"].ToString();
            }
        }
    }
}