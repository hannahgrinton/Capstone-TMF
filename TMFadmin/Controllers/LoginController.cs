﻿using System;
using Microsoft.AspNetCore.Mvc;
using TMFadmin.Models;

//this is the controller for the login for the administration end of the app
namespace TMFadmin.Controllers {

    public class LoginController : Controller {

        public IActionResult Index() {
            return View();
        }

        public IActionResult Submit(string myUsername, string myPassword) {
            // WebLogin webLogin = new WebLogin("Server=localhost;Database=login;Uid=hannah;Pwd=grinton;SslMode=none;", HttpContext);
            WebLogin webLogin = new WebLogin("Server=localhost;Database=dbTMF;Uid=root;Pwd=;SslMode=none;", HttpContext);
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
