using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TMFadmin.Models;

namespace TMFadmin.Controllers
{
    public class HomeController : Controller
    {
        private RevenueManager revenueManager;
        private IHostingEnvironment environment;
        public HomeController(RevenueManager myManager, IHostingEnvironment env) {
            revenueManager = myManager;
            environment = env;
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
            return RedirectToAction("ViewSponsor");
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
            //remove donation relations
            foreach(var item in revenueManager.getSponsorDonRels(sponsor.sponsorId)) {
                revenueManager.Remove(item);
                revenueManager.SaveChanges();
            }
            //remove advert relations
            foreach(var item in revenueManager.getSponsorAdRels(sponsor.sponsorId)) {
                revenueManager.Remove(item);
                revenueManager.SaveChanges();
            }
            //remove address relations
            foreach(var item in revenueManager.getSponsorAddressRels(sponsor.sponsorId)) {
                revenueManager.Remove(item);
                revenueManager.SaveChanges();
            }
            //remove addresses
            revenueManager.getSponsorAddresses(sponsor.sponsorId);
            foreach(var item in revenueManager.addresses) {
                revenueManager.Remove(item);
                revenueManager.SaveChanges();
            }
            //delete sponsor
            revenueManager.Remove(sponsor);
            revenueManager.SaveChanges();
            return RedirectToAction("ViewSponsors");
        } 
        //---------------------------------------------------------------------- Advert Work
        public IActionResult ViewAdvertisements() {
            //view all advertisements
            return View(revenueManager);
        }
        public IActionResult AddAdvertisement() {
            //redirect to add ad form
            Advertisement advertisement = new Advertisement();
            ViewBag.selectList = revenueManager.getList();
            return View(advertisement);
        }        
        [HttpPost]
        public IActionResult AddAdvertisementSubmit(Advertisement myAdvertisement, int mySponsorId, String adSize, IFormFile imgFile) {
            ImageManager imageManager = new ImageManager(environment, "images");
            if (!ModelState.IsValid) return RedirectToAction("AddAdvertisement");
            //submit new ad to db
            if (adSize == "full") {
                myAdvertisement.adSize = "full";
            } else if (adSize == "half") {
                myAdvertisement.adSize = "half";
            } else if (adSize == "quarter") {
                myAdvertisement.adSize = "quarter";
            }
            myAdvertisement.date = DateTime.Now;
            int result = imageManager.uploadImage(imgFile);
            switch (result) {
                case 1:
                    ViewData["feedback"] = "Wrong File Type";
                    return RedirectToAction("AddAdvertisement");
                case 2:
                    ViewData["feedback"] = "File Too Large";
                    return RedirectToAction("AddAdvertisement");
                case 3:
                    ViewData["feedback"] = "File Name Too Long";
                    return RedirectToAction("AddAdvertisement");
                case 4:
                    ViewData["feedback"] = "Error Saving File";
                    return RedirectToAction("AddAdvertisement");
                case 5:
                    ViewData["feedback"] = "Success";
                    myAdvertisement.imgFile = imageManager.fileName;
                    revenueManager.Add(myAdvertisement);
                    revenueManager.SaveChanges();
                    //build rel with sponsor
                    AdvertRelations rel = new AdvertRelations();
                    rel.sponsorId = mySponsorId;
                    rel.adId = revenueManager.newAdId();
                    revenueManager.Add(rel);
                    revenueManager.SaveChanges();
                    return RedirectToAction("ViewAdvertisements");
                default:
                    ViewData["feedback"] = "No File Selected";
                    return RedirectToAction("AddAdvertisement");
            }  
        }
        [HttpPost]
        public IActionResult DeleteAdvertisement(int myAdId) {
            //redirect to delete Advertisement page
            Advertisement advertisement = new Advertisement();
            advertisement = revenueManager.getAdvertisement(myAdId);
            Console.WriteLine("\n\nImage file: " + advertisement.imgFile);
            return View(advertisement);
        }
        [HttpPost]
        public IActionResult DeleteAdvertisementSubmit(Advertisement myAdvertisement) {
            //delete Advertisement
            
            ImageManager imageManager = new ImageManager(environment, "images");
            bool result = imageManager.deleteImage(myAdvertisement.imgFile);
            if (result) {
                try {
                    AdvertRelations rel = new AdvertRelations();
                    rel = revenueManager.getAdvertRelations(myAdvertisement.adId);
                    revenueManager.Remove(rel);
                    revenueManager.SaveChanges();
                } catch {}
                revenueManager.Remove(myAdvertisement);
                revenueManager.SaveChanges();
            } else {
                Console.WriteLine("\n\n\n***There has been an error deleting the imagefile!***\n\n\n");
            }
            
            return RedirectToAction("ViewAdvertisements");
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
            //submit new donation to db
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
            DonationRelations donRel = new DonationRelations();
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
            DonationRelations rel = new DonationRelations();
            try {
                rel = revenueManager.getDonationRelations(donation.donId);
                revenueManager.Remove(rel);
                revenueManager.SaveChanges();
            } catch {}
            revenueManager.Remove(donation);
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
            ViewBag.fundList = revenueManager.getFundList();
            return View(award);
        }                
        [HttpPost]
        public IActionResult AddAwardSubmit(Award myAward, int myFundId) {
            if (!ModelState.IsValid) return RedirectToAction("AddAward");
            myAward.fundId = myFundId;
            //add award
            revenueManager.Add(myAward);
            revenueManager.SaveChanges(); 
            return RedirectToAction("ViewAwards");
        }
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
            revenueManager.Remove(myAward);
            revenueManager.SaveChanges();
            return RedirectToAction("ViewAwards");
        } 

        //---------------------------------------------------------------------- Funds Work
        public IActionResult ViewFunds() {
            //view all funds
            return View(revenueManager);
        }
        public IActionResult AddFund() {
            //redirect to add fund form
            Fund fund = new Fund();
            return View(fund);
        }
        [HttpPost]
        public IActionResult AddFundSubmit(Fund myFund) {
            if (!ModelState.IsValid) return RedirectToAction("AddFund");
            revenueManager.Add(myFund);
            revenueManager.SaveChanges();
            return RedirectToAction("ViewFunds");
        }
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
            foreach(var item in revenueManager.getFundedAwards(myFund.fundId)) {
                item.fundId = 0;
                revenueManager.Update(item);
                revenueManager.SaveChanges();
            }
            foreach(var item in revenueManager.getFundDonations(myFund.fundId)) {
                item.fundId = 0;
                revenueManager.Update(item);
                revenueManager.SaveChanges();
            }
            revenueManager.Remove(myFund);
            revenueManager.SaveChanges();
            return RedirectToAction("ViewFunds");
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

        //------------------------------------------------------------------------ Login Page Work
        // check out login page
        public IActionResult LandingLogin() {
            //redirect to add login
            return View(revenueManager);
        }
    }
}
