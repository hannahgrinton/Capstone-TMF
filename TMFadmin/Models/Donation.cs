using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    public class Donation : Revenue
    {
        //list of amounts donated - coincides with years donated
        public float[] history {get; set;}
        //what they're donating to 
        public Fund fund;
        //charitable receipt sent or not
        public bool receipt {get; set;}
        //list of years donated
        public DateTime[] yearsDonated {get; set;}
        //amount donated
        public float amount {get; set;}
        //total amount donated from all time
        public float total {get; set;}

        public Donation() : base() {
            history = null;
            fund = new Fund();
            receipt = false;
            amount  = 0;
            total = 0;
        }

    }
}