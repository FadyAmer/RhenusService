using Rhenus_Special_Delivery.DataAccess.Players.Models;
namespace Rhenus_Special_Delivery.DataAccess.Players.Writers
{
    public interface IPlayerWriter
    {
        public Player UpdatePlayer(string playerId,int playerPoints);
        public Player CreatePlayer(int points, string userName);

    }
}
