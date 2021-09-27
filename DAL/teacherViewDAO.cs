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
    public class teacherViewDAO
    {
        public teacherView getTripByName()
        {
            teacherView obj = new teacherView();
            //List <teacherView> tripsList = new List<teacherView>();
            string DBConnect = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select tripName, staffNo, location, description, startDate,EndDate,cost,typeOfTrip,tripSumamry,tripAirline,tripItinerary,tripSelection from TRIP");
           
            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);

            da.Fill(ds,"tripTable");
            int rec_cnt = ds.Tables["tripTable"].Rows.Count;

            if (rec_cnt> 0)
            {
                    DataRow row = ds.Tables["tripTable"].Rows[0];
                    obj.getTripName = Convert.ToString(row["tripName"]);
                    obj.getStaffNo = Convert.ToString(row["StaffNo"]);
                    obj.getLocation = Convert.ToString(row["Location"]);
                    obj.getDescription = Convert.ToString(row["Description"]);
                    obj.getStartDate = Convert.ToDateTime(row["StartDate"]);
                    obj.getEndDate = Convert.ToDateTime(row["EndDate"]);
                    obj.getCost = Convert.ToInt32(row["Cost"]);
                    obj.getTypeOfTrip = Convert.ToString(row["TypeOfTrip"]);
                    obj.tripSummary = row["tripSummary"].ToString();
                    obj.tripAirline = row["tripAirline"].ToString();
                    obj.tripItinerary = row["tripItinerary"].ToString();
                    obj.tripSelection = row["tripSelection"].ToString();
            }
            else
            {
                obj = null;
            }


            return obj;
        }
    }
}