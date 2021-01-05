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
    public class MultipleInputsExampleModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public MultipleInputsExampleModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public List<string> PlayerList { get; set; }
        [BindProperty]
        public List<string> PlayerAdded { get; set; }

        public IEnumerable<Player> PlayersInDB { get; set; }
        public async Task OnGet()
        {
            PlayersInDB = await _db.Player.ToListAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            PlayerList = new List<string>();
            PlayerList.AddRange(PlayerAdded);

            foreach(var item in PlayerList)
            {
                if (await _db.Player.FindAsync(item) == null)
                {
                    Player p = new Player { Name = item, WonMatches = 0 };
                    await _db.Player.AddAsync(p);
                }
            }
            await _db.SaveChangesAsync();
            return Page();
        }
    }
}