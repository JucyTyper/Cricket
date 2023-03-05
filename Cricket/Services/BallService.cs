using Cricket.Data;
using Cricket.Models;

namespace Cricket.Services
{
    public class BallService : IBallService
    {
        private ResponseModel response = new ResponseModel();
        private readonly CricketDatabase _db;

        public BallService(CricketDatabase _db)
        {
            this._db = _db;
        }
        public object AddBall(AddBall ball)
        {
            try
            {
                var _ball = new Ball
                {
                    BallNo = ball.BallNo,
                    BallStatus = ball.BallStatus,
                    TotalBAll = ball.TotalBAll,
                    Over = ball.Over,
                    Score = ball.Score,
                    StrikeBatsmanId = ball.StrikeBatsmanId,
                    NonStrikeBatsmanId = ball.NonStrikeBatsmanId,
                    BowlerID= ball.BowlerID,
                    MatchID= ball.MatchID,
                    BattingTeamId = ball.BattingTeamId,
                    FieldingTeamId= ball.FieldingTeamId
                };
                _db.balls.Add(_ball);
                _db.SaveChanges();
                response.Message = "Ball Added";
                response.Data = _ball;
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
                return response;
            }
        }
        public object GetBall(Guid id, int BallNo, Guid Bowler, int over, Guid StrikeBatsman, string status,Guid matchId , Guid BattingTeamId,Guid FieldingTeamId)
        {
            try
            {
                var ball = _db.balls.Where(x => (x.BallId == id || id == Guid.Empty) && (x.BallNo == BallNo || BallNo == 0)&&(x.BallStatus == status || status == null)&&(x.BowlerID==Bowler||Bowler==Guid.Empty)&&(x.MatchID == matchId||matchId == Guid.Empty)&&(x.StrikeBatsmanId == StrikeBatsman || StrikeBatsman == Guid.Empty)&&(x.BattingTeamId == BattingTeamId || BattingTeamId == Guid.Empty)&&(x.FieldingTeamId==FieldingTeamId||FieldingTeamId == Guid.Empty)).Select(x => new { x.BallId,x.BallNo,x.BallStatus,x.Score,x.BowlerID,x.Over,x.MatchID,x.StrikeBatsmanId,x.NonStrikeBatsmanId,x.BattingTeamId,x.FieldingTeamId,x.TotalBAll});
                if (ball.Count() == 0)
                {
                    response.StatusCode = 404;
                    response.Message = "Ball Not Found";
                    return response;
                }
                response.Data = ball;
                return response;
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
