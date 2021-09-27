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
    public class interviewDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;

        public staff getStaffNamebyStaffNo(string staffNo)
        {
            staff id = new staff();
            DataSet ds = new DataSet();
            DataTable idData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From Staff");
            sqlStr.AppendLine("where staffNo = @paraStaffNo");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraStaffNo", staffNo);

            da.Fill(ds, "TableID");

            staff ID = new staff();
            int rec_cnt = ds.Tables["TableID"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["TableID"].Rows[0];
                ID.sStaffName = row["staffName"].ToString();
                ID.sStaffHP = row["staffHP"].ToString();
            }
            else
            {
                ID = null;
            }

            return ID;
        }

        public int addInterview(String tripId, String adminNo, String staffName,String staffHP, String meetDate, String meetTime, String meetLocation, String additionalInfo)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;

            sqlStr.AppendLine("INSERT INTO interviewDetails (tripId, adminNo, staffName,staffHP, meetDate, meetTime, meetLocation, additionalInfo)");
            sqlStr.AppendLine("VALUES (@paraTripId, @paraAdminNo, @paraStaffName,@paraStaffHP, @paraMeetDate,@paraMeetTime, @paraMeetLocation, @paraAdditionalInfo)");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);
            sqlCmd.Parameters.AddWithValue("@paraTripId", tripId);
            sqlCmd.Parameters.AddWithValue("@paraAdminNo", adminNo);
            sqlCmd.Parameters.AddWithValue("@paraStaffName", staffName);
            sqlCmd.Parameters.AddWithValue("@paraStaffHP", staffHP);
            sqlCmd.Parameters.AddWithValue("@paraMeetDate", meetDate);
            sqlCmd.Parameters.AddWithValue("@paraMeetTime", meetTime);
            sqlCmd.Parameters.AddWithValue("@paraMeetLocation", meetLocation);
            sqlCmd.Parameters.AddWithValue("@paraAdditionalInfo", additionalInfo);


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public interview getInterviewDetailsByAdminNo(string adminNo)
        {
            interview id = new interview();
            DataSet ds = new DataSet();
            DataTable idData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From interviewDetails");
            sqlStr.AppendLine("where adminNo = @paraAdminNo");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraAdminNo", adminNo);

            da.Fill(ds, "TableID");

            interview ID = new interview();
            int rec_cnt = ds.Tables["TableID"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["TableID"].Rows[0];
                ID.idTripId = row["tripId"].ToString();
                ID.idStaffName = row["staffName"].ToString();
                ID.idStaffHP= row["staffHP"].ToString();
                ID.idMeetDate = row["meetDate"].ToString();
                ID.idMeetTime = row["meetTime"].ToString();
                ID.idMeetLocation = row["meetLocation"].ToString();
                ID.idAdditionalInfo = row["additionalInfo"].ToString();
            }
            else
            {
                ID = null;
            }

            return ID;
        }

        public List<interview> getInterviewByTripId(string tripId)
        {
            List<interview> idList = new List<interview>();
            DataSet ds = new DataSet();
            DataTable idData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From interviewDetails");
            sqlStr.AppendLine("WHERE tripId = @paraTripId");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);
            
            da.SelectCommand.Parameters.AddWithValue("paraTripId", tripId);

            da.Fill(ds, "TableID");

            int rec_cnt = ds.Tables["TableID"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableID"].Rows)
                {
                    interview ID = new interview();

                    ID.idAdminNo = row["adminNo"].ToString();

                    idList.Add(ID);
                }
            }
            else
            {
                idList = null;
            }

            return idList;
        }
        public int deleteInterview(string adminNo)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("DELETE From interviewDetails");
            sqlStr.AppendLine("WHERE adminNo = @paraAdminNo");

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