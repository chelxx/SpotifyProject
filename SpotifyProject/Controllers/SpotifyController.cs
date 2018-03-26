using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SpotifyProject.Models;

namespace SpotifyProject.Controllers
{
    public class SpotifyController : Controller
    {
        [HttpGet]
        [Route("overview")]
        public IActionResult Overview()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View("Overview");
        }

        [HttpGet]
        [Route("podcasts")]
        public IActionResult Podcasts()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");   
            return View("Podcasts");
        }

        [HttpGet]
        [Route("concerts")]
        public IActionResult Concerts()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View("Concerts");
        }

        [HttpGet]
        [Route("charts")]
        public IActionResult Charts()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View("Charts");
        }

        [HttpGet]
        [Route("genremood")]
        public IActionResult GenreMood()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View("GenreMood");
        }

        [HttpGet]
        [Route("userprofile/{userid}")]
        public IActionResult UserProfile(int userid)
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");
            return View("UserProfile");
        }
    }
}