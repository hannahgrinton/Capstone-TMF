using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    //address class
    public class Address
    {
        public string address {get; set;}
        public string city {get; set;}
        public string province {get; set;}
        public string postal {get; set;}
        public string country {get; set;}

        public Address() {
            address = "";
            city = "";
            province = "";
            postal = "";
            country = "Canada";
        }
    }
}