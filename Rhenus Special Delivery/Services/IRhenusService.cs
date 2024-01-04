using Rhenus_Special_Delivery.DTOs;

namespace Rhenus_Special_Delivery.Services
{
    public interface IRhenusService
    {
        public BetResponse PlaceBet(BetRequest betRequest, string playerId);
    }
}