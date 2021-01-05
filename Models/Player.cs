using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesLibrary.Models
{
    public class Player
    {
        [Key]
        public string Name { get; set; }
        public int WonMatches { get; set; }
    }
}
