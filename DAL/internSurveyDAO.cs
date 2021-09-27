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
    public class internSurveyDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;

        public int addSurvey(String intId, String diploma, String PEMGroup, String adminNo, String fullName, String gender, String DOB, String contact, String address, String citizenship, String passportNo, String passportExp,
            String waitList, String GPA, String CCA, String leadership, String offence, String PSEABalance,String  fundingScheme, String fasopHist, String medCondition, String partTimeExp, String overseasStay, String independence, String specialAns, String resume)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;

            sqlStr.AppendLine("INSERT INTO internshipSurvey (intId, diploma, PEMGroup, adminNo, fullName, gender, DOB, contact, address, citizenship, passportNo, ");
            sqlStr.AppendLine("passportExp, waitList, GPA, CCA, leadership, offenceCommitted, PSEABalance, fundingScheme, fasopHist, medicalCondition, partTimeExp, overseasStay, independence, specialAns, resume)");
            sqlStr.AppendLine("VALUES (@paraIntId, @paraDiploma, @paraPEMGroup, @paraAdminNo, @paraFullName, @paraGender, @paraDOB, @paraContact, @paraAddress, @paraCitizenship, @paraPassportNo, @paraPassportExp,");
            sqlStr.AppendLine("@paraWaitList, @paraGPA, @paraCCA, @paraLeadership, @paraOffence, @paraPSEABalance, @paraFundingScheme, @paraFasopHist, @paraMedicalCondition, @paraPartTimeExp, @paraOverseasStay, @paraIndependence, @paraSpecialAns, @paraResume)");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);
            sqlCmd.Parameters.AddWithValue("@paraIntId", intId);
            sqlCmd.Parameters.AddWithValue("@paraDiploma", diploma);
            sqlCmd.Parameters.AddWithValue("@paraPEMGroup", PEMGroup);
            sqlCmd.Parameters.AddWithValue("@paraAdminNo", adminNo);
            sqlCmd.Parameters.AddWithValue("@paraFullName", fullName);
            sqlCmd.Parameters.AddWithValue("@paraGender", gender);
            sqlCmd.Parameters.AddWithValue("@paraDOB", DOB);
            sqlCmd.Parameters.AddWithValue("@paraContact", contact);
            sqlCmd.Parameters.AddWithValue("@paraAddress", address);
            sqlCmd.Parameters.AddWithValue("@paraCitizenship", citizenship);
            sqlCmd.Parameters.AddWithValue("@paraPassportNo", passportNo);
            sqlCmd.Parameters.AddWithValue("@paraPassportExp", passportExp);
            sqlCmd.Parameters.AddWithValue("@paraWaitList", waitList);
            sqlCmd.Parameters.AddWithValue("@paraGPA", GPA);
            sqlCmd.Parameters.AddWithValue("@paraCCA", CCA);
            sqlCmd.Parameters.AddWithValue("@paraLeadership", leadership);
            sqlCmd.Parameters.AddWithValue("@paraOffence", offence);
            sqlCmd.Parameters.AddWithValue("@paraPSEABalance", PSEABalance);
            sqlCmd.Parameters.AddWithValue("@paraFundingScheme", fundingScheme);
            sqlCmd.Parameters.AddWithValue("@paraFasopHist", fasopHist);
            sqlCmd.Parameters.AddWithValue("@paraMedicalCondition", medCondition);
            sqlCmd.Parameters.AddWithValue("@paraPartTimeExp", partTimeExp);
            sqlCmd.Parameters.AddWithValue("@paraoverseasStay", overseasStay);
            sqlCmd.Parameters.AddWithValue("@paraIndependence", independence);
            sqlCmd.Parameters.AddWithValue("@paraSpecialAns", specialAns);
            sqlCmd.Parameters.AddWithValue("@paraResume", resume);


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        public List<internSurveyResults> getSuresultsById(string intId)
        {
            List<internSurveyResults> suresultsList = new List<internSurveyResults>();
            DataSet ds = new DataSet();
            DataTable SRdata = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From InternshipSurvey");
            sqlStr.AppendLine("WHERE intId = @paraIntId OR adminNo = @paraIntId");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);
            
            da.SelectCommand.Parameters.AddWithValue("paraIntId", intId);
            
            da.Fill(ds, "TableSR");
            
            int rec_cnt = ds.Tables["TableSR"].Rows.Count;
            if (rec_cnt > 0)
            {
                foreach (DataRow row in ds.Tables["TableSR"].Rows)
                {
                    internSurveyResults suresults = new internSurveyResults();

                    suresults.isDiploma = row["diploma"].ToString();
                    suresults.isPEMGroup = row["PEMGroup"].ToString();
                    suresults.isAdminNo = row["adminNo"].ToString();
                    suresults.isFullName = row["fullName"].ToString();
                    suresults.isGender = row["gender"].ToString();
                    suresults.isDOB = row["DOB"].ToString();
                    suresults.isContact = row["contact"].ToString();
                    suresults.isAddress = row["address"].ToString();
                    suresults.isCitizenship = row["citizenship"].ToString();
                    suresults.isPassportNo = row["passportNo"].ToString();
                    suresults.isPassportExp = row["passportExp"].ToString();
                    suresults.isWaitList = row["waitList"].ToString();
                    suresults.isGPA = row["GPA"].ToString();
                    suresults.isCCA = row["CCA"].ToString();
                    suresults.isLeadership = row["leadership"].ToString();
                    suresults.isOffence = row["offenceCommitted"].ToString();
                    suresults.isPSEABalance = row["PSEABalance"].ToString();
                    suresults.isFundingScheme = row["fundingScheme"].ToString();
                    suresults.isFasopHist = row["fasopHist"].ToString();
                    suresults.isMedCondition = row["medicalCondition"].ToString();
                    suresults.isPartTimeExp = row["partTimeExp"].ToString();
                    suresults.isOverseasStay = row["overseasStay"].ToString();
                    suresults.isIndependence = row["independence"].ToString();

                    suresultsList.Add(suresults);
                }
            }
            else
            {
                suresultsList = null;
            }

            return suresultsList;
        }

        public internSurveyResults getSRbyAdminNo(string adminNo)
        {
            internSurveyResults SR = new internSurveyResults();
            DataSet ds = new DataSet();
            DataTable srData = new DataTable();

            StringBuilder sqlStr = new StringBuilder();
            sqlStr.AppendLine("SELECT * From InternshipSurvey");
            sqlStr.AppendLine("where adminNo = @paraAdminNo");
            
            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlDataAdapter da = new SqlDataAdapter(sqlStr.ToString(), myConn);
            
            da.SelectCommand.Parameters.AddWithValue("paraAdminNo", adminNo);
            
            da.Fill(ds, "TableSR");

            internSurveyResults suresults = new internSurveyResults();
            int rec_cnt = ds.Tables["TableSR"].Rows.Count;
            if (rec_cnt > 0)
            {
                DataRow row = ds.Tables["TableSR"].Rows[0];
                suresults.isIntId = row["intId"].ToString();
                suresults.isDiploma = row["diploma"].ToString();
                suresults.isPEMGroup = row["PEMGroup"].ToString();
                suresults.isAdminNo = row["adminNo"].ToString();
                suresults.isFullName = row["fullName"].ToString();
                suresults.isGender = row["gender"].ToString();
                suresults.isDOB = row["DOB"].ToString();
                suresults.isContact = row["contact"].ToString();
                suresults.isAddress = row["address"].ToString();
                suresults.isCitizenship = row["citizenship"].ToString();
                suresults.isPassportNo = row["passportNo"].ToString();
                suresults.isPassportExp = row["passportExp"].ToString();
                suresults.isWaitList = row["waitList"].ToString();
                suresults.isGPA = row["GPA"].ToString();
                suresults.isCCA = row["CCA"].ToString();
                suresults.isLeadership = row["leadership"].ToString();
                suresults.isOffence = row["offenceCommitted"].ToString();
                suresults.isPSEABalance = row["PSEABalance"].ToString();
                suresults.isFundingScheme = row["fundingScheme"].ToString();
                suresults.isFasopHist = row["fasopHist"].ToString();
                suresults.isMedCondition = row["medicalCondition"].ToString();
                suresults.isPartTimeExp = row["partTimeExp"].ToString();
                suresults.isOverseasStay = row["overseasStay"].ToString();
                suresults.isIndependence = row["independence"].ToString();
                suresults.isSpecialAns = row["specialAns"].ToString();
                suresults.isResume = row["resume"].ToString();

            }
            else
            {
                suresults = null;
            }

            return suresults;
        }
        public int deleteSurvey(string adminNo) {
            StringBuilder sqlStr = new StringBuilder();
            int result = 0;
            SqlCommand sqlCmd = new SqlCommand();

            sqlStr.AppendLine("DELETE From InternshipSurvey");
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