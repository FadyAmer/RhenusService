namespace Rhenus_Special_Delivery.DataAccess.Players.Readers
{
    public interface IPlayerReader
    {
        public Players.Models.Player GetPlayer(string playerID);
    }
}