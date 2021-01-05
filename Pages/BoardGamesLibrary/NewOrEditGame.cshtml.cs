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
    public class NewOrEditGameModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public NewOrEditGameModel(ApplicationDbContext db)
        {
            _db = db;
        }
        
        [BindProperty]
        public BoardGame BoardGame { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            BoardGame = new BoardGame();
            if (id == null)
            {
                return Page();
            }
            BoardGame = await _db.BoardGame.FirstOrDefaultAsync(u => u.IdGame == id);
            if(BoardGame == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if(BoardGame.IdGame == 0)
                {
                     _db.BoardGame.Add(BoardGame);
                }
                else
                {
                    _db.BoardGame.Update(BoardGame);
                }
                await _db.SaveChangesAsync();
                return RedirectToPage("BoardGameList");
            }
            else
            {
                return Page();
            }
        }
    }
}