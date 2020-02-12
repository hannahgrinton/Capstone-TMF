using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    public class AdvertRelations
    {
        [Key]
        public int relationId {get; set;}
        public int sponsorId {get; set;}
        public int adId {get; set;}
    }
}