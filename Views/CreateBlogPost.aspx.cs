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
    public partial class CreateBlog : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                try
                {
                    // Only allow Student and Staff to access
                    if (Session["whoWho"].ToString() == "Student" || Session["whoWho"].ToString() == "Staff")
                    {
                        string location = Request.QueryString["location"].ToString();
                        lbBlogLocation.Text = location;
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

        protected void btnPostBlog_Click(object sender, EventArgs e)
        {
            String blogTitle = tbBlogTitle.Text.ToString();
            String blogDesc = tbBlogDesc.Text.ToString();
            String blogUser = Session["name"].ToString();
            String blogImages = Path.GetFileName(blogImage.FileName).ToString();
            //String blogUser = //current user;
            DateTime blogDateTime = DateTime.Now;
            String blogLocation = lbBlogLocation.Text.ToString();

            blogDAO newBlog = new blogDAO();
            newBlog.NewBlogPost(blogTitle, blogDesc, blogUser ,blogDateTime, blogLocation, blogImages, "Posted", 0);

            if (blogImage.HasFile)
            {
                try
                {
                    string filename = Path.GetFileName(blogImage.FileName);
                    blogImage.SaveAs(Server.MapPath("~/Images/blogImages/") + filename);
                }
                catch (Exception ex)
                {

                }
            }

            Response.Redirect("Blog.aspx?BlogLocation=" + blogLocation);
        }
    }
}