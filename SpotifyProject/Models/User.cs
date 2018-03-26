using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpotifyProject.Models
{
    public class User : BaseEntity
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get;set; }
        public DateTime Birthdate { get;set; }
        public string Password { get; set; }

    }
}