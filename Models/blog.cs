using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTravel.Models
{
    public class blog
    {
       public blog()
        {
        }
        public int blogID { get; set; }
        public string blogTitle { get; set; }
        public string blogDesc { get; set; }
        public string blogUser { get; set; }
        public DateTime blogDateTime { get; set; }
        public string blogLocation { get; set; }
        public string blogImage { get; set; }
        public string blogStatus { get; set; }
        public int blogReports { get; set; }
    }
}