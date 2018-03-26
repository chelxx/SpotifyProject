using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace SpotifyTest.Models
{
    public class SpotifyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public SpotifyContext(DbContextOptions<SpotifyContext> options) : base(options) { }
        public DbSet<User> Users { get;set; }
    }
}