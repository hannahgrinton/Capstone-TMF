using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    public class Fund {
        [Key]
        public int fundId {get;set;}
        //who created the fund/award
        [MaxLength(100)]
        [Display(Name="Creator")]
        public string creator {get; set;}
        //date of creation
        [Required]
        [Display(Name="Date Created")]
        public DateTime dateCreated {get; set;}
        //additional notes - such as if the fund was used for something besides an award
        [MaxLength(250)]
        [Display(Name="Notes")]
        public string notes {get; set;}

    }
}