using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGamesLibrary.Models
{
    public class Match
    {
        [Key]
        public int IdMatch { get; set; }

        [ForeignKey("IdGame")]
        public int IdGameRef { get; set; }

        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
        public string Duration { get; set; }

        public string Winner { get; set; }
    }
}