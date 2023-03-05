namespace Cricket.Models
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public int Wickets { get; set; } = 0;
        public int Runs { get; set; } = 0;
        public int NoOfMatches { get; set; } = 0;
        public int JerseyNo { get; set; } = 0;
        public string PlayerType { get; set; } = string.Empty;
        public Guid Team { get; set; } = Guid.Empty;
        public bool IsAvailable { get; set; } = true;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
    }
}
