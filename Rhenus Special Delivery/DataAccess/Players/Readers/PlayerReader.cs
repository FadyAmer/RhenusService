using Rhenus_Special_Delivery.DataAccess.Players.Models;


namespace Rhenus_Special_Delivery.DataAccess.Players.Readers
{
    public class PlayerReader : IPlayerReader 
    {
        RhenusContext _rhenusContext;
        public PlayerReader(RhenusContext rhenusContext) { 
            _rhenusContext = rhenusContext; 
        }
        public Player GetPlayer(string playerId)
        {
            return _rhenusContext.Players.FirstOrDefault(p=>p.Id==playerId);
        }
    }
}
