using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    //address class
    public class Address
    {
        [Key]
        public int addressId {get; set;}
        [Required]
        [MaxLength(50)]
        [Display(Name="First Name")]
        public string firstname {get; set;}
        [Required]
        [MaxLength(50)]
        [Display(Name="Last Name")]
        public string lastname {get; set;}
        [Required]
        [MaxLength(100)]
        [Display(Name="Address")]
        public string address {get; set;}
        [Required]
        [MaxLength(50)]
        [Display(Name="City")]
        public string city {get; set;}
        [Required]
        [MaxLength(2)]
        [Display(Name="Province")]
        public string province {get; set;} = "NS";
        [Required]
        [MaxLength(7)]
        [Display(Name="Postal Code")]
        public string postal {get; set;}
        [Required]
        [MaxLength(20)]
        [Display(Name="Country")]
        public string country {get; set;} = "Canada";

    }
}