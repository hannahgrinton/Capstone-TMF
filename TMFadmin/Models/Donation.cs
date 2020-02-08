using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    public class Donation : Revenue
    {
        private float[] _history {get; set;}
        private Fund _fund;
        private bool _receipt {get; set;}
        private DateTime[] _yearsDonated {get; set;}
        private float _amount {get; set;}
        private float _total {get; set;}

        public Donation() : base() {
            _history = null;
            _fund = new Fund();
            _receipt = false;
            _amount  = 0;
            _total = 0;
        }

    }
}