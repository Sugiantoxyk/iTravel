using iTravel.DAL;
using iTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iTravel.Views
{
    public partial class StudentViewTrip : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Only for Student
                    if (Session["whoWho"].ToString() == "Student")
                    {
                        string tripId = Request.QueryString["tripId"].ToString();
                        studentTripRetrieve stud = new studentTripRetrieve();
                        studentTripRetrieveDAO studDao = new studentTripRetrieveDAO();
                        createTrip tripObj = new createTrip();
                        CreateTripDAO tripDAO = new CreateTripDAO();
                        tripObj = tripDAO.retrieveInfo(Request.QueryString["tripId"].ToString());
                        lbGetImg.Text = tripObj.tripId.ToString();
                        lbImg.Attributes["src"] = "../Images/tripIMG/" + tripObj.tripIMG.ToString();
                        stud = studDao.getTripById(tripId);
                        LbStartDate.Text = stud.tripStartDate;
                        LbCost.Text = stud.tripCost;
                        LbDesc.Text = stud.tripDesc;
                        LbEndDate.Text = stud.tripEndDate;
                        LbLocation.Text = stud.tripName;
                        Lbtrip.Text = stud.tripId;
                        Lbtripname.Text = stud.tripName;
                        Lbtriptype.Text = stud.triptype;
                        Labelname.Text = stud.tripName;
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

        protected void surveyBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("tripSurvey.aspx?QStripId=" +"12"+"&tname="+Lbtripname.Text+"&ttype="+Lbtriptype.Text);
            string id = Request.QueryString["tid"].ToString();
            string name = Request.QueryString["tname"].ToString();
            string type = Request.QueryString["ttype"].ToString();
            
        }
    }
}