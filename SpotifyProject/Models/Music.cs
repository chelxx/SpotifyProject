using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SpotifyProject.Models
{
    public class Music : BaseEntity
    {
        [Key]
        public string MusicMIB { get;set; }
        public User User { get;set; }
        public Playlist Playlist { get;set; }
        public int UserId { get;set; }
        

    }
}