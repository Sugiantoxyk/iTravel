using iTravel.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace iTravel.DAL
{
    public class paymentDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;
        public int InsertPayment(String firstName, String lastName, String email, double creditCardNumber, String expiryDate, double ccv, String cardHolderName,String hasPaid,String adminNo)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;

            sqlStr.AppendLine("INSERT INTO PaymentDetails(firstName, lastName, email, creditCardNumber, expiryDate, ccv, cardHolderName,hasPaid,adminNo)"); 
            sqlStr.AppendLine("VALUES (@parafirstName, @paralastName, @paraemail, @paracreditCardNumber, @paraexpiryDate, @paraccv, @paracardHolderName, @parahasPaid,@paraadminNo)");
            
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@parafirstName", firstName);
            sqlCmd.Parameters.AddWithValue("@paralastName", lastName);
            sqlCmd.Parameters.AddWithValue("@paraemail", email);
            sqlCmd.Parameters.AddWithValue("@paracreditCardNumber", creditCardNumber);
            sqlCmd.Parameters.AddWithValue("@paraexpiryDate", expiryDate);
            sqlCmd.Parameters.AddWithValue("@paraccv", ccv);
            sqlCmd.Parameters.AddWithValue("@paracardHolderName", cardHolderName);
            sqlCmd.Parameters.AddWithValue("@parahasPaid", hasPaid);
            sqlCmd.Parameters.AddWithValue("@paraadminNo", adminNo);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }

        //public Payment retrievePayment(string retrieveAdmin)
        //{
            
        //    DataSet ds = new DataSet();
        //    StringBuilder sqlCommand = new StringBuilder();
            
        //    sqlCommand.AppendLine("Select * from PaymentDetails P inner Join Student U on U.adminNo = P.adminNo");
        //    sqlCommand.AppendLine("where adminNo = @paraRetrievePayment");
        //    Payment retrievePayment = new Payment();
        //    SqlConnection myConn = new SqlConnection(DBConnect);
        //    SqlCommand sqlStr = new SqlCommand(sqlCommand.ToString(), myConn);

        //    SqlDataAdapter da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
        //    da.SelectCommand.Parameters.AddWithValue("@paraRetrievePayment", retrieveAdmin);

        //    da.Fill(ds, "retrievePaymentTable");
        //    DataRow row = ds.Tables["retrievePaymentTable"].Rows[0];
        //    retrievePayment.fname = row["firstName"].ToString();
        //    retrievePayment.lname = row["lastName"].ToString();
        //    retrievePayment.email = row["email"].ToString();
        //    retrievePayment.creditCardNUmber = Convert.ToDouble(row["creditCardNumber"].ToString());
        //    retrievePayment.expiryDate = row["expiryDate"].ToString();
        //    retrievePayment.ccv = Convert.ToDouble(row["ccv"].ToString());
        //    retrievePayment.cardHolderName = row["cardHolderName"].ToString();
        //    retrievePayment.adminNo = row["adminNo"].ToString();
        //    retrievePayment.hasPaid = row["hasPaid"].ToString();
        //    return retrievePayment;
            
        //}

       
    }
}