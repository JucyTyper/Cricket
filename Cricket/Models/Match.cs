using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cricket.Models
{
    public class Match
    {
        public Guid MatchId { get; set; } = Guid.NewGuid();
        public DateTime Date { get; set; }
        public Guid TeamA { get; set; }
        public Guid TeamB { get; set; }
        public int NoOfOvers { get; set; }

    }
}
