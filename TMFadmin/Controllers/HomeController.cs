using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TMFadmin.Models;

namespace TMFadmin.Controllers
{
    public class HomeController : Controller
    {
        private RevenueManager revenueManager;
        public HomeController(RevenueManager myManager) {
            revenueManager = myManager;
        }
        //---------------------------------------------------------------------- Main Work
        public IActionResult Index()
        {
            return View(revenueManager);
        }
        public IActionResult Logout() {
            //logs user out and reqirects to login page
            //HttpContext.Session.SetString("auth", "false");
            return RedirectToAction("Index", "Login");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        //---------------------------------------------------------------------- Sponsor Work
        public IActionResult ViewSponsors() {
            //view all sponsors
            return View(revenueManager);
        }
        //[HttpPost]
        public IActionResult ViewSponsor(int mySponsorId) {
            //view sponsor in detail
            Sponsor sponsor = new Sponsor();
            sponsor = revenueManager.getSponsor(mySponsorId);
            revenueManager.getSponsorDon(mySponsorId);
            revenueManager.getSponsorAd(mySponsorId);
            revenueManager.getSponsorAddresses(mySponsorId);
            ViewBag.donations = revenueManager.donations;
            ViewBag.adverts = revenueManager.adverts;
            ViewBag.addresses = revenueManager.addresses;

            return View(sponsor);
        }
        public IActionResult AddSponsor() {
            //redirect to add sponsor form
            Sponsor sponsor = new Sponsor();
            return View(sponsor);
        }
        [HttpPost]
        public IActionResult AddSponsorSubmit(Sponsor mySponsor) {
            //submit new sponsor to db
            if (!ModelState.IsValid) return RedirectToAction("AddSponsor");
            revenueManager.Add(mySponsor);
            revenueManager.SaveChanges();
            Sponsor sponsor = new Sponsor();
            sponsor = revenueManager.newestSponsor();
            int id = sponsor.sponsorId;
            return RedirectToAction("ViewSponsor", new { mySponsorId = id });
        }
        [HttpPost]
        public IActionResult EditSponsor(int mySponsorId) {
            //redirect to edit sponsor form
            Sponsor sponsor = new Sponsor();
            sponsor = revenueManager.getSponsor(mySponsorId);
            return View(sponsor);
        }
        [HttpPost]
        public IActionResult EditSponsorSubmit(Sponsor sponsor) {
            //submit edited sponsor
            if (!ModelState.IsValid) return RedirectToAction("Index");
            revenueManager.Update(sponsor);
            revenueManager.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteSponsor(int mySponsorId) {
            //redirect to delete sponsor page
            Sponsor sponsor = new Sponsor();
            sponsor = revenueManager.getSponsor(mySponsorId);
            return View(sponsor);
        }
        [HttpPost]
        public IActionResult DeleteSponsorSubmit(Sponsor sponsor) {
            //delete sponsor
            //if (!ModelState.IsValid) return RedirectToAction("Index");
            revenueManager.Remove(sponsor);
            revenueManager.SaveChanges();
            return RedirectToAction("Index");
        } 
        //---------------------------------------------------------------------- Sponsor Work
        public IActionResult ViewAdvertisements() {
            //view all advertisements
            return View(revenueManager);
        }
        public IActionResult AddAdvertisement() {
            //redirect to add donation form
            Advertisement advertisement = new Advertisement();
            return View(revenueManager);
        }        
        // ------ delete
        [HttpPost]
        public IActionResult DeleteAdvertisement(int myAdId) {
            //redirect to delete Advertisement page
            Advertisement advertisement = new Advertisement();
            advertisement = revenueManager.getAdvertisement(myAdId);
            return View(advertisement);
        }
        [HttpPost]
        public IActionResult DeleteAdvertisementSubmit(Advertisement myAdvertisement) {
            //delete Advertisement
            //if (!ModelState.IsValid) return RedirectToAction("Index");
            revenueManager.Remove(myAdvertisement);
            revenueManager.SaveChanges();
            return RedirectToAction("Index");
        } 

        
        
        
        //---------------------------------------------------------------------- Donations Work
        public IActionResult ViewDonations() {
            //view all donations
            return View(revenueManager);
        }
        public IActionResult AddDonation() {
            //redirect to add donation form
            Donation donation = new Donation();
            ViewBag.selectList = revenueManager.getList();
            ViewBag.fundList = revenueManager.getFundList();
            return View(donation);
        }
        [HttpPost]
        public IActionResult AddDonationSubmit(Donation myDonation, int mySponsorId, int myFundId, String receipt) {
            //submit new sponsor to db
            if (!ModelState.IsValid) return RedirectToAction("AddSponsor");
            myDonation.date = DateTime.Now;
            if (receipt == "1") {
                myDonation.receipt = 1;
            } else {
                myDonation.receipt = 0;
            }
            if (myFundId != 0) {
               myDonation.fundId = myFundId; 
            }
            //add donation
            revenueManager.Add(myDonation);
            revenueManager.SaveChanges();
            //build relation with sponsor  
            DonationRelations donRel =new DonationRelations();
            donRel.sponsorId = mySponsorId;
            donRel.donId = revenueManager.newDonId();
            //add relationship
            revenueManager.Add(donRel);
            revenueManager.SaveChanges();
            return RedirectToAction("ViewDonations");
        }
        [HttpPost]
        public IActionResult DeleteDonation(int myDonId) {
            //redirect to delete Donation page
            Donation donation = new Donation();
            donation = revenueManager.getDonation(myDonId);
            return View(donation);
        }
        [HttpPost]
        public IActionResult DeleteDonationSubmit(Donation donation) {
            //delete Donation
            if (!ModelState.IsValid) return RedirectToAction("Index");
            revenueManager.Remove(donation);
            DonationRelations rel = new DonationRelations();
            rel = revenueManager.getDonationRelations(donation.donId);
            revenueManager.Remove(rel);
            revenueManager.SaveChanges();
            return RedirectToAction("ViewDonations");
        }        
        //---------------------------------------------------------------------- Awards Work
        public IActionResult ViewAwards() {
            //view all awards
            return View(revenueManager);
        }
        public IActionResult AddAward() {
            //redirect to add fund form
            Award award = new Award();
            return View(revenueManager);
        }                
        
                // ------ delete
        [HttpPost]
        public IActionResult DeleteAward(int myAwardId) {
            //redirect to delete fund page
            Award award = new Award();
            award = revenueManager.getAward(myAwardId);
            return View(award);
        }
        [HttpPost]
        public IActionResult DeleteAwardSubmit(Award myAward) {
            //delete Fund
            //if (!ModelState.IsValid) return RedirectToAction("Index");
            revenueManager.Remove(myAward);
            revenueManager.SaveChanges();
            return RedirectToAction("Index");
        } 

 

        //---------------------------------------------------------------------- Funds Work
        public IActionResult ViewFunds() {
            //view all funds
            return View(revenueManager);
        }
        public IActionResult AddFund() {
            //redirect to add fund form
            Fund fund = new Fund();
            return View(revenueManager);
        }
                // ------ delete
        [HttpPost]
        public IActionResult DeleteFund(int myFundId) {
            //redirect to delete fund page
            Fund fund = new Fund();
            fund = revenueManager.getFund(myFundId);
            return View(fund);
        }
        [HttpPost]
        public IActionResult DeleteFundSubmit(Fund myFund) {
            //delete Fund
            //if (!ModelState.IsValid) return RedirectToAction("Index");
            revenueManager.Remove(myFund);
            revenueManager.SaveChanges();
            return RedirectToAction("Index");
        } 

        //---------------------------------------------------------------------- Address Work
        public IActionResult ViewAddresses() {
            //view all addresses
            return View(revenueManager);
        }
        [Route("/AddAddress/{id}")]
        public IActionResult AddAddress(int id) {
            Address address = new Address();
            ViewBag.selectList = revenueManager.getList(id);
            return View(address);
        }
        [HttpPost]
        public IActionResult AddAddressSubmit(Address myAddress, int mySponsorId) {
            //submit new address to db
            if (!ModelState.IsValid) return RedirectToAction("AddAddress");
            revenueManager.Add(myAddress);
            revenueManager.SaveChanges();

            AddressRelations rel = new AddressRelations();
            rel.sponsorId = mySponsorId;
            Address address = new Address();
            address = revenueManager.newestAddress();
            rel.addressId = address.addressId;
            revenueManager.Add(rel);
            revenueManager.SaveChanges();
            
            return RedirectToAction("ViewAddresses");
        }
        // ------ delete
        [HttpPost]
        public IActionResult DeleteAddress(int myAddressId) {
            //redirect to delete address page
            Address address = new Address();
            address = revenueManager.getAddress(myAddressId);
            return View(address);
        }
        [HttpPost]
        public IActionResult DeleteAddressSubmit(Address myAddress) {
            //delete address
            //if (!ModelState.IsValid) return RedirectToAction("Index");
            revenueManager.Remove(myAddress);
            revenueManager.SaveChanges();
            return RedirectToAction("Index");
        } 


        // check out login page
        public IActionResult LandingLogin() {
            //redirect to add login
            return View(revenueManager);
        }
    }
}
