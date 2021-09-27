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
    public class studentTripRetrieveDAO
    {

        public studentTripRetrieve getTripById(string Id)
        {
            //Get connection string from web.config
            string DBConnect = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;

            SqlDataAdapter da;
            DataSet ds = new DataSet();

            //Create Adapter
            //WRITE SQL Statement to retrieve all columns from Customer by customer Id using query parameter
            StringBuilder sqlCommand = new StringBuilder();
            sqlCommand.AppendLine("Select * from Trip");
            sqlCommand.AppendLine("WHERE Id = @paraId");

            //***TO Simulate system error  *****
            // change custId in where clause to custId1 or 
            // change connection string in web config to a wrong file name  

            studentTripRetrieve obj = new studentTripRetrieve();   // create a customer instance

            SqlConnection myConn = new SqlConnection(DBConnect);
            da = new SqlDataAdapter(sqlCommand.ToString(), myConn);
            da.SelectCommand.Parameters.AddWithValue("paraId", Id);
            // fill dataset
            da.Fill(ds, "tripTable");
            int rec_cnt = ds.Tables["tripTable"].Rows.Count;

            DataRow row = ds.Tables["tripTable"].Rows[0];  // Sql command returns only one record
            obj.tripName = row["tripName"].ToString();
            obj.tripCost = row["tripCost"].ToString();
            obj.tripEndDate = row["tripEndDate"].ToString();
            obj.tripStartDate = row["tripStartDate"].ToString();
            obj.tripDesc = row["tripDesc"].ToString();
            obj.tripId = row["Id"].ToString();
            obj.triptype = row["tripType"].ToString();

            return obj;
        }

    }
}