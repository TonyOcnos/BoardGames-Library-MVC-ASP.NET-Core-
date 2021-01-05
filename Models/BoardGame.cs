using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BoardGamesLibrary.Models
{
    public class BoardGame
    {
        [Key]
        public int IdGame { get; set; }

        [Required]
        public string Name { get; set; }
        [DefaultValue("NA")]
        public string Publisher { get; set; }
        [DefaultValue("NA")]
        public string Language { get; set; }
        public string Weight { get; set; }
        public string Type { get; set; }

        [Required]
        [DefaultValue(1)]
        public int NPlayers { get; set; }
    }
}
