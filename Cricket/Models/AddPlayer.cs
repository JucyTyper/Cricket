namespace Cricket.Models
{
    public class AddPlayer
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public int Wickets { get; set; } = 0;
        public int Runs { get; set; } = 0;
        public int NoOfMatches { get; set; } = 0;
        public int JerseyNo { get; set; } = 0;
        public string PlayerType { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
    }
}
