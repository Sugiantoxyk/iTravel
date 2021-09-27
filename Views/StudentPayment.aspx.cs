using iTravel.DAL;
using iTravel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iTravel.Views
{
    public partial class StudentPayment : System.Web.UI.Page
    {
        int increment = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    // Only for Student to make payment

                    if (Session["whoWho"].ToString() != "Student")
                    {
                        
                        
                        Response.Redirect("home.aspx");
                    }
                }
                catch (NullReferenceException)
                {
                    Response.Redirect("login.aspx");
                }
            }
            string DBConnect = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;



            tbAdminNo.Text = Session["username"].ToString();
            DataSet ds = new DataSet();
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select P.adminNo,P.hasPaid from PaymentDetails P inner Join Student U on U.adminNo = P.adminNo");
            Payment retrievePayment = new Payment();
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlStr = new SqlCommand(sqlCommand.ToString(), myConn);

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.Fill(ds, "retrievePaymentTable");
            int count = ds.Tables["retrievePaymentTable"].Rows.Count;
            if (count != 0)
            {
                DataRow row = ds.Tables["retrievePaymentTable"].Rows[0];
                //retrievePayment.fname = row["firstName"].ToString();
                //retrievePayment.lname = row["lastName"].ToString();
                //retrievePayment.email = row["email"].ToString();
                //retrievePayment.creditCardNUmber = Convert.ToDouble(row["creditCardNumber"].ToString());
                //retrievePayment.expiryDate = row["expiryDate"].ToString();
                //retrievePayment.ccv = Convert.ToDouble(row["ccv"].ToString());
                //retrievePayment.cardHolderName = row["cardHolderName"].ToString();
                retrievePayment.adminNo = row["adminNo"].ToString();
                retrievePayment.hasPaid = row["hasPaid"].ToString();

                if (tbAdminNo.Text == retrievePayment.adminNo)
                {
                    if (retrievePayment.hasPaid == "Yes")
                    {
                        lbText.Text = "You have paid";
                        tbFirstName.Visible = false;
                        tbLastName.Visible = false;
                        tbCreditCardNumber.Visible = false;
                        tbExpiryDate.Visible = false;
                        tbCCV.Visible = false;
                        tbCardHolderName.Visible = false;
                        tbAdminNo.Visible = false;
                        tbEmail.Visible = false;


                        lbFirstName.Visible = false;
                        lbLastName.Visible = false;
                        lbCreditCardNumber.Visible = false;
                        lbExpiryDate.Visible = false;
                        lbCCV.Visible = false;
                        lbCardholderName.Visible = false;
                        lbAdminNumber.Visible = false;
                        lbEmail.Visible = false;

                        lbMsg.Visible = true;
                        Button1.Visible = true;
                        lbText.Visible = true;

                        btnCancel.Visible = false;
                        btnSubmit.Visible = false;
                    }
                }
                
            }
            else
            {

            }
            
            

            
            
            




        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            ProfileInformation profile = new ProfileInformation();
            profile.setTripStatusTo5(Session["username"].ToString());

            increment += 1;
            String firstName = tbFirstName.Text;
            String lastName = tbLastName.Text;
            String email = tbEmail.Text;
            double creditCardNumber = Convert.ToDouble(tbCreditCardNumber.Text);
            String expiryDate = tbExpiryDate.Text;
            double ccv = Convert.ToDouble(tbCCV.Text);
            String cardholderName = tbCardHolderName.Text;
            String hasPaid = "Yes";
            String adminNo = tbAdminNo.Text;
            Session["test"] = "4";
            paymentDAO dao = new paymentDAO();
            if(lbMsg.Text == "You have paid")
            {
               
                Response.Redirect("home.aspx");
            }
            else
            {
                int result = dao.InsertPayment(firstName, lastName, email, creditCardNumber, expiryDate, ccv, cardholderName, hasPaid, adminNo);
                lbText.Text = "Sucessfully Paid";
                tbFirstName.Visible = false;
                tbLastName.Visible = false;
                tbCreditCardNumber.Visible = false;
                tbExpiryDate.Visible = false;
                tbCCV.Visible = false;
                tbCardHolderName.Visible = false;
                tbAdminNo.Visible = false;
                tbEmail.Visible = false;


                lbFirstName.Visible = false;
                lbLastName.Visible = false;
                lbCreditCardNumber.Visible = false;
                lbExpiryDate.Visible = false;
                lbCCV.Visible = false;
                lbCardholderName.Visible = false;
                lbAdminNumber.Visible = false;
                lbEmail.Visible = false;
                btnCancel.Visible = false;
                btnSubmit.Visible = false;
                lbBack.Visible = true;
                lbText.Visible = true;

            }








            //Response.Redirect("ViewTrip.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");

        }

        protected void lbBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");

        }
    }
}