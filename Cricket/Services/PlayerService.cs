using Cricket.Data;
using Cricket.Models;
using Microsoft.EntityFrameworkCore;

namespace Cricket.Services
{
    public class PlayerService : IPlayerServices
    {
        private ResponseModel response = new ResponseModel();
        private readonly CricketDatabase _db;

        public PlayerService(CricketDatabase _db)
        {
            this._db = _db;
        }
        public  object PlayerPost(AddPlayer player)
        {
            var _player = new Player();
            try
            {
                _player.FirstName = player.FirstName;
                _player.LastName = player.LastName;
                _player.Age = player.Age;
                _player.Team = player.Team;
                _player.NoOfMatches = player.NoOfMatches;
                _player.PlayerType = player.PlayerType;
                _player.JerseyNo = player.JerseyNo;
                _player.Wickets= player.Wickets;
                _player.Runs= player.Runs;
                _db.players.Add(_player);
                _db.SaveChanges();
            }
            catch(Exception ex) 
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
                return response;
            }
            response.Message = "Player Added";
            response.Data = _player;
            return response;
        }
        public object PlayerGet(Guid Id, string FirstName, string LastName, int age, string playerType, string Team)
        {

            var _player = from x in _db.players
                where (x.FirstName == FirstName || FirstName == null) && (x.LastName == LastName || LastName == null) && (x.Id == Id || Id == Guid.Empty) && (x.Age == age || age == 0) && (x.IsDeleted == false) && (x.PlayerType == playerType || playerType == null) && (x.Team == Team || Team == null)
                select new { x.Id, x.Age, x.FirstName, x.LastName, x.PlayerType, x.Team, x.JerseyNo,x.Runs,x.Wickets, x.CreationDateTime };
            _player.AsQueryable();
            try 
            { 
                if (_player.Count() == 0 )
                {
                    response.StatusCode = 404;
                    response.Message = "Player Not Found";
                    return response;
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
                return response;
            }
            response.Data = _player;
            return response;
        }
        public object PlayerDelete(Guid Id)
        {
            try
            {
                var player = from x in _db.players
                             where x.Id == Id
                             select x;
                player.AsQueryable();
                if (player.Count() == 0)
                {
                    response.StatusCode = 404;
                    response.Message = "Player Not Found";
                    return response;
                }
                player.First().IsDeleted = true;
                response.StatusCode = 200;
                response.Message = "Player Deleted";
                return response;
            }
            catch(Exception ex)
            {
                response.StatusCode = 500;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
