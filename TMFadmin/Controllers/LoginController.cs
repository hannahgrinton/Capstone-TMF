﻿using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TMFadmin.Models;

//this is the controller for the login for the administration end of the app
namespace TMFadmin.Controllers {

    public class LoginController : Controller {

        public IActionResult Index() {
            HttpContext.Session.SetString("auth", "false");
            return View();
        }

        public IActionResult Submit(string myUsername, string myPassword) {
            WebLogin webLogin = new WebLogin("Server=10.16.112.118;Database=db1120622_TMFfund;Uid=u1120622_TMFfund;Pwd=nsccDonorProject@2020;SslMode=none;", HttpContext);
            
            webLogin.username = myUsername;
            webLogin.password = myPassword;
            //do I have access?
            if (webLogin.unlock()) {
                //access granted
                return RedirectToAction("Index", "Home");
            } else {
                //access denied
                ViewData["feedback"] = "Incorrect login. Please try again...";
            }
            return View("Index");
        }
    }
}
