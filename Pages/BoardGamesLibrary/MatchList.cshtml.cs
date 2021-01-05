using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGamesLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesLibrary.Pages.BoardGamesLibrary
{
    public class MatchListModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public MatchListModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Match> Matches { get; set; }
        public IEnumerable<BoardGame> BoardGames {get; set;}
        public IEnumerable<MatchRELPlayer> MatchRELPlayer { get; set; }
        public BoardGame BoardGame { get; set; }

        public async Task OnGet(int? id)
        {
            MatchRELPlayer = await _db.MatchRELPlayer.ToListAsync();
            BoardGames = await _db.BoardGame.ToListAsync();

            if (id == null)
            {
                Matches = await _db.Match.ToListAsync();
            }
            else
            {
                Matches = _db.Match.Where(o => o.IdGameRef == id);
                BoardGame = await _db.BoardGame.FindAsync(id);
            }
            Matches = Matches.OrderByDescending(i => i.Date);
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var matchTemp = await _db.Match.FindAsync(id);
            _db.Match.Remove(matchTemp);
            await _db.SaveChangesAsync();

            return RedirectToPage("MatchList");
        }

        public string GetBoardGameName(int idGameRef)
        {
            return BoardGames.Where(o => o.IdGame == idGameRef).First().Name;
        }

        public string FixDates (DateTime date)
        {
            var fixedDate = date.ToString();
            return fixedDate.Replace(" 0:00:00", "");
        }
    }
}