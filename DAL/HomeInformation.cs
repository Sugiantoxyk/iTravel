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
    public class HomeInformation
    {
        // Database
        string DBConnect = ConfigurationManager.ConnectionStrings["ITravelDBConnectionString"].ConnectionString;

        // FOR PARENT
        // Retrieve Student Trips Information for Home page
        public DataSet retrieveStudentTripInformation(string username)
        {
            DataSet ds = new DataSet();

            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT parentChild1, parentChild2, parentChild3, parentChild4, parentChild5 FROM Parent");
            sqlStr.AppendLine("WHERE @paraUsername in (parentChild1, parentChild2, parentChild3, parentChild4, parentChild5);");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraUsername", username);

            da.Fill(ds, "returnTable");
            DataRow row = ds.Tables["returnTable"].Rows[0];

            string child1 = "";
            string child2 = "";
            string child3 = "";
            string child4 = "";
            string child5 = "";

            if (row["parentChild1"].ToString() != "")
            {
                child1 = row["parentChild1"].ToString().Substring(1);
                checkUserInTripForParent(child1);
            }
            if (row["parentChild2"].ToString() != "")
            {
                child2 = row["parentChild2"].ToString().Substring(1);
                checkUserInTripForParent(child2);
            }
            if (row["parentChild3"].ToString() != "")
            {
                child3 = row["parentChild3"].ToString().Substring(1);
                checkUserInTripForParent(child3);
            }
            if (row["parentChild4"].ToString() != "")
            {
                child4 = row["parentChild4"].ToString().Substring(1);
                checkUserInTripForParent(child4);
            }
            if (row["parentChild5"].ToString() != "")
            {
                child5 = row["parentChild5"].ToString().Substring(1);
                checkUserInTripForParent(child5);
            }

            DataSet ds2 = new DataSet();
            StringBuilder sqlStr2 = new StringBuilder();

            // SQL Command
            sqlStr2.AppendLine("SELECT adminNo, Student.tripID, studentName, tripHist, tripName, tripDesc, tripType, tripLocation, tripStartDate, tripEndDate, staffName, staffHP, staffEmail FROM Student");
            sqlStr2.AppendLine("LEFT JOIN Trip ON Trip.Id = Student.tripID");
            sqlStr2.AppendLine("LEFT JOIN Staff ON Trip.tripStaffNo = Staff.staffNo");
            sqlStr2.AppendLine("WHERE adminNo IN (@paraChild1, @paraChild2, @paraChild3, @paraChild4, @paraChild5)");

            SqlConnection myConn2 = new SqlConnection(DBConnect);
            SqlDataAdapter da2 = new SqlDataAdapter(sqlStr2.ToString(), myConn);

            da2.SelectCommand.Parameters.AddWithValue("paraChild1", child1);
            da2.SelectCommand.Parameters.AddWithValue("paraChild2", child2);
            da2.SelectCommand.Parameters.AddWithValue("paraChild3", child3);
            da2.SelectCommand.Parameters.AddWithValue("paraChild4", child4);
            da2.SelectCommand.Parameters.AddWithValue("paraChild5", child5);

            da2.Fill(ds2, "returnTable");

            return ds2;
        }

        public StudentTripHistory getTripHistoryForHome(string tripId)
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

        // Notes for parent
        public DataSet getAllNotes(string tripId, string adminNo)
        {
            DataSet ds = new DataSet();

            // SQL Command TO GET OUTING TRIP IN THAT TRIPID
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * FROM NoteforParent");
            sqlStr.AppendLine("WHERE studentAdminNo = @paraUsername AND tripId = @paraTripId");
            

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraUsername", adminNo);
            da.SelectCommand.Parameters.AddWithValue("paraTripId", tripId);

            da.Fill(ds, "returnTable");

            return ds;
        }

        public void checkUserInTripForParent(string username)
        {
            DataSet ds = new DataSet();

            // SQL Command GET STUDENT TRIP DATES
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT studentName, Student.tripID, tripStartDate, tripEndDate FROM Student");
            sqlStr.AppendLine("INNER JOIN Trip ON Student.tripID = Trip.Id");
            sqlStr.AppendLine("WHERE adminNo = @paraUsername");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraUsername", username);

            da.Fill(ds, "returnTable");

            int count = ds.Tables["returnTable"].Rows.Count;
            if (count != 0)
            {
                DataRow row = ds.Tables["returnTable"].Rows[0];

                DateTime startDate = Convert.ToDateTime(row["tripStartDate"].ToString());
                DateTime endDate = Convert.ToDateTime(row["tripEndDate"].ToString());
                DateTime nowDate = DateTime.Now;

                if (nowDate > endDate)
                {
                    // SQL Command
                    StringBuilder updateStr = new StringBuilder();
                    updateStr.AppendLine("UPDATE Student");
                    updateStr.AppendLine("SET tripStatus = 1, tripID = NULL, tripHist = tripHist + @paraTripId");
                    updateStr.AppendLine("WHERE adminNo = @paraUsername");

                    SqlCommand sqlCommand = new SqlCommand(updateStr.ToString(), myConn);

                    sqlCommand.Parameters.AddWithValue("@paraTripId", "," + row["tripID"].ToString());
                    sqlCommand.Parameters.AddWithValue("@paraUsername", username);

                    myConn.Open();
                    int result = 0;
                    result = sqlCommand.ExecuteNonQuery();
                    myConn.Close();
                }
            }
        }


        // FOR STUDENT INTRIPS
        public DataSet retrieveTripOutings(string username)
        {
            DataSet ds = new DataSet();

            DateTime nowDateTime = DateTime.Now;

            // SQL Command TO GET OUTING TRIP IN THAT TRIPID
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT InTripOrganizer.Id, senderAdminNo, studentName, title, description, location, dateTime, attending, notAttending FROM InTripOrganizer");
            sqlStr.AppendLine("INNER JOIN Student ON InTripOrganizer.senderAdminNo = Student.adminNo");
            sqlStr.AppendLine("WHERE InTripOrganizer.tripId = (SELECT tripID FROM Student");
            sqlStr.AppendLine("WHERE adminNo = @paraUsername)");
            sqlStr.AppendLine("AND dateTime > @paraNowDateTime");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraUsername", username);
            da.SelectCommand.Parameters.AddWithValue("paraNowDateTime", nowDateTime);

            da.Fill(ds, "returnTable");
            
            return ds;
        }

        public bool checkUserInTrip(string username)
        {
            DataSet ds = new DataSet();

            // SQL Command GET STUDENT TRIP DATES
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT studentName, Student.tripID, tripStartDate, tripEndDate FROM Student");
            sqlStr.AppendLine("INNER JOIN Trip ON Student.tripID = Trip.Id");
            sqlStr.AppendLine("WHERE adminNo = @paraUsername");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraUsername", username);

            da.Fill(ds, "returnTable");

            int count = ds.Tables["returnTable"].Rows.Count;
            if (count != 0)
            {
                DataRow row = ds.Tables["returnTable"].Rows[0];

                DateTime startDate = Convert.ToDateTime(row["tripStartDate"].ToString());
                DateTime endDate = Convert.ToDateTime(row["tripEndDate"].ToString());
                DateTime nowDate = DateTime.Now;

                if (nowDate > endDate)
                {
                    // SQL Command
                    StringBuilder updateStr = new StringBuilder();
                    updateStr.AppendLine("UPDATE Student");
                    updateStr.AppendLine("SET tripStatus = 1, tripID = NULL, tripHist = tripHist + @paraTripId");
                    updateStr.AppendLine("WHERE adminNo = @paraUsername");

                    SqlCommand sqlCommand = new SqlCommand(updateStr.ToString(), myConn);

                    sqlCommand.Parameters.AddWithValue("@paraTripId", "," + row["tripID"].ToString());
                    sqlCommand.Parameters.AddWithValue("@paraUsername", username);

                    myConn.Open();
                    int result = 0;
                    result = sqlCommand.ExecuteNonQuery();
                    myConn.Close();

                    // Show Normal Trip
                    return false;
                }
                else if (nowDate < startDate)
                {
                    // Show Normal Trip
                    return false;
                }
                else
                {
                    // Change TripStatus
                    ProfileInformation dao = new ProfileInformation();
                    dao.setTripStatusTo6(username);
                    // Show In-Trip Home
                    return true;
                }
            }

            // Show Normal Trip
            return false;
        }

        public int createTripOrganizer(string username, string title, string desc, string location, string date, string time)
        {
            DataSet ds = new DataSet();

            // SQL Command GET STUDENT TRIP DATES
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT studentName, Student.tripID, tripStartDate, tripEndDate FROM Student");
            sqlStr.AppendLine("INNER JOIN Trip ON Student.tripID = Trip.Id");
            sqlStr.AppendLine("WHERE adminNo = @paraUsername");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraUsername", username);

            da.Fill(ds, "returnTable");

            int count = ds.Tables["returnTable"].Rows.Count;

            if (count != 0)
            {
                DataRow row = ds.Tables["returnTable"].Rows[0];

                DateTime startDate = Convert.ToDateTime(row["tripStartDate"].ToString());
                DateTime endDate = Convert.ToDateTime(row["tripEndDate"].ToString());

                DateTime orgDate = Convert.ToDateTime(date);
                DateTime orgTime = Convert.ToDateTime(time);

                DateTime organizerDateTime = orgDate.Date.Add(orgTime.TimeOfDay);

                if (organizerDateTime < startDate || organizerDateTime > endDate)
                {
                    return 9;
                }

                // Create Trip Outings
                // SQL Command
                StringBuilder sqlInsert = new StringBuilder();
                sqlInsert.AppendLine("INSERT INTO InTripOrganizer (tripId, senderAdminNo, title, description, location, dateTime) ");
                sqlInsert.AppendLine("VALUES (@paraTripId, @paraSenderAdmin, @paraTitle, @paraDesc, @paraLocation, @paraDateTime)");

                SqlConnection toInsert = new SqlConnection(DBConnect);
                SqlCommand sqlCommand = new SqlCommand(sqlInsert.ToString(), toInsert);

                sqlCommand.Parameters.AddWithValue("@paraTripId", row["tripID"].ToString());
                sqlCommand.Parameters.AddWithValue("@paraSenderAdmin", username);
                sqlCommand.Parameters.AddWithValue("@paraTitle", title);
                sqlCommand.Parameters.AddWithValue("@paraDesc", desc);
                sqlCommand.Parameters.AddWithValue("@paraLocation", location);
                sqlCommand.Parameters.AddWithValue("@paraDateTime", organizerDateTime);

                toInsert.Open();
                int result = 0;
                result = sqlCommand.ExecuteNonQuery();
                toInsert.Close();
                
                return result;
            }

            return 0;
        }

        // For Organizer Attend/Not Attend
        public void attendingOrNo(string id, string adminNo, string attending)
        {
            DataSet ds = new DataSet();

            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT attending, notAttending FROM InTripOrganizer");
            sqlStr.AppendLine("WHERE Id = @paraId");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraId", id);

            da.Fill(ds, "returnTable");

            DataRow row = ds.Tables["returnTable"].Rows[0];
            
            if (attending == "1")
            {
                // SQL Command
                StringBuilder updateAttendStr = new StringBuilder();
                updateAttendStr.AppendLine("UPDATE InTripOrganizer");
                updateAttendStr.AppendLine("SET attending = @paraStudentAdminNo");
                updateAttendStr.AppendLine("WHERE Id = @paraTripId");

                SqlConnection myConn1 = new SqlConnection(DBConnect);
                SqlCommand sqlCommand = new SqlCommand(updateAttendStr.ToString(), myConn1);

                sqlCommand.Parameters.AddWithValue("@paraStudentAdminNo", row["attending"].ToString() + "," + adminNo.ToUpper());
                sqlCommand.Parameters.AddWithValue("@paraTripId", id);

                myConn1.Open();
                int result = 0;
                result = sqlCommand.ExecuteNonQuery();
                myConn1.Close();
            }
            else
            {
                // SQL Command
                StringBuilder updateNotAttendStr = new StringBuilder();
                updateNotAttendStr.AppendLine("UPDATE InTripOrganizer");
                updateNotAttendStr.AppendLine("SET notAttending = @paraStudentAdminNo");
                updateNotAttendStr.AppendLine("WHERE Id = @paraTripId");

                SqlConnection myConn1 = new SqlConnection(DBConnect);
                SqlCommand sqlCommand = new SqlCommand(updateNotAttendStr.ToString(), myConn1);

                sqlCommand.Parameters.AddWithValue("@paraStudentAdminNo", row["notAttending"].ToString() + "," + adminNo.ToUpper());
                sqlCommand.Parameters.AddWithValue("@paraTripId", id);

                myConn1.Open();
                int result = 0;
                result = sqlCommand.ExecuteNonQuery();
                myConn1.Close();
            }
            
        }

        // For the Curfew
        public int updateCurfew(string username, DateTime dateTime)
        {
            DataSet ds = new DataSet();

            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT tripId FROM CurfewCheck");
            sqlStr.AppendLine("WHERE studentAdminNo = @paraUsername");
            sqlStr.AppendLine("AND tripId = (SELECT Student.tripId FROM Student WHERE adminNo = @paraUsername)");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraUsername", username);

            da.Fill(ds, "returnTable");

            try
            {
                DataRow row = ds.Tables["returnTable"].Rows[0];

                // UPDATE
                // SQL Command
                StringBuilder UpdateStr = new StringBuilder();
                UpdateStr.AppendLine("UPDATE CurfewCheck");
                UpdateStr.AppendLine("SET dateTime = @paraDateTime");
                UpdateStr.AppendLine("WHERE studentAdminNo = @paraUsername");
                UpdateStr.AppendLine("AND tripId = @paraTripId");

                SqlConnection myConn3 = new SqlConnection(DBConnect);
                SqlCommand sqlCommand2 = new SqlCommand(UpdateStr.ToString(), myConn3);

                sqlCommand2.Parameters.AddWithValue("@paraUsername", username);
                sqlCommand2.Parameters.AddWithValue("@paraDateTime", dateTime.ToString());
                sqlCommand2.Parameters.AddWithValue("@paraTripId", row["tripId"].ToString());

                myConn3.Open();
                int resultUpdate = 0;
                resultUpdate = sqlCommand2.ExecuteNonQuery();
                myConn3.Close();

                return resultUpdate;
            }
            // CREATE
            catch (IndexOutOfRangeException)
            {
                // SQL Command
                StringBuilder InsertStr = new StringBuilder();
                InsertStr.AppendLine("INSERT INTO CurfewCheck (studentAdminNo, tripId, dateTime)");
                InsertStr.AppendLine("VALUES (@paraUsername, (SELECT tripID FROM Student WHERE adminNo = @paraUsername), @paraDateTime)");

                SqlConnection myConn2 = new SqlConnection(DBConnect);
                SqlCommand sqlCommand = new SqlCommand(InsertStr.ToString(), myConn2);

                sqlCommand.Parameters.AddWithValue("@paraUsername", username);
                sqlCommand.Parameters.AddWithValue("@paraDateTime", dateTime.ToString());

                myConn2.Open();
                int result = 0;
                result = sqlCommand.ExecuteNonQuery();
                myConn2.Close();

                return result;
            }
            
        }

        // FOR STAFF INTRIPS
        // Check if Staff In Trip
        public DataSet checkStaffInTrip(string username)
        {
            DataSet ds = new DataSet();

            // SQL Command GET STUDENT TRIP DATES
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT tripStaffNo, Id, tripStartDate, tripEndDate FROM Trip");
            sqlStr.AppendLine("WHERE tripStaffNo = @paraStaffUsername");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraStaffUsername", username);

            da.Fill(ds, "returnTable");

            int count = ds.Tables["returnTable"].Rows.Count;
            if (count != 0)
            {
                for (var i = 0; i < count; i++)
                {
                    DataRow row = ds.Tables["returnTable"].Rows[i];

                    DateTime startDate = Convert.ToDateTime(row["tripStartDate"].ToString());
                    DateTime endDate = Convert.ToDateTime(row["tripEndDate"].ToString());
                    DateTime nowDate = DateTime.Now;

                    if (nowDate >= startDate && nowDate <= endDate)
                    {
                        // In Trip
                        // Who in Trip?
                        DataSet resultDS = new DataSet();

                        DateTime nowDateTime = DateTime.Now;

                        // SQL Command TO GET OUTING TRIP IN THAT TRIPID
                        StringBuilder getInformation = new StringBuilder();
                        getInformation.AppendLine("SELECT  adminNo, studentName, studentHP, tripID FROM Student");
                        getInformation.AppendLine("WHERE tripID = @paraTripID");

                        SqlConnection myConnGetInfo = new SqlConnection(DBConnect);
                        SqlDataAdapter resultDA = new SqlDataAdapter(getInformation.ToString(), myConnGetInfo);

                        resultDA.SelectCommand.Parameters.AddWithValue("paraTripID", row["Id"].ToString());

                        resultDA.Fill(resultDS, "returnTable");

                        return resultDS;
                    }
                }
            }

            // Not in Trip
            return null;
        }

        // Get Curfew Info
        public string retrieveCurfewTime(string username, string tripId)
        {
            DataSet ds = new DataSet();

            DateTime nowDateTime = DateTime.Now;

            // SQL Command TO GET OUTING TRIP IN THAT TRIPID
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT dateTime FROM CurfewCheck");
            sqlStr.AppendLine("WHERE studentAdminNo = @paraUsername AND tripId = @paraTripId");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraUsername", username);
            da.SelectCommand.Parameters.AddWithValue("paraTripId", tripId);

            da.Fill(ds, "returnTable");

            int count = ds.Tables["returnTable"].Rows.Count;
            if (count != 0)
            {
                DataRow row = ds.Tables["returnTable"].Rows[0];

                string dateTime = row["dateTime"].ToString();

                return dateTime;
            }
            else return null;
        }

        // Send Notes
        public int sendNotesToParent(string staffUsername, string studUsername, string notes)
        {
            DataSet ds = new DataSet();

            // SQL Command TO GET OUTING TRIP IN THAT TRIPID
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT Trip.Id, tripStaffNo, Student.tripID, adminNo FROM Student");
            sqlStr.AppendLine("INNER JOIN Trip ON Trip.Id = Student.tripID");
            sqlStr.AppendLine("WHERE adminNo = @paraStudUsername");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraStudUsername", studUsername);

            da.Fill(ds, "returnTable");

            int count = ds.Tables["returnTable"].Rows.Count;
            if (count != 0)
            {
                // SQL Command
                StringBuilder sqlInsert = new StringBuilder();
                sqlInsert.AppendLine("INSERT INTO NoteforParent (studentAdminNo, tripId, dateTime, notes)");
                sqlInsert.AppendLine("VALUES (@paraUsername, (SELECT tripID from Student WHERE adminNo = @paraUsername), @paraDateTime, @paraDesc)");

                SqlConnection toInsert = new SqlConnection(DBConnect);
                SqlCommand sqlCommand = new SqlCommand(sqlInsert.ToString(), toInsert);

                sqlCommand.Parameters.AddWithValue("@paraUsername", studUsername);
                sqlCommand.Parameters.AddWithValue("@paraDateTime", (DateTime.Now).ToString());
                sqlCommand.Parameters.AddWithValue("@paraDesc", notes);

                toInsert.Open();
                int result = 0;
                result = sqlCommand.ExecuteNonQuery();
                toInsert.Close();

                return result;
            }
            else return 0;
        }

    }
}