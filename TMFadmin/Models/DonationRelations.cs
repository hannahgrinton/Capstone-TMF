using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    public class DonationRelations
    {
        [Key]
        public int relationId {get; set;}
        public int sponsorId {get; set;}
        public int donId {get; set;}
    }
}