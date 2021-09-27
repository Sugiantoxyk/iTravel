using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using iTravel.DAL;
using iTravel.Models;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using System.Collections;
using System.Web.UI.HtmlControls;

namespace iTravel.Views
{
    public partial class home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                try
                {
                    // STUDENT
                    if (Session["whoWho"].ToString() == "Student")
                    {
                        HomeInformation dao = new HomeInformation();
                        bool aBool = dao.checkUserInTrip(Session["username"].ToString());

                        if (aBool == false)
                        {
                            homeForStudent.Visible = true;
                            ProfileInformation studDAO = new ProfileInformation();
                            StudentInformation studObj = new StudentInformation();
                            studObj = studDAO.retrieveStudentInformation(Session["username"].ToString());
                            if (studObj.applicationStatus == "1")
                            {
                                interviewDAO idDAO = new interviewDAO();
                                interview idObj = new interview();
                                idObj = idDAO.getInterviewDetailsByAdminNo(Session["username"].ToString());

                                if (idObj != null)
                                {
                                    pNotifyIntern.Visible = true;
                                    lbStaffName.Text = idObj.idStaffName;
                                    lbStaffHP.Text = idObj.idStaffHP;
                                    lbMeetDate.Text = idObj.idMeetDate;
                                    lbMeetTime.Text = idObj.idMeetTime;
                                    lbLocation.Text = idObj.idMeetLocation;
                                    lbAdditionalInfo.Text = idObj.idAdditionalInfo;
                                }
                            }
                            else if (studObj.applicationStatus == "2")
                            {
                                lbGratz.Text = "Congratulations! You have been accepted to the overseas internship programme!";
                                pNotifyIntern2.Visible = true;
                            }
                        }
                        else
                        {
                            homeForStudentInTrip.Visible = true;

                            // Eye Lids
                            eyeLid.Attributes.Remove("style");
                            eyeLid2.Attributes.Remove("style");
                            TimeSpan now = (DateTime.Now).TimeOfDay;
                            TimeSpan midnight = Convert.ToDateTime("00:00:00").TimeOfDay;
                            TimeSpan wakeUp = Convert.ToDateTime("06:00:00").TimeOfDay;
                            if (now > midnight && now < wakeUp)
                            {
                                eyeLid.Attributes.Add("style", "height: 100%;");
                                eyeLid2.Attributes.Add("style", "height: 100%;");
                            }
                            refreshOutingList();
                        }

                    }
                    // STAFF
                    else if (Session["whoWho"].ToString() == "Staff")
                    {
                        HomeInformation dao = new HomeInformation();
                        DataSet inTrip = dao.checkStaffInTrip(Session["username"].ToString());

                        // In Trip
                        if (inTrip != null)
                        {
                            homeForStaffInTrip.Visible = true;
                            createTableShowAllStudent(inTrip);
                        }
                        // Not in Trip
                        else
                        {
                            homeForStaff.Visible = true;
                        }
                    }
                    // ADMIN
                    else if (Session["whoWho"].ToString() == "Admin")
                    {
                        Response.Redirect("admin.aspx");
                    }
                    // PARENT
                    else if (Session["whoWho"].ToString() == "Parent")
                    {
                        homeForParent.Visible = true;
                        childrenDetailsForParent();
                    }
                }
                catch (NullReferenceException)
                {
                    Response.Redirect("login.aspx");
                }
            }
        }


        // STUDENT
        // Outing Organizer
        protected void openOrganizer_Click(object sender, EventArgs e)
        {
            createOrganizer.Visible = true;

            openOrganizer.Visible = false;
            cancelOrganizerBtn.Visible = true;
            createOrganizerBtn.Visible = true;

            refreshOutingList();
            emptyForm();
        }
        protected void cancelOrganizer_Click(object sender, EventArgs e)
        {
            createOrganizer.Visible = false;

            openOrganizer.Visible = true;
            cancelOrganizerBtn.Visible = false;
            createOrganizerBtn.Visible = false;

            refreshOutingList();
            emptyForm();
        }
        protected void createOrganizer_Click(object sender, EventArgs e)
        {
            if (orgTime.Text != "" && orgDesc.Text != "" && orgLocation.Text != "" && orgDate.Text != "" && orgTime.Text != "")
            {
                HomeInformation dao = new HomeInformation();
                int result = dao.createTripOrganizer(Session["username"].ToString(), orgTitle.Text, orgDesc.Text, orgLocation.Text, orgDate.Text, orgTime.Text);

                emptyForm();

                if (result == 9)
                {
                    // DATE IS NOT IN TRIP ERROR
                    createOrgFailed.Visible = true;
                    createOrgSuccess.Visible = false;
                    createOrgFailed.InnerText = "Please state the date on the trip!";
                }
                else if (result == 0)
                {
                    // SOMETHING IS WRONG ERROR
                    createOrgFailed.Visible = true;
                    createOrgSuccess.Visible = false;
                    createOrgFailed.InnerText = "Something is wrong. Please try again later.";
                }
                else if (result == 1)
                {
                    // SUCCESS
                    createOrgFailed.Visible = false;
                    createOrgSuccess.Visible = true;
                    createOrgSuccess.InnerText = "Outings Created Successfully!";

                    createOrganizer.Visible = false;

                    openOrganizer.Visible = true;
                    cancelOrganizerBtn.Visible = false;
                    createOrganizerBtn.Visible = false;

                    // UPDATE OUTING LIST
                    refreshOutingList();
                }
            }
            else
            {
                // NO EMPTY ERROR
                createOrgFailed.Visible = true;
                createOrgSuccess.Visible = false;
                createOrgFailed.InnerText = "Please fill up all inputs!";
            }
                
        }
        protected void emptyForm()
        {
            createOrgFailed.Visible = false;
            createOrgSuccess.Visible = false;
            orgTitle.Text = "";
            orgDesc.Text = "";
            orgLocation.Text = "";
            orgDate.Text = "";
            orgTime.Text = "";
        }

        // Outing List Show
        protected void refreshOutingList()
        {
            // For eye lid feedback
            goodTextEye.Visible = false;
            badTextEye.Visible = false;

            HomeInformation dao = new HomeInformation();
            DataSet ds = dao.retrieveTripOutings(Session["username"].ToString());

            int countRow = ds.Tables["returnTable"].Rows.Count;

            if (countRow != 0)
            {
                // Count 2 by 2
                for (var i = 0; i < countRow; i+=2)
                {
                    // Div Row
                    HtmlGenericControl divRow = new HtmlGenericControl("div");
                    divRow.Attributes.Add("class", "row");

                    for (var k = 0; k < 2; k++)
                    {
                        try
                        {
                            DataRow row = ds.Tables["returnTable"].Rows[i + k];

                            // Not Attending No Div
                            if (row["notAttending"].ToString().Contains(Session["username"].ToString()))
                            {
                                continue;
                            }
                            // Div Appear
                            else
                            {
                                string attending = "NIL";
                                var myList = new List<string>();
                                try
                                {
                                    attending = row["attending"].ToString().Substring(1);
                                    myList = new List<string>(attending.Split(','));
                                }
                                catch (ArgumentOutOfRangeException){}

                                
                                HtmlGenericControl divBlock = new HtmlGenericControl("div");
                                divBlock.Attributes.Add("class", "col-md-6 outingBlock");

                                HtmlGenericControl divBlockChild = new HtmlGenericControl("div");
                                divBlockChild.Attributes.Add("class", "container outingBlockChild");
                                divBlockChild.InnerHtml = "" +
                                    "<p class='titleColor'>" + row["title"].ToString() + "</p>" +
                                    "<p>" + row["description"].ToString() + "</p>" +
                                    "<p><b>Location: </b>" + row["location"].ToString() + "</p>" +
                                    "<p><b>Date & Time: </b>" + row["dateTime"].ToString() + "</p>" +
                                    "<p><b>Created by: </b>" + row["studentName"].ToString() + "</p>" +
                                    "<p><b>Attending: </b>&nbsp;" +
                                    "";

                                foreach (var b in myList)
                                {
                                    divBlockChild.InnerHtml += "<a href='profile.aspx?adminno=" + b + "' class='linkToProfile'>" + b + "</a>,&nbsp;";
                                }
                                divBlockChild.InnerHtml += "</p>";


                                // If sender is User, no option
                                // If User is attending, no option
                                if (row["attending"].ToString().Contains(Session["username"].ToString()))
                                {
                                    divBlockChild.InnerHtml += "<p class='greenAttending'>Attending</p>";
                                }
                                else if (Session["username"].ToString() == row["senderAdminNo"].ToString()){}
                                else
                                {
                                    // Attend Button
                                    HtmlGenericControl buttonAttend = new HtmlGenericControl("a");
                                    buttonAttend.InnerText = "Attending";
                                    buttonAttend.Attributes.Add("class", "attendChoose");
                                    buttonAttend.Attributes.Add("href", "choseAttend.aspx?id="+ row["Id"].ToString()+ "&attend=1&adminno=" + Session["username"].ToString());

                                    // Not Attending Button
                                    HtmlGenericControl buttonNotAttend = new HtmlGenericControl("a");
                                    buttonNotAttend.InnerText = "Not Attending";
                                    buttonNotAttend.Attributes.Add("class", "notAttendChoose");
                                    buttonNotAttend.Attributes.Add("href", "choseAttend.aspx?id=" + row["Id"].ToString() + "&attend=0&adminno="+Session["username"].ToString());

                                    divBlockChild.Controls.Add(buttonAttend);

                                    HtmlGenericControl span = new HtmlGenericControl("span");
                                    span.InnerHtml = "&nbsp;&nbsp;";
                                    divBlockChild.Controls.Add(span);

                                    divBlockChild.Controls.Add(buttonNotAttend);
                                }

                                divBlock.Controls.Add(divBlockChild);
                                divRow.Controls.Add(divBlock);

                            }

                            if (k == 1)
                            {
                                organizerEvent.Controls.Add(divRow);
                                organizerEvent.Controls.Add(new HtmlGenericControl("hr"));
                            }

                        }
                        catch (IndexOutOfRangeException)
                        {
                            organizerEvent.Controls.Add(divRow);
                            organizerEvent.Controls.Add(new HtmlGenericControl("hr"));
                            break;
                        }
                        
                    }
                }
            }
        }
        

        protected void eyeLid_Click(object sender, EventArgs e)
        {
            eyeLid.Attributes.Add("style", "height: 100%;");
            refreshOutingList();
            checkSleep();
        }
        protected void eyeLid2_Click(object sender, EventArgs e)
        {
            eyeLid2.Attributes.Add("style", "height: 100%;");
            refreshOutingList();
            checkSleep();
        }
        void checkSleep()
        {
            DateTime DateTimeNow = DateTime.Now;
            TimeSpan now = (DateTime.Now).TimeOfDay;
            TimeSpan midnight = Convert.ToDateTime("00:00:00").TimeOfDay;
            TimeSpan wakeUp = Convert.ToDateTime("06:00:00").TimeOfDay;
            

            if (eyeLid.Attributes["style"] == "height: 100%;" && eyeLid2.Attributes["style"] == "height: 100%;" && now > wakeUp)
            {
                // Update to Db
                HomeInformation dao = new HomeInformation();
                int result = dao.updateCurfew(Session["username"].ToString(), DateTimeNow);
                if (result == 1)
                {
                    goodTextEye.Visible = true;
                }
                else
                {
                    badTextEye.Visible = true;
                }
            }
        }



        // PARENT
        // Show Children Details
        protected void childrenDetailsForParent()
        {
            // Database
            string DBConnect = ConfigurationManager.ConnectionStrings["ITravelDBConnectionString"].ConnectionString;

            // Set Variables
            HomeInformation dao = new HomeInformation();
            DataSet table = dao.retrieveStudentTripInformation(Session["username"].ToString());

            int countRow = table.Tables["returnTable"].Rows.Count;

            if (countRow != 0)
            {
                for (var i = 0; i < countRow; i++)
                {
                    DataRow row = table.Tables["returnTable"].Rows[i];
                    // IN-TRIP
                    if (row["tripName"].ToString() != "")
                    {
                        HtmlGenericControl divHead = new HtmlGenericControl("div");
                        divHead.Attributes.Add("class", "container well");
                        divHead.InnerHtml = "<h2 class='childrenName'><b>" + row["studentName"].ToString() + "</b></h2>";

                        homeForParent.Controls.Add(divHead);

                        string startDate = row["tripStartDate"].ToString();
                        string endDate = row["tripEndDate"].ToString();

                        HtmlGenericControl divFirst = new HtmlGenericControl("div");
                        divFirst.Attributes.Add("class", "row");
                        divFirst.InnerHtml = "" +
                            "<div class='col-md-3 shiftLeft'><h4><b>Trip Status</b></h4></div>" +
                            "<div class='col-md-8 col-md-offset-1'>" +
                                "<div class='staffInfo'>" +
                                    "<h2 class='tripName'>" + row["tripName"].ToString() + "</h2>" +
                                    "<p class='tripType'>" + row["tripType"].ToString() + "</p>" +
                                    "<p><span class='fa fa-map-o'></span>&nbsp;&nbsp;<span class='tripLocation'>" + row["tripLocation"].ToString() + "</span></p>" +
                                    "<p class='tripSchedule'><span>" + startDate + "</span>&nbsp;-&nbsp;<span>" + endDate + "</span></p>" +
                                    "<p class='tripDesc'>" + row["tripDesc"].ToString() + "</p>" +
                                    "<br/>" +
                                    "<div class='alignRight'>" +
                                        "<b>Teacher-in-charge:</b>   " + row["staffName"].ToString() + "<br/>" +
                                        "<b>Contact Number:</b>   " + row["staffHP"].ToString() + "<br/>" +
                                        "<b>Email:</b>   " + row["staffEmail"].ToString() +
                                    "</div>" +
                                "</div>" +
                            "</div>";

                        homeForParent.Controls.Add(divFirst);
                        homeForParent.Controls.Add(new HtmlGenericControl("br"));
                        homeForParent.Controls.Add(new HtmlGenericControl("hr"));

                    }
                    else
                    {
                        HtmlGenericControl divHead = new HtmlGenericControl("div");
                        divHead.Attributes.Add("class", "container well");
                        divHead.InnerHtml = "<h2 class='childrenName'><b>" + row["studentName"].ToString() + "</b></h2>";

                        homeForParent.Controls.Add(divHead);

                        HtmlGenericControl divFirst = new HtmlGenericControl("div");
                        divFirst.Attributes.Add("class", "row");
                        divFirst.InnerHtml = "" +
                            "<div class='col-md-3 shiftLeft'><h4><b>Trip Status</b></h4></div>" +
                            "<div class='col-md-8 col-md-offset-1'>" +
                                "<p class='tripStatusText'>Currently not on any trips...</p>" +
                            "</div>";

                        homeForParent.Controls.Add(divFirst);
                        homeForParent.Controls.Add(new HtmlGenericControl("br"));
                        homeForParent.Controls.Add(new HtmlGenericControl("hr"));

                    }

                    // HISTORY
                    if (row["tripHist"].ToString() != "")
                    {
                        HtmlGenericControl divSecondSecond = new HtmlGenericControl("div");
                        divSecondSecond.Attributes.Add("class", "col-md-8 col-md-offset-1");


                        string[] tripHistArr = (row["tripHist"].ToString().Split(','));
                        for (var p = 1; p < tripHistArr.Length; p++)
                        {
                            StudentTripHistory histTrip = dao.getTripHistoryForHome(tripHistArr[p]);

                            HtmlGenericControl divHead = new HtmlGenericControl("div");
                            divHead.Attributes.Add("class", "historyDivs");
                            divHead.InnerHtml = "" +
                                "<b>Trip Name:</b>   " + histTrip.tripName + "<br/>" +
                                "<b>Trip Type:</b>   " + histTrip.tripType + "<br/>" +
                                "<b>Trip Location:</b>   " + histTrip.tripLocation + "<br/>" +
                                "<b>Period:</b>   " + Convert.ToDateTime(histTrip.tripStartDate).ToString("dd MMM yyyy") + "  -  " + Convert.ToDateTime(histTrip.tripEndDate).ToString("dd MMM yyyy") +
                                "";

                            divSecondSecond.Controls.Add(divHead);
                            divSecondSecond.Controls.Add(new HtmlGenericControl("p"));

                        }

                        HtmlGenericControl divSecond = new HtmlGenericControl("div");
                        divSecond.Attributes.Add("class", "row");
                        divSecond.InnerHtml = "<div class='col-md-3 shiftLeft'><h4><b>Trip History</b></h4></div>";

                        divSecond.Controls.Add(divSecondSecond);

                        homeForParent.Controls.Add(divSecond);
                        homeForParent.Controls.Add(new HtmlGenericControl("br"));
                        homeForParent.Controls.Add(new HtmlGenericControl("hr"));
                        homeForParent.Controls.Add(new HtmlGenericControl("br"));
                    }
                    else
                    {
                        HtmlGenericControl divSecond = new HtmlGenericControl("div");
                        divSecond.Attributes.Add("class", "row");
                        divSecond.InnerHtml = "" +
                            "<div class='col-md-3 shiftLeft'><h4><b>Trip History</b></h4></div>" +
                            "<div class='col-md-8 col-md-offset-1'>" +
                                "<p class='tripHistoryText'>No Trip History...</p>" +
                            "</div>";

                        homeForParent.Controls.Add(divSecond);
                        homeForParent.Controls.Add(new HtmlGenericControl("br"));
                        homeForParent.Controls.Add(new HtmlGenericControl("hr"));
                        homeForParent.Controls.Add(new HtmlGenericControl("br"));
                    }

                    // NOTES from STAFF
                    DataSet NotesTable = dao.getAllNotes(row["tripID"].ToString(), row["adminNo"].ToString());

                    int count = NotesTable.Tables["returnTable"].Rows.Count;

                    if (count != 0)
                    {
                        HtmlGenericControl divBox = new HtmlGenericControl("div");
                        divBox.Attributes.Add("class", "col-md-8 col-md-offset-1");

                        for (var m = 0; m < count; m++)
                        {
                            DataRow myRow = NotesTable.Tables["returnTable"].Rows[m];

                            HtmlGenericControl divHead = new HtmlGenericControl("div");
                            divHead.Attributes.Add("class", "notesDiv");
                            divHead.InnerHtml = "" +
                                "<b>Notes:</b>   " + myRow["notes"].ToString() + "<br/>" +
                                "<b>Date & Time:</b>   " + myRow["dateTime"].ToString() +
                                "";

                            divBox.Controls.Add(divHead);
                            divBox.Controls.Add(new HtmlGenericControl("p"));
                        }

                        HtmlGenericControl divRow = new HtmlGenericControl("div");
                        divRow.Attributes.Add("class", "row");
                        divRow.InnerHtml = "<div class='col-md-3 shiftLeft'><h4><b>Notes from Teacher</b></h4></div>";

                        divRow.Controls.Add(divBox);

                        homeForParent.Controls.Add(divRow);
                        homeForParent.Controls.Add(new HtmlGenericControl("br"));
                        homeForParent.Controls.Add(new HtmlGenericControl("hr"));
                        homeForParent.Controls.Add(new HtmlGenericControl("br"));
                    }
                    else
                    {
                        HtmlGenericControl divSecond = new HtmlGenericControl("div");
                        divSecond.Attributes.Add("class", "row");
                        divSecond.InnerHtml = "" +
                            "<div class='col-md-3 shiftLeft'><h4><b>Notes from Teacher</b></h4></div>" +
                            "<div class='col-md-8 col-md-offset-1'>" +
                                "<p class='tripHistoryText'>No Notes... Your child is safe!</p>" +
                            "</div>";

                        homeForParent.Controls.Add(divSecond);
                        homeForParent.Controls.Add(new HtmlGenericControl("br"));
                        homeForParent.Controls.Add(new HtmlGenericControl("hr"));
                        homeForParent.Controls.Add(new HtmlGenericControl("br"));
                    }
                    

                }
            }
        }


        // STAFF
        void createTableShowAllStudent(DataSet Data)
        {
            int count = Data.Tables["returnTable"].Rows.Count;

            if (count != 0)
            {
                staffInTripTable.InnerHtml = "";
            }
            

            // Loop all data
            for (var i = 0; i < count; i++)
            {
                DataRow row = Data.Tables["returnTable"].Rows[i];

                HomeInformation dao = new HomeInformation();

                // Retrieve the DateTime for Curfew
                string adminNo = row["adminNo"].ToString();
                string name = row["studentName"].ToString();
                string mobile = row["studentHP"].ToString();
                string tripId = row["tripID"].ToString();
                string dateTime = dao.retrieveCurfewTime(adminNo, tripId);
                if (dateTime == null)
                {
                    dateTime = "No Timing Yet";
                }

                // Put data in table
                staffInTripTable.InnerHtml += "" +
                    "<tr>" +
                        "<th><a class='linkToProfile' href='profile.aspx?adminno="+adminNo.ToUpper()+"'>"+adminNo+"</a></th>" +
                        "<th>"+name+"</th>" +
                        "<th>"+mobile+"</th>" +
                        "<th>"+dateTime+"</th>" +
                    "</tr>";

            }
        }

        // Sending Notes to Parent
        protected void sendNotesBtn_click(object sender, EventArgs e)
        {
            string adminNo = tbAdminNo.Text;
            string desc = tbDesc.Text;

            HomeInformation dao = new HomeInformation();
            int result = dao.sendNotesToParent(Session["username"].ToString(), adminNo, desc);

            noteToParentYay.Visible = false;
            noteToParentYay.InnerText = "";
            noteToParentErr.Visible = false;
            // Success
            if (result == 1)
            {
                noteToParentYay.Visible = true;
                noteToParentYay.InnerText = "Notes successfully sent to "+ adminNo +" parents!";
                noteToParentErr.Visible = false;
            }
            // Error
            else
            {
                noteToParentYay.Visible = false;
                noteToParentErr.Visible = true;
            }
            tbAdminNo.Text = "";
            tbDesc.Text = "";
        }
    }
}