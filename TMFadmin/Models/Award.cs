using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    //award class
    public class Award
    {
        [Key]
        public int awardId {get; set;}
        [MaxLength(100)]
        [Display(Name="Recipient")]
        public string recipient {get; set;}
        [MaxLength(4)]
        [Display(Name="Year Awarded")]
        public string year {get; set;}
        public int fundId {get; set;}
    }
}