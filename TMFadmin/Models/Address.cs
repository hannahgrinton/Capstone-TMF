using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    //address class
    public class Address
    {
        public int id {get;}
        public string address {get; set;}
        public string city {get; set;}
        public string province {get; set;}
        public string postal {get; set;}
        public string country {get; set;}

        public Address() {
            id = 0;
            address = "";
            city = "";
            province = "";
            postal = "";
            country = "Canada";
        }
    }
}