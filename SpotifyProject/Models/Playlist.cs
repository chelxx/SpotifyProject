using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpotifyProject.Models
{
    public class Playlist : BaseEntity
    {
        public int PlaylistId { get; set; }
        public string PlaylistTitle { get; set; }

        // STARTED GOING TO SHIT WHEN THESE WERE ADDED
        // BUILD FAILS, CANNOT MIGRATE
        public User User { get; set; }
        public int UserId { get; set; }
    }
}