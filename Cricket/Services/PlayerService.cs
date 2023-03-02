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
                _player.Name = player.Name;
                    _player.Age = player.Age;
                    _player.Team = player.Team;
                    _player.Matches = player.Matches;
                    _player.PlayerType = player.PlayerType;
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
        public object PlayerGet(Guid Id, string Name, int age, string playerType, string Team, int Matches)
        {

            var _player = from x in _db.players
                where (x.Name == Name || Name == null) && (x.Id == Id || Id == Guid.Empty) && (x.Age == age || age == 0) && (x.IsDeleted == false) && (x.PlayerType == playerType || playerType == null) && (x.Team == Team || Team == null) && (x.Matches == Matches || Matches == null)
                select new { x.Id, x.Age, x.Name, x.PlayerType, x.Team, x.Matches, x.CreationDateTime };
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
    }
}
