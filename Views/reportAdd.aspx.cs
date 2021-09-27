using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTravel.Models;
using iTravel.DAL;

namespace iTravel.Views
{
    public partial class reportAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            blogDAO blogDao = new blogDAO();

            int plusReport = Convert.ToInt32(Request.QueryString["blogId"]);

            blogDao.plus1Report(plusReport);

            string blogLocation = Request.QueryString["BlogLocation"].ToString();

            Response.Redirect("Blog.aspx?BlogLocation=" + blogLocation);
        }
    }
}