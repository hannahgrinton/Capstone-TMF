using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    public class AddressRelations
    {
        [Key]
        public int relationId {get; set;}
        [MaxLength(10)]
        [Display(Name="Address Type")]
        public string type {get; set;}
        public int sponsorId {get; set;}
        public int addressId {get; set;}
    }
}