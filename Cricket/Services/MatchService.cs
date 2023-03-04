using Cricket.Data;
using Cricket.Models;
using Cricket.Models.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cricket.Services
{
    public class MatchService : IMatchService
    {
        private ResponseModel response = new ResponseModel();
        private readonly CricketDatabase _db;

        public MatchService(CricketDatabase _db)
        {
            this._db = _db;
        }
        public List<Player> GetPlayerList()
        {
            var playerList = _db.players.Select(x =>x).ToList();
            return playerList;
        }
        public object selectPlayer()
        {
            var AllPlayers = GetPlayerList();
            var model = new PlayerView();
            model.PlayerSelectList = new List<SelectListItem>();
            foreach (var player in AllPlayers)
            {
                model.PlayerSelectList.Add(new SelectListItem
                {
                    Text = player.Name,
                    Value = player.Id.ToString(),
                });
            }
            return model;
        }
    }
}
