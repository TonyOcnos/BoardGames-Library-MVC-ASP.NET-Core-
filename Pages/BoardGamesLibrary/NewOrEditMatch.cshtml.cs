using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BoardGamesLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace BoardGamesLibrary.Pages.BoardGamesLibrary
{
    public class NewOrEditMatchModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public NewOrEditMatchModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Match Match { get; set; }

        [BindProperty]
        public List<string> PlayerAdded { get; set; }
        public List<string> PlayerList { get; set; }
        [BindProperty]
        public List<int> CheckedWinner { get; set; }

        public BoardGame BoardGame { get; set; }

        public MatchRELPlayer MatchRELPlayer { get; set; }

        public IEnumerable<BoardGame> BoardGames { get; set; }

        public async Task OnGet(int id)
        {
            BoardGame = new BoardGame();
            BoardGame = await _db.BoardGame.FindAsync(id);

            BoardGames = await _db.BoardGame.ToListAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                PlayerList = new List<string>();
                PlayerList.AddRange(PlayerAdded);

                await _db.Match.AddAsync(Match);
                await _db.SaveChangesAsync();

                await AddPlayer();
                await _db.SaveChangesAsync();

                return RedirectToPage("MatchList");
            }
            return Page();
        }

        public async Task AddPlayer()
        {
            var count = 1;
            Player p;
            foreach (var item in PlayerList)
            {
                if (item != null) { 
                    p = new Player { Name = item, WonMatches = 0 };
                    if (await _db.Player.FindAsync(item) == null)
                    {
                        await _db.Player.AddAsync(p);
                    
                    }
                    await AddPlayerToTable(p, count);
                }
                count++;
            }
        }
        public async Task AddPlayerToTable(Player p, int count)
        {
            MatchRELPlayer temp;
            if (CheckedWinner.Contains(count))
            {
                temp = new MatchRELPlayer { NameRef = p.Name, IdMatchRef = Match.IdMatch, Winner = true };
            }
            else
            {
                temp = new MatchRELPlayer { NameRef = p.Name, IdMatchRef = Match.IdMatch, Winner = false };
            }
            await _db.MatchRELPlayer.AddAsync(temp);
        }
    }
}