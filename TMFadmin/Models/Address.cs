using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    //address class
    public class Address
    {
        private string _address {get; set;}
        private string _city {get; set;}
        private string _province {get; set;}
        private string _postal {get; set;}
        private string _country {get; set;}

        public Address() {
            _address = "";
            _city = "";
            _province = "";
            _postal = "";
            _country = "Canada";
        }
    }
}