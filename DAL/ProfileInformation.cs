using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using iTravel.Models;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace iTravel.DAL
{
    public class ProfileInformation
    {
        // Database
        string DBConnect = ConfigurationManager.ConnectionStrings["ITravelDBConnectionString"].ConnectionString;

        public StudentInformation retrieveStudentInformation(string username)
        {
            DataSet ds = new DataSet();

            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT adminNo, tripStatus, studentGender, studentAddress, studentCCA, studentName, studentNationality, studentCourse, PEMGroup, studentHP, DOB, Bio, studentEmail, studentGPA, IC_No, passportNo, passportExpDate, applicationStatus, tripHist From Student");
            sqlStr.AppendLine("WHERE adminNo = @paraUsername");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraUsername", username);

            da.Fill(ds, "returnTable");

            DataRow row = ds.Tables["returnTable"].Rows[0];

            StudentInformation myModel = new StudentInformation();
            myModel.tripStatus = row["tripStatus"].ToString();
            myModel.adminNo = row["adminNo"].ToString();
            myModel.studentGender = row["studentGender"].ToString();
            myModel.studentAddress = row["studentAddress"].ToString();
            myModel.studentCCA = row["studentCCA"].ToString();
            myModel.studentName = row["studentName"].ToString();
            myModel.studentNationality = row["studentNationality"].ToString();
            myModel.studentCourse = row["studentCourse"].ToString();
            myModel.PEMGroup = row["PEMGroup"].ToString();
            myModel.studentHP = row["studentHP"].ToString();
            myModel.DOB = row["DOB"].ToString();
            myModel.Bio = row["Bio"].ToString();
            myModel.studentEmail = row["studentEmail"].ToString();
            myModel.studentGPA = row["studentGPA"].ToString();
            myModel.IC_No = row["IC_No"].ToString();
            myModel.passportNo = row["passportNo"].ToString();
            myModel.passportExpDate = row["passportExpDate"].ToString();
            myModel.applicationStatus = row["applicationStatus"].ToString();
            myModel.tripHist = row["tripHist"].ToString();

            return myModel;
        }

        public void updateStudentProfile(string mobile, string bio, string username)
        {
            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("UPDATE Student");
            sqlStr.AppendLine("SET studentHP = @parastudentHP, Bio = @paraBio");
            sqlStr.AppendLine("WHERE adminNo = @paraadminNo");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCommand = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCommand.Parameters.AddWithValue("@parastudentHP", mobile);
            sqlCommand.Parameters.AddWithValue("@paraBio", bio);
            sqlCommand.Parameters.AddWithValue("@paraadminNo", username);

            myConn.Open();
            int result = 0;
            result = sqlCommand.ExecuteNonQuery();
            myConn.Close();
        }

        public void updateStudentPersonal(string passNo, string passExp, string username)
        {
            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("UPDATE Student");
            sqlStr.AppendLine("SET passportNo = @parapassportNo, passportExpDate = @parapassportExpDate");
            sqlStr.AppendLine("WHERE adminNo = @paraadminNo");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCommand = new SqlCommand(sqlStr.ToString(), myConn);
            
            sqlCommand.Parameters.AddWithValue("@parapassportNo", passNo);
            sqlCommand.Parameters.AddWithValue("@parapassportExpDate", passExp);
            sqlCommand.Parameters.AddWithValue("@paraadminNo", username);

            myConn.Open();
            int result = 0;
            result = sqlCommand.ExecuteNonQuery();
            myConn.Close();
        }

        public int updateStudentPassword(string pass, string newPass, string username)
        {
            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("UPDATE Student");
            sqlStr.AppendLine("SET studentPass = @parastudentNewPass");
            sqlStr.AppendLine("WHERE adminNo = @paraadminNo AND studentPass = @parastudentPass");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCommand = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCommand.Parameters.AddWithValue("@parastudentNewPass", newPass);
            sqlCommand.Parameters.AddWithValue("@parastudentPass", pass);
            sqlCommand.Parameters.AddWithValue("@paraadminNo", username);

            myConn.Open();
            int result = 0;
            result = sqlCommand.ExecuteNonQuery();
            myConn.Close();
            return result;
        }

        public StudentTripHistory getTripHistory(string tripId)
        {
            DataSet ds = new DataSet();

            // SQL Command TO GET TRIP HISTORY OF STUDENT
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT tripName, tripType, tripLocation, tripStartDate, tripEndDate FROM Trip");
            sqlStr.AppendLine("WHERE Id = @paraTripId");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraTripId", tripId);

            da.Fill(ds, "returnTable");

            DataRow row = ds.Tables["returnTable"].Rows[0];

            StudentTripHistory myModel = new StudentTripHistory();
            myModel.tripName = row["tripName"].ToString();
            myModel.tripType = row["tripType"].ToString();
            myModel.tripLocation = row["tripLocation"].ToString();
            myModel.tripStartDate = row["tripStartDate"].ToString();
            myModel.tripEndDate = row["tripEndDate"].ToString();

            return myModel;
        }

        // For Trip Status Only
        // Pending Registration
        public void setTripStatusTo2(string username)
        {
            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("UPDATE Student");
            sqlStr.AppendLine("SET tripStatus = 2");
            sqlStr.AppendLine("WHERE adminNo = @paraadminNo");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCommand = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCommand.Parameters.AddWithValue("@paraadminNo", username);

            myConn.Open();
            int result = 0;
            result = sqlCommand.ExecuteNonQuery();
            myConn.Close();
        }

        // Interview Time
        public void setTripStatusTo3(string username)
        {
            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("UPDATE Student");
            sqlStr.AppendLine("SET tripStatus = 3");
            sqlStr.AppendLine("WHERE adminNo = @paraadminNo");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCommand = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCommand.Parameters.AddWithValue("@paraadminNo", username);

            myConn.Open();
            int result = 0;
            result = sqlCommand.ExecuteNonQuery();
            myConn.Close();
        }

        // Payment Time
        public void setTripStatusTo4(string username)
        {
            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("UPDATE Student");
            sqlStr.AppendLine("SET tripStatus = 4");
            sqlStr.AppendLine("WHERE adminNo = @paraadminNo");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCommand = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCommand.Parameters.AddWithValue("@paraadminNo", username);

            myConn.Open();
            int result = 0;
            result = sqlCommand.ExecuteNonQuery();
            myConn.Close();
        }

        // Waiting for Trip
        public void setTripStatusTo5(string username)
        {
            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("UPDATE Student");
            sqlStr.AppendLine("SET tripStatus = 5");
            sqlStr.AppendLine("WHERE adminNo = @paraadminNo");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCommand = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCommand.Parameters.AddWithValue("@paraadminNo", username);

            myConn.Open();
            int result = 0;
            result = sqlCommand.ExecuteNonQuery();
            myConn.Close();
        }

        // Currently on Trip
        public void setTripStatusTo6(string username)
        {
            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("UPDATE Student");
            sqlStr.AppendLine("SET tripStatus = 6");
            sqlStr.AppendLine("WHERE adminNo = @paraadminNo");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCommand = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCommand.Parameters.AddWithValue("@paraadminNo", username);

            myConn.Open();
            int result = 0;
            result = sqlCommand.ExecuteNonQuery();
            myConn.Close();
        }

        // Add tripID for Student Table
        public void setTripID(string username, string id)
        {
            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("UPDATE Student");
            sqlStr.AppendLine("SET tripID = @paraID");
            sqlStr.AppendLine("WHERE adminNo = @paraadminNo");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCommand = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCommand.Parameters.AddWithValue("@paraID", id);
            sqlCommand.Parameters.AddWithValue("@paraadminNo", username);

            myConn.Open();
            int result = 0;
            result = sqlCommand.ExecuteNonQuery();
            myConn.Close();
        }

        // Phil's
        public int updateAppStatus(String adminNo)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("UPDATE Student SET applicationStatus = '2' ");

            sqlStr.AppendLine("Where adminNo = @paraAdminNo ");

            SqlConnection myConn = new SqlConnection(DBConnect);
            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);


            sqlCmd.Parameters.AddWithValue("@paraAdminNo", adminNo);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }
    }
}