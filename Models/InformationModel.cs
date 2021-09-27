using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTravel.Models
{
    // For Profile page
    public class StudentInformation
    {
        public string tripStatus { get; set; }
        
        public string adminNo { get; set; }
        public string studentName { get; set; }
        public string studentGender { get; set; }
        public string studentAddress { get; set; }
        public string studentCCA { get; set; }
        public string DOB { get; set; }
        public string studentNationality { get; set; }
        public string studentCourse { get; set; }
        public string PEMGroup { get; set; }
        public string studentHP { get; set; }
        public string Bio { get; set; }

        public string studentEmail { get; set; }
        public string studentGPA { get; set; }
        public string IC_No { get; set; }
        public string passportNo { get; set; }
        public string passportExpDate { get; set; }
        public string applicationStatus { get; set; }

        public string tripHist { get; set; }
        
    }

    // For Profile History
    public class StudentTripHistory
    {
        public string tripName { get; set; }
        public string tripType { get; set; }
        public string tripLocation { get; set; }
        public string tripStartDate { get; set; }
        public string tripEndDate { get; set; }
    }

}