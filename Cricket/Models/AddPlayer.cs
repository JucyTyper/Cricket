namespace Cricket.Models
{
    public class AddPlayer
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public int Matches { get; set; } = 0;
        public string PlayerType { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
    }
}
