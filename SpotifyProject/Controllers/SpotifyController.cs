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
            int? UserId = HttpContext.Session.GetInt32("userID");
            if (UserId == null)
            {
                TempData["NobodyThere"] = "You must be logged in first!";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.UserId = HttpContext.Session.GetInt32("userID");
                ViewBag.FullName = HttpContext.Session.GetString("fullname");
                ViewBag.Username = HttpContext.Session.GetString("username");

                int? userid = HttpContext.Session.GetInt32("userID");
                List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
                ViewBag.MyPlaylists = myplaylists;

                return View("Overview");
            }
        }

        [HttpGet]
        [Route("podcasts")]
        public IActionResult Podcasts()
        {
            int? UserId = HttpContext.Session.GetInt32("userID");
            if (UserId == null)
            {
                TempData["NobodyThere"] = "You must be logged in first!";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.UserId = HttpContext.Session.GetInt32("userID");
                ViewBag.FullName = HttpContext.Session.GetString("fullname");
                ViewBag.Username = HttpContext.Session.GetString("username");

                int? userid = HttpContext.Session.GetInt32("userID");
                List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
                ViewBag.MyPlaylists = myplaylists;

                return View("Podcasts");
            }
        }

        [HttpGet]
        [Route("concerts")]
        public IActionResult Concerts()
        {
            int? UserId = HttpContext.Session.GetInt32("userID");
            if (UserId == null)
            {
                TempData["NobodyThere"] = "You must be logged in first!";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.UserId = HttpContext.Session.GetInt32("userID");
                ViewBag.FullName = HttpContext.Session.GetString("fullname");
                ViewBag.Username = HttpContext.Session.GetString("username");

                int? userid = HttpContext.Session.GetInt32("userID");
                List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
                ViewBag.MyPlaylists = myplaylists;

                return View("Concerts");
            }
        }

        [HttpGet]
        [Route("charts")]
        public IActionResult Charts()
        {
            int? UserId = HttpContext.Session.GetInt32("userID");
            if (UserId == null)
            {
                TempData["NobodyThere"] = "You must be logged in first!";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.UserId = HttpContext.Session.GetInt32("userID");
                ViewBag.FullName = HttpContext.Session.GetString("fullname");
                ViewBag.Username = HttpContext.Session.GetString("username");

                int? userid = HttpContext.Session.GetInt32("userID");
                List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
                ViewBag.MyPlaylists = myplaylists;

                return View("Charts");
            }
        }

        [HttpGet]
        [Route("genremood")]
        public IActionResult GenreMood()
        {
            int? UserId = HttpContext.Session.GetInt32("userID");
            if (UserId == null)
            {
                TempData["NobodyThere"] = "You must be logged in first!";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.UserId = HttpContext.Session.GetInt32("userID");
                ViewBag.FullName = HttpContext.Session.GetString("fullname");
                ViewBag.Username = HttpContext.Session.GetString("username");

                int? userid = HttpContext.Session.GetInt32("userID");
                List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
                ViewBag.MyPlaylists = myplaylists;

                return View("GenreMood");
            }
        }

        [HttpGet]
        [Route("userprofile/{id}")]
        public IActionResult UserProfile(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("userID");
            if (UserId == null)
            {
                TempData["NobodyThere"] = "You must be logged in first!";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.Birthday = _context.Users.Where(u => u.UserId == UserId).SingleOrDefault();
                ViewBag.UserId = HttpContext.Session.GetInt32("userID");
                ViewBag.FullName = HttpContext.Session.GetString("fullname");
                ViewBag.Username = HttpContext.Session.GetString("username");

                int? userid = HttpContext.Session.GetInt32("userID");
                List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
                ViewBag.MyPlaylists = myplaylists;

                return View("UserProfile");
            }
        }

        [HttpGet]
        [Route("songs/{id}")]
        public IActionResult Songs(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("userID");
            if (UserId == null)
            {
                TempData["NobodyThere"] = "You must be logged in first!";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.UserId = HttpContext.Session.GetInt32("userID");
                ViewBag.FullName = HttpContext.Session.GetString("fullname");
                ViewBag.Username = HttpContext.Session.GetString("username");
                ViewBag.AllTracks = _context.Tracks.Where(t => t.UserId == id).ToList();

                int? userid = HttpContext.Session.GetInt32("userID");
                List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
                ViewBag.MyPlaylists = myplaylists;

                return View("Songs");
            }
        }

        [HttpGet]
        [Route("playlist/{id}")]
        public IActionResult Playlist(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("userID");
            if (UserId == null)
            {
                TempData["NobodyThere"] = "You must be logged in first!";
                return RedirectToAction("Index", "User");
            }
            else
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
        }

        [HttpGet]
        [Route("artists")]
        public IActionResult AllArtists(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("userID");
            if (UserId == null)
            {
                TempData["NobodyThere"] = "You must be logged in first!";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.UserId = HttpContext.Session.GetInt32("userID");
                ViewBag.FullName = HttpContext.Session.GetString("fullname");
                ViewBag.Username = HttpContext.Session.GetString("username");

                int? userid = HttpContext.Session.GetInt32("userID");
                List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
                ViewBag.MyPlaylists = myplaylists;

                return View("AllArtists");
            }
        }

        [HttpGet]
        [Route("albums")]
        public IActionResult AllAlbums(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("userID");
            if (UserId == null)
            {
                TempData["NobodyThere"] = "You must be logged in first!";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.UserId = HttpContext.Session.GetInt32("userID");
                ViewBag.FullName = HttpContext.Session.GetString("fullname");
                ViewBag.Username = HttpContext.Session.GetString("username");

                int? userid = HttpContext.Session.GetInt32("userID");
                List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
                ViewBag.MyPlaylists = myplaylists;

                return View("AllAlbums");
            }
        }

        [HttpGet]
        [Route("artist/ARTIST")]
        public IActionResult OneArtist(int id)
        {
            int? UserId = HttpContext.Session.GetInt32("userID");
            if (UserId == null)
            {
                TempData["NobodyThere"] = "You must be logged in first!";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.UserId = HttpContext.Session.GetInt32("userID");
                ViewBag.FullName = HttpContext.Session.GetString("fullname");
                ViewBag.Username = HttpContext.Session.GetString("username");

                int? userid = HttpContext.Session.GetInt32("userID");
                List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
                ViewBag.MyPlaylists = myplaylists;

                return View("OneArtist");
            }
        }

        [HttpGet]
        [Route("recentlyplayed")]
        public IActionResult RecentlyPlayed()
        {
            int? UserId = HttpContext.Session.GetInt32("userID");
            if (UserId == null)
            {
                TempData["NobodyThere"] = "You must be logged in first!";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.UserId = HttpContext.Session.GetInt32("userID");
                ViewBag.FullName = HttpContext.Session.GetString("fullname");
                ViewBag.Username = HttpContext.Session.GetString("username");

                int? userid = HttpContext.Session.GetInt32("userID");
                List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
                ViewBag.MyPlaylists = myplaylists;

                return View("RecentlyPlayed");
            }
        }

        [HttpGet]
        [Route("top50charts")]
        public IActionResult Top50Charts()
        {
            int? UserId = HttpContext.Session.GetInt32("userID");
            if (UserId == null)
            {
                TempData["NobodyThere"] = "You must be logged in first!";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.UserId = HttpContext.Session.GetInt32("userID");
                ViewBag.FullName = HttpContext.Session.GetString("fullname");
                ViewBag.Username = HttpContext.Session.GetString("username");

                int? userid = HttpContext.Session.GetInt32("userID");
                List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
                ViewBag.MyPlaylists = myplaylists;

                return View("Chart50");
            }
        }

        [HttpGet]
        [Route("search")]
        public IActionResult Search()
        {
            int? UserId = HttpContext.Session.GetInt32("userID");
            if (UserId == null)
            {
                TempData["NobodyThere"] = "You must be logged in first!";
                return RedirectToAction("Index", "User");
            }
            else
            {
                ViewBag.UserId = HttpContext.Session.GetInt32("userID");
                ViewBag.FullName = HttpContext.Session.GetString("fullname");
                ViewBag.Username = HttpContext.Session.GetString("username");

                int? userid = HttpContext.Session.GetInt32("userID");
                List<Playlist> myplaylists = _context.Playlists.Where(u => u.UserId == userid).ToList();
                ViewBag.MyPlaylists = myplaylists;

                return View("Search");
            }
        }

        [HttpPost]
        [Route("addplaylist")]
        public IActionResult AddPlaylist(Playlist newPlaylist)
        {
            int? UserId = HttpContext.Session.GetInt32("userID");
            if (UserId == null)
            {
                TempData["NobodyThere"] = "You must be logged in first!";
                return RedirectToAction("Index", "User");
            }
            else
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

        [HttpPost]
        [Route("addtracktosongs")]
        public IActionResult AddTrackToSongs(Track newTrack)
        {
            Track addtrack = new Track
            {
                UserId = (int)HttpContext.Session.GetInt32("userID"),
                data_track = newTrack.data_track,
                data_artist = newTrack.data_artist,
            };
            _context.Add(addtrack);
            _context.SaveChanges();
            return RedirectToAction("Overview", "Spotify");
        }

        [HttpPost]
        [Route("delete/{id}")]
        public IActionResult DeletePlaylist(int id)
        {
            Playlist playlist = _context.Playlists.SingleOrDefault(w => w.PlaylistId == id);
            _context.Remove(playlist);
            _context.SaveChanges();
            return RedirectToAction("Overview", "Spotify");
        }
    }
}


