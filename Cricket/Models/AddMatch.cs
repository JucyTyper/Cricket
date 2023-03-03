namespace Cricket.Models
{
    public class AddMatch
    {
        public string Date { get; set; }
        public string TeamA { get; set; }
        public string TeamB { get; set; }
        //public int NoOfOvers { get; set; }
        public List<string> TeamAPlayers { get; set;}
        public List<string> TeamBPlayers { get; set; }
    }
}
