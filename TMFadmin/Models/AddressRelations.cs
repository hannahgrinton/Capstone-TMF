using System;
using System.ComponentModel.DataAnnotations;
namespace TMFadmin.Models
{
    public class AddressRelations
    {
        [Key]
        public int relationId {get; set;}
        public int sponsorId {get; set;}
        public int addressId {get; set;}
    }
}