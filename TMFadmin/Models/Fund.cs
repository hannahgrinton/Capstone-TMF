using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    public class Fund {
        //who created the fund/award
        public string creator {get; set;}
        //date of creation
        public DateTime dateCreated {get; set;}
        //list of donors
        public Donation[] donors {get; set;}
        //festival years where fund was used
        public DateTime[] yearsUsed {get; set;}
        //list of who has recieved the fund/award - if applicable
        public string[] recipients {get; set;}
        //additional notes - such as if the fund was used for something besides an award
        public string notes {get; set;}

        public Fund() {
            creator = "";
            donors = null;
            notes = "";
        }
    }
}