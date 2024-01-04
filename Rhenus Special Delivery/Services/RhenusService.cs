using Microsoft.AspNetCore.Mvc;
using Rhenus_Special_Delivery.DataAccess;
using Rhenus_Special_Delivery.DataAccess.Players.Models;
using Rhenus_Special_Delivery.DataAccess.Players.Readers;
using Rhenus_Special_Delivery.DataAccess.Players.Writers;
using Rhenus_Special_Delivery.DTOs;

namespace Rhenus_Special_Delivery.Services
{
    public class RhenusService : IRhenusService
    {
        IPlayerReader _playerReader;
        IPlayerWriter _playerWriter;
        private readonly Random _random;
        public RhenusService(IPlayerReader playerReader, IPlayerWriter playerWriter)
        {
            _playerReader = playerReader;
            _playerWriter = playerWriter;
            _random = new Random();
        }


        public BetResponse PlaceBet(BetRequest betRequest, string playerId)
        {

            var player = _playerReader.GetPlayer(playerId);
            ValidatePrams(betRequest, player);

            var generatedNumber = GenerateRandomNumber();
            var betResponse = new BetResponse();

            if (IsBetCorrect(generatedNumber, betRequest.Number))
            {
                var winningPoints = CalculateWinningPoints(betRequest.Points);
                player = _playerWriter.UpdatePlayer(player.Id, winningPoints);

                betResponse.Account = player.Points;
                betResponse.Status = BetStatus.won.ToString();
                betResponse.Points = $"+{winningPoints}";
            }
            else
            {
                betResponse.Account = player.Points;
                betResponse.Status = BetStatus.lose.ToString();
                betResponse.Points = "+0";
            }
            return betResponse;
        }

        private void ValidatePrams(BetRequest betRequest, Player player)
        {
            if (player == null)
            {
                throw new ArgumentException("Invalid player  ID.");
            }
            if (player.Points < betRequest.Points || betRequest.Points <= 0 || betRequest.Number >= 9)
            {
                throw new ArgumentException("Invalid bet or insufficient points.");
            }
        }

        private int GenerateRandomNumber()
        {
            return _random.Next(0, 9);
        }

        private bool IsBetCorrect(int generatedNumber, int betPoints)
        {
            return generatedNumber == betPoints;
        }

        private int CalculateWinningPoints(int betPoints)
        {
            return betPoints * 9;
        }

    }
}
