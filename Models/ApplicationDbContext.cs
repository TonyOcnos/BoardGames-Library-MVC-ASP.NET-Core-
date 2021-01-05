using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesLibrary.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BoardGame> BoardGame { get; set; }
        public DbSet<Match> Match { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<MatchRELPlayer> MatchRELPlayer { get; set; }
    }
}
