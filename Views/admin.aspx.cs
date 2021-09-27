using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTravel.Models;
using iTravel.DAL;
using System.Data;

namespace iTravel.Views
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Only for Admin
                    if (Session["whoWho"].ToString() == "Admin")
                    {

                        GridView_AllBlog.Visible = false;
                        GridView_Archived.Visible = false;
                        GridView_Blog.Visible = false;
                        GridView_Reported.Visible = false;
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

        protected void GridView_Blog_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Archive")
            {
                adminDAO adminDao = new adminDAO();
        
                int index = Convert.ToInt32(e.CommandArgument.ToString());
                int blogID = Convert.ToInt32(GridView_Blog.Rows[index].Cells[0].Text);

                adminDao.updateStatus(blogID, "Archived");

                Response.Redirect("admin.aspx");
            } 
        }

        protected void GridView_Archived_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Undo Archive")
            {
                adminDAO adminDao = new adminDAO();

                int index = Convert.ToInt32(e.CommandArgument.ToString());
                int blogID = Convert.ToInt32(GridView_Archived.Rows[index].Cells[0].Text);

                adminDao.updateStatus(blogID, "Posted");

                Response.Redirect("admin.aspx");
            }
            if (e.CommandName == "Delete")
            {
                adminDAO adminDao = new adminDAO();

                int index = Convert.ToInt32(e.CommandArgument.ToString());
                int blogID = Convert.ToInt32(GridView_Archived.Rows[index].Cells[0].Text);

                adminDao.deleteBlog(blogID);

                Response.Redirect("admin.aspx");
            }
        }

        protected void GridView_Reported_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Archive")
            {
                adminDAO adminDao = new adminDAO();

                int index = Convert.ToInt32(e.CommandArgument.ToString());
                int blogID = Convert.ToInt32(GridView_Blog.Rows[index].Cells[0].Text);

                adminDao.updateStatus(blogID, "Archived");

                Response.Redirect("admin.aspx");
            }
        }

        protected void ddlCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlCat.SelectedValue == "--Select--" )
            {
                GridView_AllBlog.Visible = false;
                GridView_Archived.Visible = false;
                GridView_Blog.Visible = false;
                GridView_Reported.Visible = false;
                LbMsg.Visible = false;
            }
            else if (ddlCat.SelectedValue == "All Blogs")
            {
                GridView_AllBlog.Visible = true;
                GridView_Archived.Visible = false;
                GridView_Blog.Visible = false;
                GridView_Reported.Visible = false;

                if(GridView_AllBlog.Rows.Count == 0)
                {
                    LbMsg.Text = "No Blogs";
                    LbMsg.Visible = true;
                }
                else
                {
                    LbMsg.Visible = false;
                }
            }
            else if (ddlCat.SelectedValue == "Posted Blogs")
            {
                GridView_AllBlog.Visible = false;
                GridView_Blog.Visible = true;
                GridView_Archived.Visible = false;
                GridView_Reported.Visible = false;

                if (GridView_Blog.Rows.Count == 0)
                {
                    LbMsg.Text = "No Posted Blogs";
                    LbMsg.Visible = true;
                }
                else
                {
                    LbMsg.Visible = false;
                }
            }
            else if (ddlCat.SelectedValue == "Reported Blogs")
            {
                GridView_AllBlog.Visible = false;
                GridView_Archived.Visible = false;
                GridView_Reported.Visible = true;
                GridView_Blog.Visible = false;


                if (GridView_Reported.Rows.Count == 0)
                {
                    LbMsg.Text = "No Reported Blogs";
                    LbMsg.Visible = true;
                }
                else
                {
                    LbMsg.Visible = false;
                }
            }
            else if (ddlCat.SelectedValue == "Archived Blogs")
            {
                GridView_AllBlog.Visible = false;
                GridView_Blog.Visible = false;
                GridView_Reported.Visible = false;
                GridView_Archived.Visible = true;

                if (GridView_Archived.Rows.Count == 0)
                {
                    LbMsg.Text = "No Archived Blogs";
                    LbMsg.Visible = true;
                }
                else
                {
                    LbMsg.Visible = false;
                }
            }
        }
    }
}