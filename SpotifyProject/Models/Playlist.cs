using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpotifyProject.Models
{
    public class Playlist : BaseEntity
    {
        public int PlaylistId { get; set; }
        public string PlaylistTitle { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public List<Track> Tracks { get;set; }
        public Playlist()
        {
            Tracks = new List<Track>();
        }
    }
}