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
    public class adminDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;

        public int updateStatus(int blogID, String blogStatus)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;    
            SqlCommand sqlCmd = new SqlCommand();   

            sqlStr.AppendLine("UPDATE Blog SET blogStatus = @parablogStatus");
            sqlStr.AppendLine("WHERE blogID =  @parablogID");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@parablogStatus", blogStatus);
            sqlCmd.Parameters.AddWithValue("@parablogID", blogID);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public int deleteBlog(int blogID)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("DELETE FROM Blog WHERE blogID = @parablogID");

            SqlConnection myConn = new SqlConnection(DBConnect);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("@parablogID", blogID);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}