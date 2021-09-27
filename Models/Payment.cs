using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iTravel.Models
{
    public class Payment
    {
        public Payment()
        {
        }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
        public double creditCardNUmber { get; set; }
        public string expiryDate { get; set; }
        public double ccv { get; set; }
        public string cardHolderName { get; set; }
        public string hasPaid { get; set; }
        public string adminNo { get; set; }
    }
}