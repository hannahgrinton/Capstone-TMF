using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    public class Advertisement
    {
        [Key]
        public int adId {get; set;}
        //date of advertisement request (year is most important, as it will be appended to a list)
        [Required]
        [Display(Name="Date")]
        public DateTime date {get; set;}
        //additional notes
        [MaxLength(250)]
        [Display(Name="Notes")]
        public string notes {get; set;}
        //png file name
        [MaxLength(50)]
        [Display(Name="Image File")]
        public string imgFile {get; set;}
        //size of advertisement
        [Required]
        [MaxLength(100)]
        [Display(Name="Advertisement Size")]
        public string adSize {get; set;}
        //total cost of advertisement
        [Required]
        [Display(Name="Total Cost")]
        public float cost {get; set;}
        //how much they've paid so far
        [Display(Name="Amount Paid")]
        public float? paid {get; set;}
        //how much they have left to pay
        [Required]
        [Display(Name="Amount Due")]
        public float due {get; set;}
    }
}