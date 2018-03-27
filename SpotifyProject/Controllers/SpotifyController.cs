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
        private SpotifyContext _context;
 
        public SpotifyController(SpotifyContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("overview")]
        public IActionResult Overview()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");

            int? userid = HttpContext.Session.GetInt32("userID");
            List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
            ViewBag.MyPlaylists = myplaylists;

            return View("Overview");
        }

        [HttpGet]
        [Route("podcasts")]
        public IActionResult Podcasts()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");

            int? userid = HttpContext.Session.GetInt32("userID");
            List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
            ViewBag.MyPlaylists = myplaylists;

            return View("Podcasts");
        }

        [HttpGet]
        [Route("concerts")]
        public IActionResult Concerts()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");

            int? userid = HttpContext.Session.GetInt32("userID");
            List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
            ViewBag.MyPlaylists = myplaylists;

            return View("Concerts");
        }

        [HttpGet]
        [Route("charts")]
        public IActionResult Charts()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");

            int? userid = HttpContext.Session.GetInt32("userID");
            List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
            ViewBag.MyPlaylists = myplaylists;

            return View("Charts");
        }

        [HttpGet]
        [Route("genremood")]
        public IActionResult GenreMood()
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");

            int? userid = HttpContext.Session.GetInt32("userID");
            List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
            ViewBag.MyPlaylists = myplaylists;

            return View("GenreMood");
        }

        [HttpGet]
        [Route("userprofile/{id}")]
        public IActionResult UserProfile(int id)
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");

            int? userid = HttpContext.Session.GetInt32("userID");
            List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
            ViewBag.MyPlaylists = myplaylists;

            return View("UserProfile");
        }

        [HttpGet]
        [Route("songs/{id}")]
        public IActionResult Songs(int id)
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");

            int? userid = HttpContext.Session.GetInt32("userID");
            List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
            ViewBag.MyPlaylists = myplaylists;

            return View("Songs");
        }

        [HttpGet]
        [Route("playlist/{id}")]
        public IActionResult Playlist(int id)
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");

            int? userid = HttpContext.Session.GetInt32("userID");
            List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
            ViewBag.MyPlaylists = myplaylists;
            
            Playlist thisplaylist = _context.Playlists.Where(p => p.PlaylistId == id).SingleOrDefault();
            ViewBag.ThisPlaylist = thisplaylist;

            return View("Playlists");
        }

        [HttpGet]
        [Route("artists")]
        public IActionResult AllArtists(int id)
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");

            int? userid = HttpContext.Session.GetInt32("userID");
            List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
            ViewBag.MyPlaylists = myplaylists;

            return View("AllArtists");
        }

        [HttpGet]
        [Route("albums")]
        public IActionResult AllAlbums(int id)
        {
            ViewBag.UserId = HttpContext.Session.GetInt32("userID");
            ViewBag.FullName = HttpContext.Session.GetString("fullname");
            ViewBag.Username = HttpContext.Session.GetString("username");

            int? userid = HttpContext.Session.GetInt32("userID");
            List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
            ViewBag.MyPlaylists = myplaylists;

            return View("AllAlbums");
        }

        [HttpPost]
        [Route("addplaylist")]
        public IActionResult AddPlaylist(Playlist newPlaylist)
        {
            if (ModelState.IsValid)
            {
                int? id = HttpContext.Session.GetInt32("userID");
                Playlist playlist = new Playlist
                {
                    UserId = (int)id,
                    PlaylistTitle = newPlaylist.PlaylistTitle,
                };
                _context.Add(playlist);
                _context.SaveChanges();
                return RedirectToAction("Overview", "Spotify");
            }
            else
            {
                return View("Overview");
            }
        }
    }
}