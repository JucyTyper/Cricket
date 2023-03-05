namespace Cricket.Models
{
    public class AddMatch
    {
        public DateTime Date { get; set; }
        public Guid TeamA { get; set; }
        public Guid TeamB { get; set; }
        public int NoOfOvers { get; set; }
        public Guid TossWon { get; set; }
    }
}
