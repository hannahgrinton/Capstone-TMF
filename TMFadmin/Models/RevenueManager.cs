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
        //list to hold addresses for current sponsor
        public List<Address> addresses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySQL(Connection.CONNECTION_STRING);
        }
        //------------------------------------------------------------- Sponsor Work
        //get current sponsor
        public Sponsor getSponsor(int mySponsorId) {
            return sponsor.Single(item => item.sponsorId == mySponsorId);
        }
        //get newest sponsor
        public Sponsor newestSponsor() {
            return sponsor.Last();
        }
        //get newest sponsor's id
        public int newID() {
            Sponsor sponsor = newestSponsor();
            int id = sponsor.sponsorId;
            return id;
        }
        //alphabetize by lastname
        public List<Sponsor> alphaSponsorLname() {
            List<Sponsor> sponsors = sponsor.OrderBy(l => l.company).ToList();
            return sponsors;
        }
        //get select list of sponsor names
        public SelectList getList() {
            List<Sponsor> listData = sponsor.OrderBy(c => c.company).ToList();
            return new SelectList(listData, "sponsorId", "company");
        }
        //get select list of sponsor names with selected item matching parameter
        public SelectList getList(int mySponsorId) {
            string id = Convert.ToString(mySponsorId);
            //using linq methods to query data and return as a list
            List<Sponsor> listData = sponsor.OrderBy(c => c.company).ToList();
            SelectList myList = new SelectList(listData, "sponsorId", "company");
            var selected = myList.Where(x => x.Value == id).First();
            selected.Selected = true;
            return myList;
        }
        //get list of donations of sponsor
        public void getSponsorDon(int mySponsorId) {
            //list of relations that pertain to sponsor
            List<DonationRelations> rels = donRels.Where(item => item.sponsorId == mySponsorId).ToList();
            //loop through all donations
            donations = new List<Donation> {};
            foreach (var item in rels) 
            {
                //if donation id matches relation id, add it to list
                Donation myDonation = new Donation();
                myDonation = donation.Single(don => don.donId == item.donId);
                donations.Add(myDonation);
            }
        }
        //get list of ads of sponsor
        public void getSponsorAd(int mySponsorId) {
            //list of relations that pertain to sponsor
            List<AdvertRelations> rels = advertRels.Where(item => item.sponsorId == mySponsorId).ToList();
            //loop through all ads
            adverts = new List<Advertisement> {};
            foreach (var item in rels) 
            {
                Advertisement advert = new Advertisement();
                //if add id matches relation id, add it to list
                advert = advertisement.Single(ad => ad.adId == item.adId);
                adverts.Add(advert);
            }
        }
        //get list of addresses of sponsor
        public void getSponsorAddresses(int mySponsorId) {
            //list of relations that pertain to sponsor
            List<AddressRelations> rels = addressRels.Where(item => item.sponsorId == mySponsorId).ToList();
            //loop through all addresses
            addresses = new List<Address> {};
            foreach (var item in rels) 
            {
                Address myAddress = new Address();
                //if address id matches relation id, add it to list
                myAddress = address.Single(ad => ad.addressId == item.addressId);
                addresses.Add(myAddress);
            }
        }

        //----------------------------------------------------------------- Advertisement Work
        //get list of adverts, sorted by ID
        public List<Advertisement> getAdvertisementsById() {
            List<Advertisement> advertisements = advertisement.OrderBy(l => l.adId).ToList();
            return advertisements;
        }
        //get current award
        public Advertisement getAdvertisement(int myAdId) {
            return advertisement.Single(item => item.adId == myAdId);
        }





        //----------------------------------------------------------------- Donation Work
        //get list of donations, sorted by date
        public List<Donation> getDonationsByDate() {
            List<Donation> donations = donation.OrderBy(l => l.date).ToList();
            return donations;
        }
        //get newest donation
        public Donation newestDonation() {
            return donation.Last();
        }
        //get newest donation id
        public int newDonId() {
            Donation donation = newestDonation();
            int id = donation.donId;
            return id;
        }
        //get donation by id
        public Donation getDonation(int myDonationId) {
            return donation.Single(item => item.donId == myDonationId);
        }
        //get relation with sponsor based on the id of the donation
        public DonationRelations getDonationRelations(int myDonationId) {
            return donRels.Single(item => item.donId == myDonationId);
        }

        //----------------------------------------------------------------- Award Work
        //get list of awards, sorted by ID
        public List<Award> getAwardsById() {
            List<Award> award = awards.OrderBy(l => l.awardId).ToList();
            return award;
        }

        //get current award
        public Award getAward(int myAwardId) {
            return awards.Single(item => item.awardId == myAwardId);
        }



        //----------------------------------------------------------------- Fund Work
        //get list of funds, sorted by ID
        public List<Fund> getFundsById() {
            List<Fund> funds = fund.OrderBy(l => l.fundId).ToList();
            return funds;
        }
        //get select list of funds, set default to N/A     
        public SelectList getFundList() {
            List<Fund> listData = fund.OrderBy(c => c.fundId).ToList();
            Fund blank = new Fund();
            blank.fundId = 0;
            blank.fundName = "N/A";
            blank.dateCreated = DateTime.Now;
            listData.Add(blank);
            SelectList myList = new SelectList(listData, "fundId", "fundName");
            var selected = myList.Where(x => x.Value == "0").First();
            selected.Selected = true;
            return myList;
        }        
        //get fund by id
        public Fund getFund(int id) {
            return fund.Single(item => item.fundId == id);
        }
        
        
        //----------------------------------------------------------------- Address Work
        //get list of addresses sorted by ID
        public List<Address> getAddressesById() {
            List<Address> addresses = address.OrderBy(l => l.addressId).ToList();
            return addresses;
        }
        //get newest address
        public Address newestAddress() {
            return address.Last();
        }

        //get current address
        public Address getAddress(int myAddressId) {
            return address.Single(item => item.addressId == myAddressId);
        }

    }
}