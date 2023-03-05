namespace Cricket.Models
{
    public class GetMatchModel
    {
        public Guid MatchId { get; set; }
        public DateTime Date { get; set; }
        public Guid TeamA { get; set; }
        public Guid TeamB { get; set; }

    }
}
