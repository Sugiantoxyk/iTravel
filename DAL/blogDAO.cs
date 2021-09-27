using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using iTravel.Models;
using System.Collections.Generic;

namespace iTravel.DAL
{
    public class blogDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;

        public int NewBlogPost(String blogTitle, String blogDesc, String blogUser, DateTime blogDateTime, String blogLocation, String blogImage, String blogStatus, int blogReports)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("INSERT INTO Blog(blogTitle, blogDesc, blogUser, blogDateTime, blogLocation, blogImage, blogStatus, blogReports)");
            sqlStr.AppendLine("VALUES (@parablogTitle, @parablogDesc, @parablogUser, @parablogDateTime, @parablogLocation, @parablogImage, @parablogStatus, @parablogReports)");

            SqlConnection myConn = new SqlConnection(DBConnect);
            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd.Parameters.AddWithValue("parablogTitle", blogTitle);
            sqlCmd.Parameters.AddWithValue("parablogDesc", blogDesc);
            sqlCmd.Parameters.AddWithValue("parablogUser", blogUser);
            sqlCmd.Parameters.AddWithValue("parablogDateTime", blogDateTime);
            sqlCmd.Parameters.AddWithValue("parablogLocation", blogLocation);
            sqlCmd.Parameters.AddWithValue("parablogImage", blogImage);
            sqlCmd.Parameters.AddWithValue("parablogStatus", blogStatus);
            sqlCmd.Parameters.AddWithValue("parablogReports", blogReports);

            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public blog getPostByBlogId(string blogID)
        {
            blog td = new blog();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From Blog");
            sqlStr.AppendLine("where blogID = @parablogID");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);


            da.SelectCommand.Parameters.AddWithValue("parablogID", blogID);

            da.Fill(ds, "TableTD");

            blog myTD = new blog();
            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["TableTD"].Rows[0];
                myTD.blogID = Convert.ToInt32(row["blogID"]);
                myTD.blogTitle = row["blogTitle"].ToString();
                myTD.blogDesc = row["blogDesc"].ToString();
                myTD.blogUser = row["blogUser"].ToString();
                myTD.blogDateTime = Convert.ToDateTime(row["blogDateTime"]);
                myTD.blogLocation = row["blogLocation"].ToString();
                myTD.blogImage = row["blogImage"].ToString();
                myTD.blogStatus = row["blogStatus"].ToString();
                myTD.blogReports = Convert.ToInt32(row["blogReports"]);
            }
            else
            {
                myTD = null;
            }

            return myTD;
        }

        public blog getPostByBlogLocation(string blogLocation)
        {
            blog td = new blog();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From Blog");
            sqlStr.AppendLine("where blogLocation = @parablogLocation");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);


            da.SelectCommand.Parameters.AddWithValue("parablogLocation", blogLocation);

            da.Fill(ds, "TableTD");

            blog myTD = new blog();
            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["TableTD"].Rows[0];
                myTD.blogID = Convert.ToInt32(row["blogID"]);
                myTD.blogTitle = row["blogTitle"].ToString();
                myTD.blogDesc = row["blogDesc"].ToString();
                myTD.blogUser = row["blogUser"].ToString();
                myTD.blogDateTime = Convert.ToDateTime(row["blogDateTime"]);
                myTD.blogLocation = row["blogLocation"].ToString();
                myTD.blogImage = row["blogImage"].ToString();
                myTD.blogStatus = row["blogStatus"].ToString();
                myTD.blogReports = Convert.ToInt32(row["blogReports"]);
            }
            else
            {
                myTD = null;
            }

            return myTD;
        }

        public createTrip getTripImage(string tripLocation)
        {
            createTrip td = new createTrip();
            DataSet ds = new DataSet();
            DataTable tdData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From Trip");
            sqlStr.AppendLine("where tripLocation = @paratripLocation");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);


            da.SelectCommand.Parameters.AddWithValue("paratripLocation", tripLocation);

            da.Fill(ds, "TableTD");

            createTrip myTD = new createTrip();
            int rec_cnt = ds.Tables["TableTD"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["TableTD"].Rows[0];
                myTD.tripId = Convert.ToInt32(row["Id"]);
                myTD.location = row["tripLocation"].ToString();
                myTD.tripImage = row["tripIMG"].ToString();
            }
            else
            {
                myTD = null;
            }

            return myTD;
        }

        public int plus1Report(int blogID)
        {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("UPDATE Blog");
            sqlStr.AppendLine("SET blogReports = blogReports + 1");
            sqlStr.AppendLine("WHERE blogID =  @parablogID");

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