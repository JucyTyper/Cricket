namespace Cricket.Models
{
    public class Player
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; } = 0;
        public int Matches { get; set; } = 0;
        public string PlayerType { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
    }
}
