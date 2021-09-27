using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace iTravel.Models
{
    public class createTrip
    {
        public createTrip()
            {
            }
        //timeDeposit stuff (for my own ref)
        public int tripId { get; set; }
        public string tripName { get; set; }
        public string staffNo { get; set; }
        public string location { get; set; }
        public string description { get; set; }
        public string tripImage { get; set; }
        public string startDate { get; set; }
        public string EndDate { get; set; }
        public double cost { get; set; }
        public string typeOfTrip { get; set; }
        public string tripSummary { get; set; }
        public string tripAirline { get; set; }
        public string tripItinerary { get; set; }
        public string tripSelection { get; set; }
        public string tripIMG { get; set; }
        public string tripStudentList { get; set; }




    }
}