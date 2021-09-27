using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace iTravel.DAL
{
    public class TripSurveyDAO
    {
        string DBConnect = ConfigurationManager.ConnectionStrings["iTravelDBConnectionString"].ConnectionString;

        public int addSurvey(String tripId, String tripName, String tripType, String diploma, String PEMGroup, String adminNo, String fullName, String gender, String DOB, String contact, String address, String citizenship, String passportNo, String passportExp, 
            String waitList, String GPA, String CCA, String leadership, String offence, String PSEABalance, String fasopApply, String fasopHist, String buddy, String allergy, String medCondition, String medication)
        {

            StringBuilder sqlStr = new StringBuilder();
            int result = 0;

            sqlStr.AppendLine("INSERT INTO surveyResults (tripId, tripName, tripType, diploma, PEMGroup, adminNo, fullName, gender, DOB, contact, address, citizenship, passportNo, ");
            sqlStr.AppendLine("passportExp, waitList, GPA, CCA, leadership, offenceCommitted, PSEABalance, fasopApply, fasopHist, buddy, allergy, medicalCondition, medication)");
            sqlStr.AppendLine("VALUES (@paraTripId, @paraTripName, @paraTripType, @paraDiploma, @paraPEMGroup, @paraAdminNo, @paraFullName, @paraGender, @paraDOB, @paraContact, @paraAddress, @paraCitizenship, @paraPassportNo, @paraPassportExp,");
            sqlStr.AppendLine("@paraWaitList, @paraGPA, @paraCCA, @paraLeadership, @paraOffenceCommitted, @paraPSEABalance, @paraFasopApply, @paraFasopHist, @paraBuddy, @paraAllergy, @paraMedicalCondition, @paraMedication)");

            SqlConnection myConn = new SqlConnection(DBConnect);
            SqlCommand sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);

            sqlCmd = new SqlCommand(sqlStr.ToString(), myConn);
            sqlCmd.Parameters.AddWithValue("@paraTripId", tripId);
            sqlCmd.Parameters.AddWithValue("@paraTripName", tripName);
            sqlCmd.Parameters.AddWithValue("@paraTripType", tripType);
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
            sqlCmd.Parameters.AddWithValue("@paraOffenceCommitted", offence);
            sqlCmd.Parameters.AddWithValue("@paraPSEABalance", PSEABalance);
            sqlCmd.Parameters.AddWithValue("@paraFasopApply", fasopApply);
            sqlCmd.Parameters.AddWithValue("@paraFasopHist", fasopHist);
            sqlCmd.Parameters.AddWithValue("@paraBuddy", buddy);
            sqlCmd.Parameters.AddWithValue("@paraAllergy", allergy);
            sqlCmd.Parameters.AddWithValue("@paraMedicalCondition", medCondition);
            sqlCmd.Parameters.AddWithValue("@paraMedication", medication);


            myConn.Open();
            result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}