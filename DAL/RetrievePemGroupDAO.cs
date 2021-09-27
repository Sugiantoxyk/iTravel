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
    public class RetrievePemGroupDAO
    {
        public RetrievePemGroup getPemGroupid(string Id)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer by customer Id using query parameter
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from Staff");

            //***TO Simulate system error  *****
            // change custId in where clause to custId1 or 
            // change connection string in web config to a wrong file name  

            RetrievePemGroup obj = new RetrievePemGroup();   // create a customer instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("Id", Id);
            // fill dataset
            da.Fill(ds,  "Staff");
            int rec_cnt = ds.Tables["Staff"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["Staff"].Rows[0];  // Sql command returns only one record
                obj.PemGroup = row["PEMGroup"].ToString();
           

            }
            else
            {
                obj = null;
            }

            return obj;
        }

    }
}