using iTravel.models;
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
    public class internshipDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;

        public int addInternship(String imageName, String imageType, String jobTitle, String country, String Salary, String website, String contact, String industry, String duration, String workingHrs, String company, String overview, String jobScope, String eligibility, String specialQn)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;

            sqlStr.AppendLine("INSERT INTO InternshipInfo (imageName, imageType, jobTitle, country, salary, website, contact, industry, duration, workingHrs, company, overview, jobScope, eligibility, tripType, specialQn)");
            sqlStr.AppendLine("VALUES (@paraImageName, @paraImageType, @paraJobTitle,@paraCountry, @paraSalary, @paraWebsite, @paraContact, @paraIndustry, @paraDuration, @paraWorkingHrs, @paraCompany, @paraOverview, @paraJobScope, @paraEligibility, @paraTripType, @paraSpecialQn)");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);
            sqlCmd.Parameters.AddWithValue("@paraImageName", imageName);
            sqlCmd.Parameters.AddWithValue("@paraImageType", imageType);
            sqlCmd.Parameters.AddWithValue("@paraJobTitle", jobTitle);
            sqlCmd.Parameters.AddWithValue("@paraCountry", country);
            sqlCmd.Parameters.AddWithValue("@paraSalary", Salary);
            sqlCmd.Parameters.AddWithValue("@paraWebsite", website);
            sqlCmd.Parameters.AddWithValue("@paraContact", contact);
            sqlCmd.Parameters.AddWithValue("@paraIndustry", industry);
            sqlCmd.Parameters.AddWithValue("@paraDuration", duration);
            sqlCmd.Parameters.AddWithValue("@paraWorkingHrs", workingHrs);
            sqlCmd.Parameters.AddWithValue("@paraCompany", company);
            sqlCmd.Parameters.AddWithValue("@paraOverview", overview);
            sqlCmd.Parameters.AddWithValue("@paraJobScope", jobScope);
            sqlCmd.Parameters.AddWithValue("@paraEligibility", eligibility);
            sqlCmd.Parameters.AddWithValue("@paraTripType", "Internship");
            sqlCmd.Parameters.AddWithValue("@paraSpecialQn", specialQn);


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public List<internshipInfo> getInternshipName()
        {
            List<internshipInfo> intInfoList = new List<internshipInfo>();
            DataSet ds = new DataSet();
            DataTable intData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From InternshipInfo");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.Fill(ds, "TableInt");

            int rec_cnt = ds.Tables["TableInt"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableInt"].Rows)
                {
                    internshipInfo IntInfo = new internshipInfo();

                    IntInfo.intId = row["Id"].ToString();
                    IntInfo.intImageName = row["imageName"].ToString();
                    IntInfo.intJobTitle = row["jobTitle"].ToString();
                    IntInfo.intSalary = row["salary"].ToString();
                    IntInfo.intWebsite = row["website"].ToString();
                    IntInfo.intContact = row["contact"].ToString();
                    IntInfo.intIndustry = row["industry"].ToString();
                    IntInfo.intDuration = row["duration"].ToString();
                    IntInfo.intWorkingHrs = row["workingHrs"].ToString();
                    IntInfo.intCompany = row["company"].ToString();
                    IntInfo.intOverview = row["overview"].ToString();
                    IntInfo.intJobscope = row["jobScope"].ToString();
                    IntInfo.intEligibility = row["eligibility"].ToString();
                    IntInfo.intSpecialQn = row["specialQn"].ToString();

                    intInfoList.Add(IntInfo);
                }
            }
            else
            {
                intInfoList = null;
            }

            return intInfoList;
        }

        public internshipInfo getInternshipById(string intId)
        {
            internshipInfo Int = new internshipInfo();
            DataSet ds = new DataSet();
            DataTable intData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From InternshipInfo");
            sqlStr.AppendLine("where Id = @paraIntId");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);

            da.SelectCommand.Parameters.AddWithValue("paraIntId", intId);

            da.Fill(ds, "TableInt");

            internshipInfo IntInfo = new internshipInfo();
            int rec_cnt = ds.Tables["TableInt"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["TableInt"].Rows[0];
                IntInfo.intId = row["Id"].ToString();
                IntInfo.intImageName = row["imageName"].ToString();
                IntInfo.intJobTitle = row["jobTitle"].ToString();
                IntInfo.intSalary = row["salary"].ToString();
                IntInfo.intWebsite = row["website"].ToString();
                IntInfo.intContact = row["contact"].ToString();
                IntInfo.intIndustry = row["industry"].ToString();
                IntInfo.intDuration = row["duration"].ToString();
                IntInfo.intWorkingHrs = row["workingHrs"].ToString();
                IntInfo.intCompany = row["company"].ToString();
                IntInfo.intOverview = row["overview"].ToString();
                IntInfo.intJobscope = row["jobScope"].ToString();
                IntInfo.intEligibility = row["eligibility"].ToString();
                IntInfo.intSpecialQn = row["specialQn"].ToString();

            }
            else
            {
                IntInfo = null;
            }

            return IntInfo;
        }

    }
}