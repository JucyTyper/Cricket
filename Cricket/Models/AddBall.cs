namespace Cricket.Models
{
    public class AddBall
    {
        public int BallNo { get; set; }
        public int TotalBAll { get; set; }
        public Guid BowlerID { get; set; }
        public int Over { get; set; }
        public Guid StrikeBatsmanId { get; set; }
        public Guid NonStrikeBatsmanId { get; set; }
        public int Score { get; set; }
        public Guid MatchID { get; set; }
        public Guid BattingTeamId { get; set; }
        public Guid FieldingTeamId { get; set; }
        public string BallStatus { get; set; }
    }
}
