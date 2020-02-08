using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    public class Donation : Revenue
    {
        //what they're donating to 
        public Fund fund;
        //charitable receipt sent or not
        public bool receipt {get; set;}
        //amount donated
        public float amount {get; set;}
        //total amount donated from all time
        public float total {get; set;}

        public Donation() : base() {
            fund = new Fund();
            receipt = false;
            amount  = 0;
            total = 0;
        }

    }
}