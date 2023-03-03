namespace Cricket.Models
{
    public class GetMatchModel
    {
        public Guid MatchId { get; set; }
        public string Date { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        public List<string> TeamAPlayers { get; set; }
        public List<string> TeamBPlayers { get; set; }
    }
}
