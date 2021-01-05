using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BoardGamesLibrary.Models
{
    public class MatchRELPlayer
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("IdMatch")]
        public int IdMatchRef { get; set; }

        [ForeignKey("Name")]
        public string NameRef { get; set; }

        public bool Winner { get; set; }
    }
}
