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
        
        //list to hold donations for current sponsor
        public List<Donation> donations { get; set; }
        //list to hold ads for current sponsor
        public List<Advertisement> adverts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySQL(Connection.CONNECTION_STRING);
        }
        //------------------------------------------------------------- Sponsor Work
        //get current sponsor
        public Sponsor getSponsor(int mySponsorId) {
            return sponsor.Single(item => item.sponsorId == mySponsorId);
        }
        //alphabetize by lastname
        public List<Sponsor> alphaSponsorLname() {
            List<Sponsor> sponsors = sponsor.OrderBy(l => l.lastname).ToList();
            return sponsors;
        }
        //alphabetize by firstname
        public List<Sponsor> alphaSponsorFname() {
            List<Sponsor> sponsors = sponsor.OrderBy(l => l.firstname).ToList();
            return sponsors;
        }
        //get list of donations of sponsor
        public void getSponsorDon(int mySponsorId) {
            //list of relations that pertain to sponsor
            List<DonationRelations> rels = donRels.Where(item => item.sponsorId == mySponsorId).ToList();
            //loop through all donations
            foreach (var item in rels) 
            {
                //if donation id matches relation id, add it to list
                Donation don = new Donation();
                don = donation.Single(d => d.donId == item.donId);
                donations.Add(don);
            }
        }
        //get list of ads of sponsor
        public void getSponsorAd(int mySponsorId) {
            //list of relations that pertain to sponsor
            List<AdvertRelations> rels = advertRels.Where(item => item.sponsorId == mySponsorId).ToList();
            //loop through all ads
            foreach (var item in rels) 
            {
                Advertisement advert = new Advertisement();
                //if add id matches relation id, add it to list
                advert = advertisement.Single(ad => ad.adId == item.adId);
                adverts.Add(advert);
            }
        }
    }
}