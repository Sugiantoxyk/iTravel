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
using iTravel.Models;
using iTravel.DAL;

namespace iTravel.Views
{
    public partial class BlogHome : System.Web.UI.Page
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Only allow Student and Staff to access
                    if (Session["whoWho"].ToString() == "Student" || Session["whoWho"].ToString() == "Staff")
                    {
                        DataSet ds = new DataSet();
                        StringBuilder sqlStr = new StringBuilder();
                        sqlStr.AppendLine("SELECT DISTINCT tripLocation from Trip");

                        SqlConnection myConn = new SqlConnection(DBConnect);
                        SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

                        da.Fill(ds, "TableTD");

                        foreach (DataRow pRow in ds.Tables["TableTD"].Rows)
                        {
                            createTrip tripObj = new createTrip();
                            blogDAO blogDao = new blogDAO();
                            tripObj = blogDao.getTripImage(pRow["tripLocation"].ToString());
                            String tripImage = tripObj.tripImage;

                            Console.WriteLine(pRow["tripLocation"]);
                            HtmlGenericControl img = new HtmlGenericControl("img");
                            if(tripImage == "")
                            {
                                img.Attributes.Add("src", "../Images/tripIMG/no-img.png");
                            }
                            else
                            {
                                img.Attributes.Add("src", "../Images/tripIMG/" + tripImage); //add img for the trip
                            }
                            img.Attributes.Add("class", "imgLoc");

                            HtmlGenericControl newDiv = new HtmlGenericControl("div");
                            newDiv.Attributes.Add("class", "divLoc col-md-4");

                            HtmlGenericControl pDiv = new HtmlGenericControl("div");
                            pDiv.Attributes.Add("class", "pDiv");
                            pDiv.InnerHtml = (String)pRow["tripLocation"];

                            HtmlGenericControl a = new HtmlGenericControl("a");
                            a.Attributes.Add("href", "Blog.aspx?BlogLocation=" + pDiv.InnerHtml);
                            a.Attributes.Add("class", "aLoc");

                            //append into page placeholder
                            newDiv.Controls.Add(img);
                            newDiv.Controls.Add(pDiv);
                            a.Controls.Add(newDiv);
                            blogPH.Controls.Add(a);
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