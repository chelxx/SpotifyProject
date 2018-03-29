using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpotifyProject.Models
{
    public class Track : BaseEntity
    {
        [Key]
        public string TrackId { get;set; }
        public int UserId { get;set; }
        public int PlaylistId { get;set; }
        public string TrackName { get;set; }
        public string Artist { get;set; }
        public User User { get;set; }
        public Playlist Playlist { get;set; }
    }
};  