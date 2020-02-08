using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    //abstract class for all sources of revenue
    public abstract class Revenue {
        protected int id {get;}
        //date of donation/advertisement request (year is most important, as it will be appended to a list)
        protected DateTime date {get; set;}
        //additional notes
        protected string notes {get; set;}
        protected Sponsor sponsor;
        public Revenue() {
            id = 0;
            date = DateTime.Now;
            notes = "";
            sponsor = new Sponsor();
        }
    } 
}