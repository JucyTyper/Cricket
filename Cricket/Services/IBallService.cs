using Cricket.Models;

namespace Cricket.Services
{
    public interface IBallService
    {
        public object AddBall(AddBall ball);
        public object GetBall(Guid id, int BallNo, Guid Bowler, int over, Guid StrikeBatsman, string status, Guid matchId, Guid BattingTeamId, Guid FieldingTeamId);
    }
}
