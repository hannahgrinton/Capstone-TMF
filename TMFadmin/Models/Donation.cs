using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    public class Donation
    {
        [Key]
        public int donId {get;set;}
        //date of donation request (year is most important, as it will be appended to a list)
        [Required]
        [Display(Name="Date")]
        protected DateTime date {get; set;}
        //additional notes
        [MaxLength(250)]
        [Display(Name="Notes")]
        protected string notes {get; set;}
        //charitable receipt sent or not
        [Required]
        [Display(Name="Chariable Receipt Sent")]
        public bool receipt {get; set;}
        //amount donated
        [Required]
        [MaxLength(10)]
        [Display(Name="Amount Donated")]
        public float amount {get; set;}
        //id of fund donating to
        public int fundId {get; set;}
    }
}