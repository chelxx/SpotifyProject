using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SpotifyProject.Models
{
    public class Track : BaseEntity
    {
        [Key]
        public string TrackId { get;set; }
        
        public int UserId { get;set; }

        [DisplayName("data_track")]
        public string data_track { get;set; }

        [DisplayName("data_artist")]
        public string data_artist { get;set; }

        public User User { get;set; }
    }
};  