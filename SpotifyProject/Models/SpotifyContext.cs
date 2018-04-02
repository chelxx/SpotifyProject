using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SpotifyProject.Models
{
    public class SpotifyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public SpotifyContext(DbContextOptions<SpotifyContext> options) : base(options) { }
        public DbSet<User> Users { get;set; }
        public DbSet<Playlist> Playlists { get;set; }
        public DbSet<Track> Tracks { get;set; }
    }
}