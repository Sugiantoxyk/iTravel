using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTravel.DAL;
using iTravel.Models;
using System.Drawing;
using System.Text;
using System.Data;
using System.Web.UI.HtmlControls;

namespace iTravel.Views
{
    public partial class profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string who = Session["whoWho"].ToString();
                }
                catch (NullReferenceException)
                {
                    Response.Redirect("login.aspx");
                }

                // Check user or see user
                try
                {
                    if (Request.QueryString["adminno"].ToString().ToUpper() != Session["username"].ToString().ToUpper())
                    {
                        setValueToSeeUser();
                    }
                    else
                    {
                        Response.Redirect("profile.aspx");
                    }
                }
                // OWnself
                catch (NullReferenceException)
                {
                    // Only Student
                    if (Session["whoWho"].ToString() == "Student")
                    {
                        setValueBack();
                    }
                }
            }
        }

        // Setting Textbox to target User
        protected void setValueToSeeUser()
        {
            // Setup UI
            string seeAdminNo = Request.QueryString["adminno"].ToString();
            tripStatusDiv.Visible = false;
            editProfileBtn.Visible = false;
            personalInfoDiv.Visible = false;
            changePassDiv.Visible = false;
            hello1.Visible = false;
            hello2.Visible = false;
            hello3.Visible = false;

            ProfileInformation dao = new ProfileInformation();
            StudentInformation myModel = dao.retrieveStudentInformation(seeAdminNo);

            profileMainName.InnerText = myModel.studentName;

            profileName.Text = myModel.studentName;
            profileGender.Text = myModel.studentGender;
            profileNationality.Text = myModel.studentNationality;
            profileCourse.Text = myModel.studentCourse;
            profilePEMGrp.Text = myModel.PEMGroup;
            profileMobile.Text = myModel.studentHP;
            profileDOB.Text = myModel.DOB;
            profileBio.Text = myModel.Bio;

            // For History
            if (myModel.tripHist != "")
            {
                string[] tripHistArr = (myModel.tripHist.Split(','));
                for (var p = 1; p < tripHistArr.Length; p++)
                {
                    StudentTripHistory histTrip = dao.getTripHistory(tripHistArr[p]);

                    HtmlGenericControl divHead = new HtmlGenericControl("div");
                    divHead.Attributes.Add("class", "historyDivs");
                    divHead.InnerHtml = "" +
                        "<b>Trip Name:</b>   " + histTrip.tripName + "<br/>" +
                        "<b>Trip Type:</b>   " + histTrip.tripType + "<br/>" +
                        "<b>Trip Location:</b>   " + histTrip.tripLocation + "<br/>" +
                        "<b>Period:</b>   " + Convert.ToDateTime(histTrip.tripStartDate).ToString("dd MMM yyyy") + "  -  " + Convert.ToDateTime(histTrip.tripEndDate).ToString("dd MMM yyyy") +
                        "";

                    historyInfo.Controls.Add(divHead);
                    historyInfo.Controls.Add(new HtmlGenericControl("p"));
                }
            }
            else
            {
                historyInfo.InnerHtml = "<br /><p class='historyText'>No Trip History...</p>";
            }
        }


        // Setting Textbox to original value
        protected void setValueBack()
        {
            ProfileInformation dao = new ProfileInformation();
            if (Session["whoWho"].ToString() == "Student")
            {
                StudentInformation myModel = dao.retrieveStudentInformation(Session["username"].ToString());
                int statusNumber = Convert.ToInt16(myModel.tripStatus);
                if (statusNumber >= 2)
                {
                    statusText.InnerText = "Pending registration";
                    statusBtn.Visible = false;
                    status2.BgColor = "Orange";
                    if (statusNumber >= 3)
                    {
                        statusText.InnerText = "Interview";
                        statusBtn.Visible = false;
                        status3.BgColor = "Yellow";
                        if (statusNumber >= 4)
                        {
                            statusText.InnerText = "Payment";
                            statusBtn.Visible = true;
                            statusBtn.InnerText = "Proceed Payment";
                            statusBtn.Attributes.Add("href", "studentpayment.aspx");
                            status4.BgColor = "Lime";
                            if (statusNumber >= 5)
                            {
                                statusText.InnerText = "Waiting for trip";
                                statusBtn.Visible = false;
                                status5.BgColor = "Teal";
                                if (statusNumber >= 6)
                                {
                                    statusText.InnerText = "Currently on trip";
                                    statusBtn.Visible = true;
                                    statusBtn.InnerText = "Write Blog";
                                    statusBtn.Attributes.Add("href", "BlogHome.aspx");
                                    status6.BgColor = "Aqua";
                                }
                            }
                        }
                    }
                }

                
                profileMainName.InnerText = myModel.studentName;
                
                profileName.Text = myModel.studentName;
                profileGender.Text = myModel.studentGender;
                profileNationality.Text = myModel.studentNationality;
                profileCourse.Text = myModel.studentCourse;
                profilePEMGrp.Text = myModel.PEMGroup;
                profileMobile.Text = myModel.studentHP;
                profileDOB.Text = myModel.DOB;
                profileBio.Text = myModel.Bio;

                profileAdminNo.Text = myModel.adminNo;
                personalEmail.Text = myModel.studentEmail;
                personalGPA.Text = myModel.studentGPA;
                personalIC.Text = myModel.IC_No;
                personalPassNum.Text = myModel.passportNo;
                PersonalPassExp.Text = myModel.passportExpDate;
                
                profileMobile.Attributes.Add("Disabled", "disabled");
                profileBio.Attributes.Add("Disabled", "disabled");
                profileMobile.BorderColor = Color.Empty;
                profileBio.BorderColor = Color.Empty;
                personalPassNum.Attributes.Add("Disabled", "disabled");
                PersonalPassExp.Attributes.Add("Disabled", "disabled");
                personalPassNum.BorderColor = Color.Empty;
                PersonalPassExp.BorderColor = Color.Empty;

                editProfileBtn.Visible = true;
                cancelProfileBtn.Visible = false;
                updateProfileBtn.Visible = false;
                editPersonalBtn.Visible = true;
                cancelPersonalBtn.Visible = false;
                updatePersonalBtn.Visible = false;

                // For password changing
                currentPasswordInput.Attributes.Remove("value");
                newPasswordInput.Attributes.Remove("value");
                confirmNewPasswordInput.Attributes.Remove("value");
                changePassSuccess.Attributes.Add("hidden", "hidden");
                changePassError1.Attributes.Add("hidden", "hidden");
                changePassError2.Attributes.Add("hidden", "hidden");
                changePasswordCont.Visible = false;
                changePasswordBtn.Visible = true;
                
                // For History
                if (myModel.tripHist != "")
                {
                    string[] tripHistArr = (myModel.tripHist.Split(','));
                    for (var p = 1; p < tripHistArr.Length; p++)
                    {
                        StudentTripHistory histTrip = dao.getTripHistory(tripHistArr[p]);

                        HtmlGenericControl divHead = new HtmlGenericControl("div");
                        divHead.Attributes.Add("class", "historyDivs");
                        divHead.InnerHtml = "" +
                            "<b>Trip Name:</b>   " + histTrip.tripName + "<br/>" +
                            "<b>Trip Type:</b>   " + histTrip.tripType + "<br/>" +
                            "<b>Trip Location:</b>   " + histTrip.tripLocation + "<br/>" +
                            "<b>Period:</b>   " + Convert.ToDateTime(histTrip.tripStartDate).ToString("dd MMM yyyy") + "  -  " + Convert.ToDateTime(histTrip.tripEndDate).ToString("dd MMM yyyy") +
                            "";

                        historyInfo.Controls.Add(divHead);
                        historyInfo.Controls.Add(new HtmlGenericControl("p"));
                    }
                }
                else
                {
                    historyInfo.InnerHtml = "<br /><p class='historyText'>No Trip History...</p>";
                }
            }
        }

        // Edit Buttons
        protected void editProfileBtn_Click(object sender, EventArgs e)
        {
            // Set the Personal Information to Edit
            setValueBack();
            
            profileMobile.Attributes.Remove("Disabled");
            profileBio.Attributes.Remove("Disabled");
            profileMobile.BorderColor = Color.CornflowerBlue;
            profileBio.BorderColor = Color.CornflowerBlue;

            editProfileBtn.Visible = false;
            cancelProfileBtn.Visible = true;
            updateProfileBtn.Visible = true;
        }
        protected void editPersonalBtn_Click(object sender, EventArgs e)
        {
            // Set the Profile to Edit
            setValueBack();

            personalPassNum.Attributes.Remove("Disabled");
            PersonalPassExp.Attributes.Remove("Disabled");
            personalPassNum.BorderColor = Color.CornflowerBlue;
            PersonalPassExp.BorderColor = Color.CornflowerBlue;

            editPersonalBtn.Visible = false;
            cancelPersonalBtn.Visible = true;
            updatePersonalBtn.Visible = true;
        }

        // Cancel Buttons
        protected void cancelProfileBtn_Click(object sender, EventArgs e)
        {
            setValueBack();
        }
        protected void cancelPersonalBtn_Click(object sender, EventArgs e)
        {
            setValueBack();
        }

        // Update Buttons
        protected void updateProfileBtn_Click(object sender, EventArgs e)
        {
            ProfileInformation dao = new ProfileInformation();
            dao.updateStudentProfile(profileMobile.Text, profileBio.Text, Session["username"].ToString());
            setValueBack();
            Response.Redirect(Request.RawUrl);
        }
        protected void updatePersonalBtn_Click(object sender, EventArgs e)
        {
            ProfileInformation dao = new ProfileInformation();
            dao.updateStudentPersonal(personalPassNum.Text, PersonalPassExp.Text, Session["username"].ToString());
            setValueBack();
            Response.Redirect(Request.RawUrl);
        }

        /* Change Password */
        protected void changePasswordBtn_Click(object sender, EventArgs e)
        {
            setValueBack();

            changePasswordBtn.Visible = false;
            changePasswordCont.Visible = true;
        }
        protected void cancelPasswordBtn_Click(object sender, EventArgs e)
        {
            setValueBack();
        }
        protected void updatePasswordBtn_Click(object sender, EventArgs e)
        {
            // Set no error shown
            changePassSuccess.Attributes.Add("hidden", "hidden");
            changePassError1.Attributes.Add("hidden", "hidden");
            changePassError2.Attributes.Add("hidden", "hidden");

            // Set the password again
            currentPasswordInput.Attributes.Add("value", currentPasswordInput.Text);
            newPasswordInput.Attributes.Add("value", newPasswordInput.Text);
            confirmNewPasswordInput.Attributes.Add("value", confirmNewPasswordInput.Text);

            if (currentPasswordInput.Text == "" || newPasswordInput.Text == "" || confirmNewPasswordInput.Text == "")
            {
                changePassError1.InnerText = "Make sure all inputs are filled.";
                changePassError1.Attributes.Remove("hidden");
            } else if (newPasswordInput.Text != confirmNewPasswordInput.Text)
            {
                changePassError2.InnerText = "Passwords are different.";
                changePassError2.Attributes.Remove("hidden");
            } else
            {
                // Update password
                ProfileInformation dao = new ProfileInformation();
                string encryptCurrPass = encryption(currentPasswordInput.Text);
                string encryptNewPass = encryption(newPasswordInput.Text);
                int result = dao.updateStudentPassword(encryptCurrPass, encryptNewPass, Session["username"].ToString());
                if (result == 0)
                {
                    changePassError1.InnerText = "Current password is wrong.";
                    changePassError1.Attributes.Remove("hidden");
                }
                else
                {
                    currentPasswordInput.Attributes.Remove("value");
                    newPasswordInput.Attributes.Remove("value");
                    confirmNewPasswordInput.Attributes.Remove("value");
                    changePassSuccess.InnerText = "Password change successfully.";
                    changePassSuccess.Attributes.Remove("hidden");
                }
            }
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