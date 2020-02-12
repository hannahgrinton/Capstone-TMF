using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
namespace TMFadmin.Models
{
    public class RevenueManager : DbContext
    {
        public DbSet<Address> address { get; set; }
        public DbSet<AddressRelations> addressRels { get; set; }
        public DbSet<Advertisement> advertisement { get; set; }
        public DbSet<AdvertRelations> advertRels { get; set; }
        public DbSet<Award> awards { get; set; }
        public DbSet<Donation> donation { get; set; }
        public DbSet<DonationRelations> donRels { get; set; }
        public DbSet<Fund> fund { get; set; }
        public DbSet<Sponsor> sponsor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySQL(Connection.CONNECTION_STRING);
        }
    }
}