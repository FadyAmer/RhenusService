
using Microsoft.AspNetCore.Mvc;
using Rhenus_Special_Delivery.DataAccess.Players.Models;
using Rhenus_Special_Delivery.DataAccess.Players.Readers;

namespace Rhenus_Special_Delivery.DataAccess.Players.Writers
{
    public class PlayerWriter : IPlayerWriter
    {
        RhenusContext _rhenusContext;
        IPlayerReader _playerReader;
        public PlayerWriter(RhenusContext rhenusContext, IPlayerReader playerReader) { _rhenusContext = rhenusContext; _playerReader = playerReader; }
        public Player UpdatePlayer(string playerId, int winningPoints)
        {
            var player = _playerReader.GetPlayer(playerId);
            if (player != null)
            {
                player.Points += winningPoints;
                _rhenusContext.SaveChanges();
                return player;
            }
            throw new ArgumentException("Invalid player  ID.");
        }
        
        public Player CreatePlayer(int points, string userName)
        {
            var player = new Models.Player() { Id = new Guid().ToString(), Points = points, Username = userName };
            _rhenusContext.Players.Add(player);
            _rhenusContext.SaveChanges();
            return player;
        }
    }
}
