using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace iTravel.Views
{
    public partial class immersionTrips : System.Web.UI.Page
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["test"] = "99";
        
            if (!IsPostBack)
            {
                try
                {
                    // Only for Student and Parent
                    if (Session["whoWho"].ToString() == "Student" || Session["whoWho"].ToString() == "Parent")
                    {
                        DataSet ds = new DataSet();
                        StringBuilder sqlStr = new StringBuilder();
                        sqlStr.AppendLine("SELECT * from Trip");
                        sqlStr.AppendLine("WHERE tripType = 'Immersion'");

                        SqlConnection myConn = new SqlConnection(DBConnect);
                        SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

                        da.Fill(ds, "TableTD");

                        if (ds.Tables["TableTD"].Rows.Count != 0)
                        {
                            foreach (DataRow pRow in ds.Tables["TableTD"].Rows)
                            {
                                Console.WriteLine(pRow["Id"]);

                                HtmlGenericControl a = new HtmlGenericControl("a");
                                a.Attributes.Add("href","studentViewTrip.aspx?tripId="+ pRow["Id"].ToString()); //href

                                HtmlGenericControl div = new HtmlGenericControl("div");
                                div.Attributes.Add("style", "box-shadow: 1px 1px 5px 0px rgba(0, 0, 0, 0.3); padding: 15px; margin: 10px;");

                                HtmlGenericControl title = new HtmlGenericControl("p");
                                title.InnerHtml = (String)pRow["tripName"];
                                title.Attributes.Add("style", "font-weight: bold;");

                                a.Controls.Add(div);
                                div.Controls.Add(title);
                                immersionTripe.Controls.Add(a);
                            }
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