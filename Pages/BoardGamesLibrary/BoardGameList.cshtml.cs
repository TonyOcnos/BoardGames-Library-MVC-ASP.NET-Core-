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
    public class BoardGameListModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public BoardGameListModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public IEnumerable<BoardGame> BoardGames { get; set; }
        public IEnumerable<Match> Matches { get; set; }

        public async Task OnGet()
        {
            BoardGames = await _db.BoardGame.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var BoardGame = await _db.BoardGame.FindAsync(id);

            if (BoardGame == null)
            {
                return NotFound();
            }
            DeleteConcurrences(BoardGame.IdGame);
            _db.BoardGame.Remove(BoardGame);

            await _db.SaveChangesAsync();

            return RedirectToPage("BoardGameList");
        }

        public void DeleteConcurrences(int id)
        {
            Matches = _db.Match.Where(o => o.IdGameRef == id);
            foreach(var item in Matches)
            {
                _db.MatchRELPlayer.RemoveRange(_db.MatchRELPlayer.Where(o => o.IdMatchRef == item.IdMatch));
            }
            _db.Match.RemoveRange(Matches);
        }
        
        public int CountMatches (int idGame)
        {
            int count = _db.Match
            .Where(o => o.IdGameRef == idGame)
            .Count();

            if(count == 0)
            {
                return 0;
            }
            return count;
        }
    }
}