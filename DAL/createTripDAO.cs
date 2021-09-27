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
    public class CreateTripDAO
    
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;
        public int InsertTrip(String TripName, String StaffNo, String Location, String Description, Double Cost, DateTime StartDate, DateTime EndDate, String TypeOfTrip, String TripSummary, String TripAirline, String TripItinerary, String TripSelection, String TripIMG) 
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;

            sqlStr.AppendLine("INSERT INTO Trip(tripName, tripStaffNo, tripLocation, tripDesc, tripCost, tripStartDate, tripEndDate, tripType, tripSummary, tripAirline, tripItinerary, tripSelection, tripIMG)"); //tripIMG
            sqlStr.AppendLine("VALUES (@paraTripName, @paraStaffNo,@paraLocation, @paraDescription, @paraCost, @paraStartDate, @paraEndDate, @paraTypeOfTrip, @paraTripSummary, @paraTripAirline, @paraTripItinerary, @paraTripSelection,@paraTripIMG)");
            //@paraTripIMG
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraTripName", TripName);
            sqlCmd.Parameters.AddWithValue("@paraStaffNo", StaffNo);
            sqlCmd.Parameters.AddWithValue("@paraLocation", Location);
            sqlCmd.Parameters.AddWithValue("@paraDescription", Description);
            sqlCmd.Parameters.AddWithValue("@paraCost", Cost);
            sqlCmd.Parameters.AddWithValue("@paraStartDate", StartDate);
            sqlCmd.Parameters.AddWithValue("@paraEndDate", EndDate);
            sqlCmd.Parameters.AddWithValue("@paraTypeOfTrip", TypeOfTrip);
            sqlCmd.Parameters.AddWithValue("@paraTripSummary", TripSummary);    
            sqlCmd.Parameters.AddWithValue("@paraTripAirline", TripAirline);    
            sqlCmd.Parameters.AddWithValue("@paraTripItinerary", TripItinerary);    
            sqlCmd.Parameters.AddWithValue("@paraTripSelection", TripSelection);

            sqlCmd.Parameters.AddWithValue("@paraTripIMG", TripIMG);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }



        public int updateTrip(String TripName, String StaffNo, String Location, String Description, Double Cost, DateTime StartDate, DateTime EndDate, String TypeOfTrip, String Id, String TripSummary, String TripAirline, String TripItinerary, String TripSelection, String TripIMG)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("UPDATE Trip SET tripName = @paraTripName,  tripStaffNo = @paraStaffNo,  tripLocation = @paraLocation,  tripDesc = @paraDescription,  tripCost = @paraCost,   tripStartDate = @paraStartDate,   tripEndDate = @paraEndDate,   tripType = @paraTypeOfTrip, tripSummary = @paraTripSummary, tripAirline = @paraTripAirline, tripItinerary = @paraTripItinerary, tripSelection = @paraTripSelection,  tripIMG = @paraTripIMG ");

            sqlStr.AppendLine("Where Id = @paraId ");

            SqlConnection myConn = new SqlConnection(DBConnect);
            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paraTripName", TripName);
            sqlCmd.Parameters.AddWithValue("@paraStaffNo", StaffNo);
            sqlCmd.Parameters.AddWithValue("@paraLocation", Location);
            sqlCmd.Parameters.AddWithValue("@paraDescription", Description);
            sqlCmd.Parameters.AddWithValue("@paraCost", Cost);
            sqlCmd.Parameters.AddWithValue("@paraStartDate", StartDate);
            sqlCmd.Parameters.AddWithValue("@paraEndDate", EndDate);
            sqlCmd.Parameters.AddWithValue("@paraTypeOfTrip", TypeOfTrip);
            sqlCmd.Parameters.AddWithValue("@paraId", Id);
            sqlCmd.Parameters.AddWithValue("@paraTripSummary", TripSummary);
            sqlCmd.Parameters.AddWithValue("@paraTripAirline", TripAirline);
            sqlCmd.Parameters.AddWithValue("@paraTripItinerary", TripItinerary);
            sqlCmd.Parameters.AddWithValue("@paraTripSelection", TripSelection);
            sqlCmd.Parameters.AddWithValue("@paraTripIMG", TripIMG);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }

        public int updateStudentList(String tripName, String tripStudentList)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("UPDATE Trip SET tripStudentList = @paratripStudentList");

            sqlStr.AppendLine("Where tripName = @paratripName ");

            SqlConnection myConn = new SqlConnection(DBConnect);
            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@paratripName", tripName);
            sqlCmd.Parameters.AddWithValue("@paratripStudentList", tripStudentList);


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();
            return result;
        }

        public List<createTrip> getUpdatedTrip()
        {
            DataSet ds = new DataSet();
            List<createTrip> tripList = new List<createTrip>();
            SqlConnection myConn = new SqlConnection(DBConnect);
            StringBuilder strSQL = new StringBuilder();

            SqlDataAdapter da = new SqlDataAdapter(strSQL.ToString(), myConn);

            strSQL.AppendLine("Select * from Trip");

            //strSQL.AppendLine("Where Id = @paraId ");
            //da.SelectCommand.Parameters.AddWithValue("@paraId", Id);

            da.Fill(ds, "TripTable");
            int count = ds.Tables["TripTable"].Rows.Count;
            if (count > 0)
            {
                foreach (DataRow row in ds.Tables["TripTable"].Rows)
                {
                    createTrip obj = new createTrip();
                    obj.tripName = row["tripName"].ToString();
                    obj.staffNo = row["tripStaffNo"].ToString();
                    obj.location = row["tripLocation"].ToString();
                    obj.description = row["tripDesc"].ToString();
                    obj.startDate = row["tripStartDate"].ToString();
                    obj.EndDate = row["tripEndDate"].ToString();
                    obj.cost = Convert.ToDouble(row["tripCost"].ToString());
                    obj.typeOfTrip = row["tripType"].ToString();
                    obj.tripSummary = row["tripSummary"].ToString();
                    obj.tripAirline = row["tripAirline"].ToString();
                    obj.tripItinerary = row["tripItinerary"].ToString();
                    obj.tripSelection = row["tripSelection"].ToString();
                    obj.tripIMG = row["tripIMG"].ToString();

                    tripList.Add(obj);
                }
            }

            return tripList;
        }

       
        public createTrip retrieveInfo(string retrieveId)
        {
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from Trip");
            sqlCommand.AppendLine("Where Id = @paraRetrieveId");
            createTrip retrieveTripId = new createTrip();
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlStr = new SqlCommand(sqlCommand.ToString(), myConn);

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraRetrieveId", retrieveId);
            da.Fill(ds, "retrieveTripTable");
            //int rec_cnt = ds.Tables["retrieveTripTable"].Rows.Count;

            DataRow row = ds.Tables["retrieveTripTable"].Rows[0];
            retrieveTripId.tripName = row["tripName"].ToString();
            retrieveTripId.staffNo = row["tripStaffNo"].ToString();
            retrieveTripId.location = row["tripLocation"].ToString();
            retrieveTripId.description = row["tripDesc"].ToString();
            retrieveTripId.startDate = row["tripStartDate"].ToString();
            retrieveTripId.EndDate = row["tripEndDate"].ToString();
            retrieveTripId.cost = Convert.ToDouble(row["tripCost"]);
            retrieveTripId.typeOfTrip = row["tripType"].ToString();
            retrieveTripId.tripSummary = row["tripSummary"].ToString();
            retrieveTripId.tripAirline = row["tripAirline"].ToString();
            retrieveTripId.tripItinerary = row["tripItinerary"].ToString();
            retrieveTripId.tripSelection = row["tripSelection"].ToString();
            retrieveTripId.tripId = Convert.ToInt32(row["Id"].ToString());
            retrieveTripId.tripIMG = row["tripIMG"].ToString();
            return retrieveTripId;
        }


        public createTrip retrievestudlist(string tripName)
        {
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from Trip");
            sqlCommand.AppendLine("Where tripName = @paratripName");
            createTrip retrieveTrip = new createTrip();
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlStr = new SqlCommand(sqlCommand.ToString(), myConn);

            SqlDataAdapter da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("@paratripName", tripName);
            da.Fill(ds, "retrieveTripTable");
            int rec_cnt = ds.Tables["retrieveTripTable"].Rows.Count;

            DataRow row = ds.Tables["retrieveTripTable"].Rows[0];
            retrieveTrip.tripStudentList = row["tripStudentList"].ToString();

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
            sqlStr.AppendLine("SELECT * From Trip");
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
                myTD.tripSummary = row["tripSummary"].ToString();
                myTD.tripAirline = row["tripAirline"].ToString();
                myTD.tripItinerary = row["tripItinerary"].ToString();
                myTD.tripSelection = row["tripSelection"].ToString();
                myTD.tripIMG = row["tripIMG"].ToString(); // for image

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
                myTD.tripSummary = row["tripSummary"].ToString();
                myTD.tripAirline = row["tripAirline"].ToString();
                myTD.tripItinerary = row["tripItinerary"].ToString();
                myTD.tripSelection = row["tripSelection"].ToString();
                myTD.tripIMG = row["tripIMG"].ToString(); //for image

            }
            else
            {
                myTD = null;
            }

            return myTD;
        }
    }
}