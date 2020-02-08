using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    //abstract class for all sources of revenue
    public abstract class Revenue {
        //first name
        protected string firstname {get; set;}
        //last name
        protected string lastname {get; set;}
        //mailing address
        protected Address mailing;
        //billing address
        protected Address billing;
        //phone number
        protected string phone {get; set;}
        //fax number
        protected string fax {get; set;}
        //email address
        protected string email {get; set;}
        //date of donation/advertisement request (year is most important, as it will be appended to a list)
        protected DateTime date {get; set;}
        //whether they are active revenue sources or wish to not be solicited
        protected string activity {get; set;} = "active";
        //additional notes
        protected string notes {get; set;}

        public Revenue() {
            firstname  = "";
            lastname = "";
            mailing = new Address();
            billing = new Address();
            phone = "";
            fax = "";
            email = "";
        }
    } 
}