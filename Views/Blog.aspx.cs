using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTravel.DAL;
using iTravel.Models;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;

namespace iTravel.Views
{
    public partial class Blog : System.Web.UI.Page
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
                        string location = Request.QueryString["BlogLocation"].ToString();
                        string status = "Posted";

                        lbLocTitle.Text = location + " Blog";

                        DataSet ds = new DataSet();
                        StringBuilder sqlStr = new StringBuilder();
                        sqlStr.AppendLine("SELECT * from Blog");
                        sqlStr.AppendLine("WHERE blogLocation = @paralocation AND blogStatus = 'Posted'");
                        sqlStr.AppendLine("ORDER BY blogDateTime DESC");

                        SqlConnection myConn = new SqlConnection(DBConnect);
                        SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

                        da.SelectCommand.Parameters.AddWithValue("paralocation", location);

                        da.Fill(ds, "TableTD");

                        String previousDate = "";

                        if (ds.Tables["TableTD"].Rows.Count != 0)
                        {
                            for (int i = 0; i < ds.Tables["TableTD"].Rows.Count; i++)
                            {
                                DataRow currentRow = ds.Tables["TableTD"].Rows[i];
                                String currentDate = Convert.ToDateTime(currentRow["blogDateTime"]).ToString("dddd, dd MMMM yyyy");


                                if (previousDate != currentDate)
                                {
                                    HtmlGenericControl ldiv = new HtmlGenericControl("div");
                                    ldiv.Attributes.Add("class", "uniqueDate");
                                    HtmlGenericControl date = new HtmlGenericControl("h2");
                                    date.InnerHtml = currentDate;
                                    ldiv.Controls.Add(date);
                                    ldiv.Controls.Add(new LiteralControl("<br/>"));
                                    ldiv.Controls.Add(new LiteralControl("<br/>"));
                                    blogs.Controls.Add(ldiv);
                                }

                                previousDate = Convert.ToDateTime(currentRow["blogDateTime"]).ToString("dddd, dd MMMM yyyy");

                                HtmlGenericControl sdiv = new HtmlGenericControl("div");
                                sdiv.Attributes.Add("class", "post");

                                HtmlGenericControl title = new HtmlGenericControl("p");
                                title.InnerHtml = (String)currentRow["blogTitle"];
                                title.Attributes.Add("class", "postTitle");

                                HtmlGenericControl imgDiv = new HtmlGenericControl("div");
                                imgDiv.Attributes.Add("class", "postImgDiv");

                                HtmlGenericControl img = new HtmlGenericControl("img");
                                img.Attributes.Add("class", "postImg");
                                img.Attributes.Add("src", "../Images/blogImages/" + currentRow["blogImage"].ToString());
                                   
                                HtmlGenericControl description = new HtmlGenericControl("p");
                                description.InnerHtml = ((String)currentRow["blogDesc"]).Replace("\r\n", "<br />");
                                description.Attributes.Add("class", "postDesc");

                                HtmlGenericControl user = new HtmlGenericControl("p");
                                user.InnerHtml = "Posted by: " + (String)currentRow["blogUser"];
                                user.Attributes.Add("class", "postUser");

                                HtmlGenericControl dte = new HtmlGenericControl("p");
                                dte.InnerHtml = currentRow["blogDateTime"].ToString();
                                dte.Attributes.Add("class", "postDateTime");

                                HtmlGenericControl infoDiv = new HtmlGenericControl("div");
                                infoDiv.Attributes.Add("class", "postInfo");
                                infoDiv.Controls.Add(user);
                                infoDiv.Controls.Add(dte);

                                HtmlGenericControl reportBtn = new HtmlGenericControl("a");
                                reportBtn.Attributes.Add("class", "reportBtn fa fa-exclamation-triangle");
                                reportBtn.Attributes.Add("href", "reportAdd.aspx?blogId=" + Convert.ToInt32(currentRow["blogID"]) + "&BlogLocation=" + location);
                                reportBtn.InnerHtml = "   Report";

                                HtmlGenericControl reportDiv = new HtmlGenericControl("div");
                                reportDiv.Attributes.Add("class", "postReport");
                                reportDiv.Controls.Add(reportBtn);

                                sdiv.Controls.Add(title);
                                if (currentRow["blogImage"].ToString() != "")
                                {
                                    imgDiv.Controls.Add(img);
                                    sdiv.Controls.Add(imgDiv);
                                    sdiv.Controls.Add(new LiteralControl("<br/>"));
                                }
                                sdiv.Controls.Add(description);
                                sdiv.Controls.Add(new LiteralControl("<br/>"));
                                sdiv.Controls.Add(reportDiv);
                                sdiv.Controls.Add(infoDiv);
                                blogs.Controls.Add(sdiv);
                                blogs.Controls.Add(new LiteralControl("<br/>"));
                                blogs.Controls.Add(new LiteralControl("<br/>"));
                                blogs.Controls.Add(new LiteralControl("<br/>"));
                            }
                        }
                        else
                        {
                            HtmlGenericControl h1 = new HtmlGenericControl("h1");
                            h1.InnerHtml = "No Blog Posts Yet ☹️";
                            h1.Attributes.Add("style", "text-align: center; ");

                            blogs.Controls.Add(h1);
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

        protected void btnNew_Click(object sender, EventArgs e)
        {
            string location = Request.QueryString["BlogLocation"].ToString();
            Response.Redirect("CreateBlogPost.aspx?location=" + location);
        }
    }
}