using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    public class Donation
    {
        [Key]
        public int donId {get; set;}
        //date of donation request
        [Required]
        [Display(Name="Date")]
        public DateTime date {get; set;}
        //additional notes
        [MaxLength(250)]
        [Display(Name="Notes")]
        public string notes {get; set;}
        //charitable receipt sent or not
        [Required]
        [Display(Name="Chariable Receipt Sent")]
        public int receipt {get; set;} = 0;
        //amount donated
        [Required]
        [Display(Name="Amount Donated")]
        public float amount {get; set;}
        //id of fund donating to
        public int? fundId {get; set;}
    }
}