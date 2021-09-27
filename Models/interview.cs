using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTravel.Models
{
    public class interview
    {

        public string idTripId { get; set; }
        public string idAdminNo { get; set; }
        public string idStaffName { get; set; }
        public string idStaffHP { get; set; }
        public string idMeetDate { get; set; }
        public string idMeetTime { get; set; }
        public string idMeetLocation { get; set; }
        public string idAdditionalInfo { get; set; }
    }

    public class staff
    {
        public string sStaffName { get; set; }
        public string sStaffHP { get; set; }
    }

}