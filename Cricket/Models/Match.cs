using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cricket.Models
{
    public class Match
    {
        public Guid MatchId { get; set; } = Guid.NewGuid();
        public string Date { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public int NoOfOvers { get; set; }
        public List<Player> PlayerTeamA { get; set; }
        public List<Player> PlayerTeamB { get; set; }

    }
}
