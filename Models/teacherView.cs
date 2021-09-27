using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTravel.Models
{
    public class teacherView
    {
        public teacherView()
        {
        }
        public string getTripName { get; set; }
        public string getStaffNo { get; set; }
        public string getLocation { get; set; }
        public string getDescription { get; set; }
        //public string tripImg { get; set; } not added in database too
        public DateTime getStartDate { get; set; }
        public DateTime getEndDate { get; set; }
        public double getCost { get; set; }
        public string getTypeOfTrip { get; set; }
        public string tripSummary { get; set; }
        public string tripAirline { get; set; }
        public string tripItinerary { get; set; }
        public string tripSelection { get; set; }

    }
}