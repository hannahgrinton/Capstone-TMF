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
        [HttpPost]
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
        public IActionResult AddSponsorSubmit(Sponsor sponsor) {
            //submit new sponsor to db
            if (!ModelState.IsValid) return RedirectToAction("Index");
            revenueManager.Add(sponsor);
            revenueManager.SaveChanges();
            return RedirectToAction("Index");
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
            if (!ModelState.IsValid) return RedirectToAction("Index");
            revenueManager.Remove(sponsor);
            revenueManager.SaveChanges();
            return RedirectToAction("Index");
        } 
                //---------------------------------------------------------------------- Sponsor Work
        public IActionResult ViewAdvertisements() {
            //view all advertisements
            return View(revenueManager);
        }        
        
        
        
        //---------------------------------------------------------------------- Donations Work
        public IActionResult ViewDonations() {
            //view all donations
            return View(revenueManager);
        }

                
        //---------------------------------------------------------------------- Awards Work
        public IActionResult ViewAwards() {
            //view all awards
            return View(revenueManager);
        }                


        //---------------------------------------------------------------------- Funds Work
        public IActionResult ViewFunds() {
            //view all funds
            return View(revenueManager);
        }

        //---------------------------------------------------------------------- Funds Work
        public IActionResult ViewAddresses() {
            //view all addresses
            return View(revenueManager);
        }
    }
}
