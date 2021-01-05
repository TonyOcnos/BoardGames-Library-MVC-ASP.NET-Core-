using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGamesLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BoardGamesLibrary.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _db;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IEnumerable<Player> Players { get; set; }
        public IEnumerable<MatchRELPlayer> MatchRELPlayers { get; set; }
        public IEnumerable<BoardGame> BoardGames { get; set; }
        public IEnumerable<Match> Matches { get; set; }

        public async Task<IActionResult> OnPost()
        {

            Players = await _db.Player.ToListAsync();
            MatchRELPlayers = await _db.MatchRELPlayer.ToListAsync();
            BoardGames = await _db.BoardGame.ToListAsync();
            Matches = await _db.Match.ToListAsync();

            if (Players.Count() != 0)
            {
                _db.Player.RemoveRange(Players);
            }
            if (MatchRELPlayers.Count() != 0)
            {
                _db.MatchRELPlayer.RemoveRange(MatchRELPlayers);
            }
            if (BoardGames.Count() != 0)
            {
                _db.BoardGame.RemoveRange(BoardGames);
            }
            if (Matches.Count() != 0)
            {
                _db.Match.RemoveRange(Matches);
            }

            try
            {
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            catch
            {
                return RedirectToPage("Error");
            }
        }
    }
}
