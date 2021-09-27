using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTravel.DAL
{
    public class studentTripRetrieve
    {

        public studentTripRetrieve()
        {
        }
        public string tripName { get; set; }
        public string tripDesc { get; set; }
        public String  tripCost { get; set; }
        public String tripStartDate { get; set; }
        public String tripEndDate { get; set; }
        public string tripId { get; set;}
        public string triptype { get; set; }
    }
}