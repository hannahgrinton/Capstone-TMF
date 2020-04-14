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

        /*
        *
        *   Sponsor Work
        *
        */



        
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

        //---
        // converts 'on' value set by null value checkbox post, replacing it with empty string
        public string[] convertOnToNull(string[] myStrings){
            for(var i = 0; i < myStrings.Length; i++){
                if(myStrings[i]=="on"){
                    myStrings[i] = "";
                }
            }
            return myStrings;
        }


        // return a list of all sponsors in database, sorted by provided string value
        public List<Sponsor> sortSponsorsByMe(string mySorting="id_asc") {

            List<Sponsor> listData;            

            switch(mySorting)
                {
                case "id_asc":
                    listData = sponsor.OrderBy(s => s.sponsorId).ToList();
                    break;
                case "id_desc":
                    listData = sponsor.OrderByDescending(s => s.sponsorId).ToList();
                    break;
                case "name_asc":
                    listData = sponsor.OrderBy(s => s.company).ToList();
                    break;
                case "name_desc":
                    listData = sponsor.OrderByDescending(s => s.company).ToList();
                    break;
                case "phone_asc":
                    listData = sponsor.OrderBy(s => s.phone).ToList();
                    break;
                case "phone_desc":
                    listData = sponsor.OrderByDescending(s => s.phone).ToList();
                    break;
                case "fax_asc":
                    listData = sponsor.OrderBy(s => s.fax).ToList();
                    break;
                case "fax_desc":
                    listData = sponsor.OrderByDescending(s => s.fax).ToList();
                    break;
                case "email_asc":
                    listData = sponsor.OrderBy(s => s.email).ToList();
                    break;
                case "email_desc":
                    listData = sponsor.OrderByDescending(s => s.email).ToList();
                    break;
                case "activity_asc":
                    listData = sponsor.OrderBy(s => s.activity).ToList();
                    break;
                case "activity_desc":
                    listData = sponsor.OrderByDescending(s => s.activity).ToList();
                    break;
                case "notes_asc":
                    listData = sponsor.OrderBy(s => s.notes).ToList();
                    break;
                case "notes_desc":
                    listData = sponsor.OrderByDescending(s => s.notes).ToList();
                    break;
                default:
                    listData = sponsor.OrderBy(s => s.sponsorId).ToList();
                    break;
                
            }

            return listData;

        }


        public List<Sponsor> filterSponsorList(List<Sponsor> mySponsors, string[] myNames, string[] myPhones
                                                , string[] myFaxes, string[] myEmails, string[] myActivities, string[] myNotes=null){
            //List<string> searchString = new List<string>(){"Jam Inc/","Not Jam","Baby Blue"};
            List<string> searchNames = new List<string>();
            List<string> searchPhones = new List<string>();
            List<string> searchFaxes = new List<string>();
            List<string> searchEmails = new List<string>();
            List<string> searchActivities = new List<string>();
            List<string> searchNotes = new List<string>();
            List<Sponsor> filteredSponsor;



            // Create lists from arrays
            if(myNotes!=null){                
                searchNames=myNames.ToList();
                searchPhones=myPhones.ToList();
                searchFaxes=myFaxes.ToList();
                searchEmails=myEmails.ToList();
                searchActivities=myActivities.ToList();
                searchNotes=myNotes.ToList();
            }  
            // apply filter to sponsors list, return filtered list of sponsors
            if (myNotes!=null)
            {
                filteredSponsor = mySponsors.Where(s => (searchNames.Contains(s.company) || (string.IsNullOrEmpty(s.company) && searchNames.Contains(string.Empty))) &&
                                                        (searchPhones.Contains(s.phone) || (string.IsNullOrEmpty(s.phone) && searchPhones.Contains(string.Empty))) &&
                                                        (searchFaxes.Contains(s.fax) || (string.IsNullOrEmpty(s.fax) && searchFaxes.Contains(string.Empty))) &&
                                                        (searchEmails.Contains(s.email) || (string.IsNullOrEmpty(s.email) && searchEmails.Contains(string.Empty))) &&
                                                        (searchActivities.Contains(s.activity) || (string.IsNullOrEmpty(s.activity) && searchActivities.Contains(string.Empty))) &&
                                                        (searchNotes.Contains(s.notes) || (string.IsNullOrEmpty(s.notes) && searchNotes.Contains(string.Empty)))
                                                        ).ToList();
            } else{
                filteredSponsor = mySponsors;
            }
            return filteredSponsor;            
        }

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
        //get list of relations between sponsor and donation
        public List<DonationRelations> getSponsorDonRels(int mySponsorId) {
            List<DonationRelations> rels = donRels.Where(item => item.sponsorId == mySponsorId).ToList();
            return rels;
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
        //get list of relations between sponsor and donation
        public List<AdvertRelations> getSponsorAdRels(int mySponsorId) {
            List<AdvertRelations> rels = advertRels.Where(item => item.sponsorId == mySponsorId).ToList();
            return rels;
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
        //get list of relations between sponsor and address
        public List<AddressRelations> getSponsorAddressRels(int mySponsorId) {
            List<AddressRelations> rels = addressRels.Where(item => item.sponsorId == mySponsorId).ToList();
            return rels;
        }
        /*
        *
        * Advertisement Work
        * 
        */

        // -------------------------------

        // return a list of all advertisements in database, sorted by provided string value
        public List<Advertisement> sortAdsByMe(string mySorting="id_asc") {

            List<Advertisement> listData;            

            switch(mySorting)
                {
                case "id_asc":
                    listData = advertisement.OrderBy(a => a.adId).ToList();
                    break;
                case "id_desc":
                    listData = advertisement.OrderByDescending(a => a.adId).ToList();
                    break;
                case "date_asc":
                    listData = advertisement.OrderBy(a => a.date).ToList();
                    break;
                case "date_desc":
                    listData = advertisement.OrderByDescending(a => a.date).ToList();
                    break;
                case "notes_asc":
                    listData = advertisement.OrderBy(a => a.notes).ToList();
                    break;
                case "notes_desc":
                    listData = advertisement.OrderByDescending(a => a.notes).ToList();
                    break;
                case "img_asc":
                    listData = advertisement.OrderBy(a => a.imgFile).ToList();
                    break;
                case "img_desc":
                    listData = advertisement.OrderByDescending(a => a.imgFile).ToList();
                    break;
                case "size_asc":
                    listData = advertisement.OrderBy(a => a.adSize).ToList();
                    break;
                case "size_desc":
                    listData = advertisement.OrderByDescending(a => a.adSize).ToList();
                    break;
                case "cost_asc":
                    listData = advertisement.OrderBy(a => a.cost).ToList();
                    break;
                case "cost_desc":
                    listData = advertisement.OrderByDescending(a => a.cost).ToList();
                    break;
                case "paid_asc":
                    listData = advertisement.OrderBy(a => a.paid).ToList();
                    break;
                case "paid_desc":
                    listData = advertisement.OrderByDescending(a => a.paid).ToList();
                    break;
                case "due_asc":
                    listData = advertisement.OrderBy(a => a.due).ToList();
                    break;
                case "due_desc":
                    listData = advertisement.OrderByDescending(a => a.due).ToList();
                    break;
                default:
                    listData = advertisement.OrderBy(a => a.adId).ToList();
                    break;
                
            }

            return listData;

        }


        public List<Advertisement> filterAdList(List<Advertisement> myAds, string[] myDates, string[] myNotes
                                                , string[] myImgFiles, string[] myAdSizes, string[] myCosts, 
                                                string[] myPaid, string[] myDue=null)
                                                {

            List<string> searchDates = new List<string>();
            List<string> searchNotes = new List<string>();
            List<string> searchImgFiles = new List<string>();
            List<string> searchAdSizes = new List<string>();
            List<string> searchCosts = new List<string>();
            List<string> searchPaid = new List<string>();
            List<string> searchDue = new List<string>();
            List<Advertisement> filteredAd;

            // Create lists from arrays
            if(myDue!=null){                
                searchDates=myDates.ToList();
                searchNotes=myNotes.ToList();
                searchImgFiles=myImgFiles.ToList();
                searchAdSizes=myAdSizes.ToList();
                searchCosts=myCosts.ToList();
                searchPaid=myPaid.ToList();
                searchDue=myDue.ToList();
            }  
            // apply filter to ads list, return filtered list of sponsors
            if (myDue!=null)
            {
                filteredAd = myAds.Where(a => (searchDates.Contains(a.date.ToString()) || (string.IsNullOrEmpty(a.date.ToString()) && searchDates.Contains(string.Empty))) &&
                                                        (searchNotes.Contains(a.notes) || (string.IsNullOrEmpty(a.notes) && searchNotes.Contains(string.Empty))) &&
                                                        (searchImgFiles.Contains(a.imgFile) || (string.IsNullOrEmpty(a.imgFile) && searchImgFiles.Contains(string.Empty))) &&
                                                        (searchAdSizes.Contains(a.adSize) || (string.IsNullOrEmpty(a.adSize) && searchAdSizes.Contains(string.Empty))) &&
                                                        (searchCosts.Contains(a.cost.ToString()) || (string.IsNullOrEmpty(a.cost.ToString()) && searchCosts.Contains(string.Empty))) &&
                                                        (searchPaid.Contains(a.paid.ToString()) || (string.IsNullOrEmpty(a.paid.ToString()) && searchPaid.Contains(string.Empty))) &&
                                                        (searchDue.Contains(a.due.ToString()) || (string.IsNullOrEmpty(a.due.ToString()) && searchDue.Contains(string.Empty)))
                                                        ).ToList();
            } else{
                filteredAd = myAds;
            }
            return filteredAd;            
        }
        //-----------------

        //get list of adverts, sorted by ID
        public List<Advertisement> getAdvertisementsById() {
            List<Advertisement> advertisements = advertisement.OrderBy(l => l.adId).ToList();
            return advertisements;
        }
        //get newest ad
        public Advertisement newestAdvert() {
            return advertisement.Last();
        }
        //get newest advert id
        public int newAdId() {
            Advertisement advert = newestAdvert();
            int id = advert.adId;
            return id;
        }
        //get ad by id
        public Advertisement getAdvertisement(int id) {
            return advertisement.Single(item => item.adId == id);
        }
        //get sponsor relation
        public AdvertRelations getAdvertRelations(int id) {
            return advertRels.Single(item => item.adId == id);
        }
        /*
        *
        *   Donation Work
        *
        */
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

        // ------------------------------ SORT / FILTER----------------------

        // return a list of all sponsors in database, sorted by provided string value
        public List<Donation> sortDonationsByMe(string mySorting="id_asc") {

            List<Donation> listData;            

            switch(mySorting)
                {
                case "id_asc":
                    listData = donation.OrderBy(d => d.donId).ToList();
                    break;
                case "id_desc":
                    listData = donation.OrderByDescending(d => d.donId).ToList();
                    break;
                case "date_asc":
                    listData = donation.OrderBy(d => d.date).ToList();
                    break;
                case "date_desc":
                    listData = donation.OrderByDescending(d => d.date).ToList();
                    break;
                case "notes_asc":
                    listData = donation.OrderBy(d => d.notes).ToList();
                    break;
                case "notes_desc":
                    listData = donation.OrderByDescending(d => d.notes).ToList();
                    break;
                case "receipt_asc":
                    listData = donation.OrderBy(d => d.receipt).ToList();
                    break;
                case "receipt_desc":
                    listData = donation.OrderByDescending(d => d.receipt).ToList();
                    break;
                case "amount_asc":
                    listData = donation.OrderBy(d => d.amount).ToList();
                    break;
                case "amount_desc":
                    listData = donation.OrderByDescending(d => d.amount).ToList();
                    break;
                default:
                    listData = donation.OrderBy(d => d.donId).ToList();
                    break;
                
            }

            return listData;

        }


        public List<Donation> filterDonationList(List<Donation> myDonations, string[] myDates, string[] myNotes
                                                , string[] myReceipts, string[] myAmounts=null){
            List<string> searchDates = new List<string>();
            List<string> searchNotes = new List<string>();
            List<string> searchReceipts = new List<string>();
            List<string> searchAmounts = new List<string>();
            List<Donation> filteredDonation;



            // Create lists from arrays
            if(myNotes!=null){                
                searchDates=myDates.ToList();
                searchNotes=myNotes.ToList();
                searchReceipts=myReceipts.ToList();
                searchAmounts=myAmounts.ToList();
            }  
            // apply filter to sponsors list, return filtered list of sponsors
            if (myAmounts!=null)
            {
                filteredDonation = myDonations.Where(
                    d => (searchDates.Contains(d.date.ToString()) || (string.IsNullOrEmpty(d.date.ToString()) && searchDates.Contains(string.Empty))) &&
                                                        (searchNotes.Contains(d.notes) || (string.IsNullOrEmpty(d.notes) && searchNotes.Contains(string.Empty))) &&
                                                        (searchReceipts.Contains(d.receipt.ToString()) || (string.IsNullOrEmpty(d.receipt.ToString()) && searchReceipts.Contains(string.Empty))) &&
                                                        (searchAmounts.Contains(d.amount.ToString()) || (string.IsNullOrEmpty(d.amount.ToString()) && searchAmounts.Contains(string.Empty)))
                                                        ).ToList();
            } else{
                filteredDonation = myDonations;
            }
            return filteredDonation;            
        }


        /*
        *
        *   Award Work
        *
        */
        //get list of awards, sorted by ID
        public List<Award> getAwardsById() {
            List<Award> award = awards.OrderBy(l => l.awardId).ToList();
            return award;
        }
        //get award by id
        public Award getAward(int id) {
            return awards.Single(item => item.awardId == id);
        }
        /*
        *
        *   Fund Work
        *
        */
        //get list of funds, sorted by ID
        public List<Fund> getFundsById() {
            List<Fund> funds = fund.OrderBy(l => l.fundId).Where(f => f.fundId > 0).ToList();
            return funds;
        }
        //get select list of funds, set default to N/A     
        public SelectList getFundList() {
            List<Fund> listData = fund.OrderBy(c => c.fundId).ToList();
            SelectList myList = new SelectList(listData, "fundId", "fundName");
            var selected = myList.Where(x => x.Value == "0").First();
            selected.Selected = true;
            return myList;
        }        
        //get fund by id
        public Fund getFund(int id) {
            return fund.Single(item => item.fundId == id);
        }
        //get list of awards with matching fund id
        public List<Award> getFundedAwards(int fundId) {
            List<Award> myAwards = awards.Where(item => item.fundId == fundId).ToList();
            return myAwards;
        }
        //get list of donations with matching fund id
        public List<Donation> getFundDonations(int fundId) {
            List<Donation> myDonations = donation.Where(item => item.fundId == fundId).ToList();
            return myDonations;
        }
        /*
        *
        *   Address Work
        *
        */
        //get list of addresses sorted by ID
        public List<Address> getAddressesById() {
            List<Address> addresses = address.OrderBy(l => l.addressId).ToList();
            return addresses;
        }
        //get newest address
        public Address newestAddress() {
            return address.Last();
        }
        public Address getAddress(int id) {
            return address.Single(item => item.addressId == id);
        }
                //get relation with sponsor based on the id of the address
        public AddressRelations getAddressRelations(int myAddressId) {
            return addressRels.Single(item => item.addressId == myAddressId);
        }
    }
}