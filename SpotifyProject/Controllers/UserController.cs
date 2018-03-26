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
    public class UserController : Controller
    {
        private SpotifyContext _context;
 
        public UserController(SpotifyContext context)
        {
            _context = context;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        [Route("signup")]
        public IActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpPost]
        [Route("register")]
        public IActionResult RegisterUser(RegUser newRegUser)
        {
            if (ModelState.IsValid)
            {
                User current = _context.Users.SingleOrDefault(e => e.Email == newRegUser.Email);
                if(current != null)
                {
                    ModelState.AddModelError("Email", "Email already exists!");
                    return View("Index");
                }
                else
                {
                    PasswordHasher<RegUser> Hasher = new PasswordHasher<RegUser>();
                    string hashed = Hasher.HashPassword(newRegUser, newRegUser.Password);
                    User user = new User
                    {
                        FullName = newRegUser.FullName,
                        Email = newRegUser.Email,
                        Username = newRegUser.Username,
                        Birthdate = newRegUser.Birthdate,
                        Password = hashed,    
                    };
                    _context.Add(user);
                    _context.SaveChanges();
                    User sessionuser = _context.Users.Where(u => u.Email == newRegUser.Email).SingleOrDefault();
                    HttpContext.Session.SetInt32("userID", sessionuser.UserId);
                    HttpContext.Session.SetString("fullname", sessionuser.FullName);
                    HttpContext.Session.SetString("username", sessionuser.Username);
                    return RedirectToAction("Overview", "Spotify");
                }
            }
            else
            {
                return View("SignUp");
            }
        }

        [HttpPost]
        [Route("login")]
        public IActionResult LoginUser(LoginUser loginUser)
        {
            if(ModelState.IsValid)
            {
                User current = _context.Users.Where(u => u.Email == loginUser.Email).SingleOrDefault();
                if(current == null)
                {
                    ModelState.AddModelError("Email", "Email does not exist!");
                    return View("Login");
                }
                else
                {
                    var hasher = new PasswordHasher<User>();
                    if(hasher.VerifyHashedPassword(current, current.Password, loginUser.Password) == 0)
                    {
                        ModelState.AddModelError("Password", "Incorrect password!");
                        return View("Login");
                    }
                    else
                    {
                        HttpContext.Session.SetInt32("userID", current.UserId);
                        HttpContext.Session.SetString("fullname", current.FullName);
                        HttpContext.Session.SetString("username", current.Username);
                        return RedirectToAction("Overview", "Spotify");
                    }
                }
            }
            else
            {
                return View("Login");
            }
        }

        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}