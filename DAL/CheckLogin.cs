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
    public class CheckLogin
    {
        // Database
        string DBConnect = ConfigurationManager.ConnectionStrings["ITravelDBConnectionString"].ConnectionString;
        
        // For Student
        public List<String> checkForStudentLogin(string id, string pass)
        {
            DataSet ds = new DataSet();

            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT studentName From Student");
            sqlStr.AppendLine("WHERE adminNo = @paraAdminNo");
            sqlStr.AppendLine("AND studentPass = @paraPass COLLATE Latin1_General_CS_AS");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraAdminNo", id);
            da.SelectCommand.Parameters.AddWithValue("paraPass", pass);

            da.Fill(ds, "returnTable");

            List<String> returnData = new List<String>(2);
            int rec_cnt = ds.Tables["returnTable"].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables["returnTable"].Rows[0];
                returnData.Add("Student");
                returnData.Add(row["studentName"].ToString());
                return returnData;
            }
            returnData.Add("Student");
            returnData.Add(null);
            return returnData;
        }

        // For Staff
        public List<String> checkForStaffLogin(string id, string pass)
        {
            DataSet ds = new DataSet();

            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT staffName, PEMGroup From Staff");
            sqlStr.AppendLine("WHERE staffNo = @paraAdminNo");
            sqlStr.AppendLine("AND staffPass = @paraPass COLLATE Latin1_General_CS_AS");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraAdminNo", id);
            da.SelectCommand.Parameters.AddWithValue("paraPass", pass);

            da.Fill(ds, "returnTable");

            List<String> returnData = new List<String>(2);
            int rec_cnt = ds.Tables["returnTable"].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables["returnTable"].Rows[0];
                returnData.Add("Staff");
                returnData.Add(row["staffName"].ToString());
                returnData.Add(row["PEMGroup"].ToString());
                return returnData;
            }
            returnData.Add("Staff");
            returnData.Add(null);
            return returnData;
        }

        // For Admin
        public List<String> checkForAdminLogin(string id, string pass)
        {
            DataSet ds = new DataSet();

            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT adminName From Admin");
            sqlStr.AppendLine("WHERE adminID = @paraAdminNo");
            sqlStr.AppendLine("AND adminPass = @paraPass COLLATE Latin1_General_CS_AS");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraAdminNo", id);
            da.SelectCommand.Parameters.AddWithValue("paraPass", pass);

            da.Fill(ds, "returnTable");

            List<String> returnData = new List<String>(2);
            int rec_cnt = ds.Tables["returnTable"].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables["returnTable"].Rows[0];
                returnData.Add("Admin");
                returnData.Add(row["adminName"].ToString());
                return returnData;
            }
            returnData.Add("Admin");
            returnData.Add(null);
            return returnData;
        }

        // For Parent
        public List<String> checkForParentLogin(string id, string pass)
        {
            DataSet ds = new DataSet();

            // SQL Command
            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT parentName From Parent");
            sqlStr.AppendLine("WHERE @paraparAdminNo IN (parentChild1, parentChild2, parentChild3, parentChild4, parentChild5)");
            sqlStr.AppendLine("AND password = @paraIC_No COLLATE Latin1_General_CS_AS");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraparAdminNo", id);
            da.SelectCommand.Parameters.AddWithValue("paraIC_No", pass);

            da.Fill(ds, "returnTable");

            List<String> returnData = new List<String>(2);
            int rec_cnt = ds.Tables["returnTable"].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables["returnTable"].Rows[0];
                returnData.Add("Parent");
                returnData.Add(row["parentName"].ToString());
                return returnData;
            }
            returnData.Add("Parent");
            returnData.Add(null);
            return returnData;
        }
    }
}