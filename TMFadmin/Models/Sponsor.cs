using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    public class Sponsor
    {   
        [Key]
        private int sponsorId {get; set;}
        //first name
        [Required]
        [MaxLength(50)]
        [Display(Name="First Name")]
        public string firstname {get; set;}
        //last name
        [Required]
        [MaxLength(50)]
        [Display(Name="Last Name")]
        public string lastname {get; set;}
        //phone number
        [Required]
        [MaxLength(14)]
        [Display(Name="Phone No.")]
        public string phone {get; set;}
        //fax number
        [MaxLength(14)]
        [Display(Name="Fax No.")]
        public string fax {get; set;}
        //email address
        [MaxLength(70)]
        [Display(Name="Email Address")]
        public string email {get; set;}
        //whether they are active revenue sources or wish to not be solicited
        [Required]
        [MaxLength(10)]
        [Display(Name="Activity")]
        public string activity {get; set;} = "active";
        //additional notes
        [MaxLength(250)]
        [Display(Name="Notes")]
        public string notes {get; set;}

    }
}