using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    public class Advertisement : Revenue
    {
        //png file name
        public string imgFile {get; set;}
        //size of advertisement
        public string adSize {get; set;}
        //total cost of advertisement
        public float cost {get; set;}
        //how much they've paid so far
        public float paid {get; set;}
        //how much they have left to pay
        public float due {get; set;}

        public Advertisement() : base() {
            imgFile = "";
            adSize = "";
            cost = 0;
            paid = 0;
            due = 0;
        }
    }
}