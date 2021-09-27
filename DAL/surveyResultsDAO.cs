using iTravel.models;
using iTravel.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace iTravel.DAL
{
    public class surveyResultsDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;

        public int addSurvey(String tripId, String tripType, String tripName, String diploma, String PEMGroup, String adminNo, String fullName, String gender, String DOB, String contact, String address, String citizenship, String passportNo, String passportExp, 
            String waitList, String GPA, String CCA, String leadership, String offence, String PSEABalance, String fasopApply, String fasopHist, String buddy, String allergy, String medCondition, String medication)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;

            sqlStr.AppendLine("INSERT INTO surveyResults (tripId, tripType, tripName, diploma, PEMGroup, adminNo, fullName, gender, DOB, contact, address, citizenship, passportNo, ");
            sqlStr.AppendLine("passportExp, waitList, GPA, CCA, leadership, offenceCommitted, PSEABalance, fasopApply, fasopHist, buddy, allergy, medicalCondition, medication)");
            sqlStr.AppendLine("VALUES (@paraTripId, @paraTripType, @paraTripName, @paraDiploma, @paraPEMGroup, @paraAdminNo, @paraFullName, @paraGender, @paraDOB, @paraContact, @paraAddress, @paraCitizenship, @paraPassportNo, @paraPassportExp,");
            sqlStr.AppendLine("@paraWaitList, @paraGPA, @paraCCA, @paraLeadership, @paraOffenceCommitted, @paraPSEABalance, @paraFasopApply, @paraFasopHist, @paraBuddy, @paraAllergy, @paraMedicalCondition, @paraMedication)");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);
            sqlCmd.Parameters.AddWithValue("@paraTripId", tripId);
            sqlCmd.Parameters.AddWithValue("@paraTripType", tripType);
            sqlCmd.Parameters.AddWithValue("@paraTripName", tripName);
            sqlCmd.Parameters.AddWithValue("@paraDiploma", diploma);
            sqlCmd.Parameters.AddWithValue("@paraPEMGroup", PEMGroup);
            sqlCmd.Parameters.AddWithValue("@paraAdminNo", adminNo);
            sqlCmd.Parameters.AddWithValue("@paraFullName", fullName);
            sqlCmd.Parameters.AddWithValue("@paraGender", gender);
            sqlCmd.Parameters.AddWithValue("@paraDOB", DOB);
            sqlCmd.Parameters.AddWithValue("@paraContact", contact);
            sqlCmd.Parameters.AddWithValue("@paraAddress", address);
            sqlCmd.Parameters.AddWithValue("@paraCitizenship", citizenship);
            sqlCmd.Parameters.AddWithValue("@paraPassportNo", passportNo);
            sqlCmd.Parameters.AddWithValue("@paraPassportExp", passportExp);
            sqlCmd.Parameters.AddWithValue("@paraWaitList", waitList);
            sqlCmd.Parameters.AddWithValue("@paraGPA", GPA);
            sqlCmd.Parameters.AddWithValue("@paraCCA", CCA);
            sqlCmd.Parameters.AddWithValue("@paraLeadership", leadership);
            sqlCmd.Parameters.AddWithValue("@paraOffenceCommitted", offence);
            sqlCmd.Parameters.AddWithValue("@paraPSEABalance", PSEABalance);
            sqlCmd.Parameters.AddWithValue("@paraFasopApply", fasopApply);
            sqlCmd.Parameters.AddWithValue("@paraFasopHist", fasopHist);
            sqlCmd.Parameters.AddWithValue("@paraBuddy", buddy);
            sqlCmd.Parameters.AddWithValue("@paraAllergy", allergy);
            sqlCmd.Parameters.AddWithValue("@paraMedicalCondition", medCondition);
            sqlCmd.Parameters.AddWithValue("@paraMedication", medication);


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int updateSurvey ( String PEMNote ,String Id)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("UPDATE surveyResults SET PEMNote = @paraPEMNote  ");

            sqlStr.AppendLine("Where Id = @paraId ");

            SqlConnection myConn = new SqlConnection(DBConnect);
            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);
            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);
            sqlCmd.Parameters.AddWithValue("@paraPEMNote", PEMNote);
            sqlCmd.Parameters.AddWithValue("@paraId", Id);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }
        public List<surveyResults> getUpdatedSurvey()
        {
            DataSet ds = new DataSet();
            List<surveyResults> surveyResults = new List<surveyResults>();
            SqlConnection myConn = new SqlConnection(DBConnect);
            StringBuilder strSQL = new StringBuilder();

            SqlDataAdapter da = new SqlDataAdapter(strSQL.ToString(), myConn);

            strSQL.AppendLine("Select * from surveyResults");

            //strSQL.AppendLine("Where Id = @paraId ");
            //da.SelectCommand.Parameters.AddWithValue("@paraId", Id);

            da.Fill(ds, "SurveyTable");
            int count = ds.Tables["SurveyTable"].Rows.Count;
            if (count > 0)
            {
                foreach (DataRow row in ds.Tables["SurveyTable"].Rows)
                {
                    surveyResults obj = new surveyResults();
                    obj.surPEMnote = row["PEMNote"].ToString();
                    

                    surveyResults.Add(obj);
                }
            }

            return surveyResults;
        }
        public surveyResults retrieveInfo(string Id)
        {
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from surveyResults");
            sqlCommand.AppendLine("Where Id = @paraId");
            surveyResults retrieveTrip = new surveyResults();
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlStr = new SqlCommand(sqlCommand.ToString(), myConn);

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", Id);
            da.Fill(ds, "retrievesurveyTable");
            int rec_cnt = ds.Tables["retrievesurveyTable"].Rows.Count;

            DataRow row = ds.Tables["retrievesurveyTable"].Rows[0];
            retrieveTrip.surtripName = row["tripName"].ToString();
            retrieveTrip.surPEMnote = row["PEMnote"].ToString();
            retrieveTrip.surPEMGroup = row["PEMGroup"].ToString();
            retrieveTrip.surAddress = row["address"].ToString();
            retrieveTrip.surAdminNo = row["adminNo"].ToString();
            retrieveTrip.surAllergy = row["allergy"].ToString();
            retrieveTrip.surBuddy = row["buddy"].ToString();
            retrieveTrip.surCCA = row["CCA"].ToString();
            retrieveTrip.surCitizenship = row["citizenship"].ToString();
            retrieveTrip.surContact = row["contact"].ToString();
            retrieveTrip.surDiploma = row["diploma"].ToString();
            retrieveTrip.surDOB = row["DOB"].ToString();
            retrieveTrip.surFasopApply = row["fasopApply"].ToString();
            retrieveTrip.surFasopHist = row["fasopHist"].ToString();
            retrieveTrip.surFullName = row["fullName"].ToString();
            retrieveTrip.surGender = row["gender"].ToString();
            retrieveTrip.surGPA = row["GPA"].ToString();
            retrieveTrip.surLeadership = row["leadership"].ToString();
            retrieveTrip.surMedCondition = row["medicalcondition"].ToString();
            retrieveTrip.surMedication = row["medication"].ToString();
            retrieveTrip.surOffence = row["offenceCommitted"].ToString();
            retrieveTrip.surPassportExp = row["passportExp"].ToString();
            retrieveTrip.surPassportNo = row["passportNo"].ToString();
            retrieveTrip.surPSEABalance = row["PSEABalance"].ToString();
            retrieveTrip.surWaitList = row["waitList"].ToString();
            

            return retrieveTrip;
        }
        public surveyResults DeleteInfo(string Id)
        {
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Delete from surveyResults");
            sqlCommand.AppendLine("Where Id = @paraId");
            surveyResults retrieveTrip = new surveyResults();
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlStr = new SqlCommand(sqlCommand.ToString(), myConn);

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", Id);
            da.Fill(ds, "retrievesurveyTable");
            

         


            return retrieveTrip;
        }
        public createTrip getTripById(string Id)
        {
            // Step 2 : declare a timeDeposit, DataSet instance and dataTable instance 

            createTrip td = new createTrip();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();
            //
            // Step 3 :Create SQLcommand to select all columns from TDMaster by parameterised TD Account

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From surveyResults");
            sqlStr.AppendLine("where Id = @paraId");


            // Step 4 :Instantiate SqlConnection instance and SqlDataAdapter instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            // Step 5 :add value to parameter 

            da.SelectCommand.Parameters.AddWithValue("paraId", Id);

            // Step 6: fill dataset
            da.Fill(ds, "TableTD");

            // Step 7: Select command return a rows from TableTD contain the selected TD

            createTrip myTD = new createTrip();
            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {

                // Step 8 Set attribute of timeDeposit instance for the record in TableTD
                DataRow row = ds.Tables["TableTD"].Rows[0];
                myTD.tripId = Convert.ToInt32(row["Id"]);
                myTD.tripName = row["tripName"].ToString();
                myTD.staffNo = row["tripStaffNo"].ToString();
                myTD.location = row["tripLocation"].ToString();
                myTD.description = row["tripDesc"].ToString();
                myTD.startDate = row["tripStartDate"].ToString();
                myTD.EndDate = row["tripEndDate"].ToString();
                myTD.cost = Convert.ToDouble(row["tripCost"]);
                myTD.typeOfTrip = row["tripType"].ToString();

            }
            else
            {
                myTD = null;
            }

            return myTD;
        }


        public createTrip getTripByLocation(string tripLocation)
        {
            // Step 2 : declare a timeDeposit, DataSet instance and dataTable instance 

            createTrip td = new createTrip();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();
            //
            // Step 3 :Create SQLcommand to select all columns from TDMaster by parameterised TD Account

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From Trip");
            sqlStr.AppendLine("where tripLocation = @paratripLocation");


            // Step 4 :Instantiate SqlConnection instance and SqlDataAdapter instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            // Step 5 :add value to parameter 

            da.SelectCommand.Parameters.AddWithValue("paratripLocation", tripLocation);

            // Step 6: fill dataset
            da.Fill(ds, "TableTD");

            // Step 7: Select command return a rows from TableTD contain the selected TD

            createTrip myTD = new createTrip();
            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {

                // Step 8 Set attribute of timeDeposit instance for the record in TableTD
                DataRow row = ds.Tables["TableTD"].Rows[0];
                myTD.tripId = Convert.ToInt32(row["Id"]);
                myTD.tripName = row["tripName"].ToString();
                myTD.staffNo = row["tripStaffNo"].ToString();
                myTD.location = row["tripLocation"].ToString();
                myTD.description = row["tripDesc"].ToString();
                myTD.startDate = row["tripStartDate"].ToString();
                myTD.EndDate = row["tripEndDate"].ToString();
                myTD.cost = Convert.ToDouble(row["tripCost"]);
                myTD.typeOfTrip = row["tripType"].ToString();

            }
            else
            {
                myTD = null;
            }

            return myTD;
        }
    }
}