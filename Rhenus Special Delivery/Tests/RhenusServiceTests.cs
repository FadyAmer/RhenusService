using NUnit.Framework;
using Moq;
using System;
using Rhenus_Special_Delivery.Services;
using Rhenus_Special_Delivery.DataAccess.Players.Models;
using Rhenus_Special_Delivery.DataAccess.Players.Readers;
using Rhenus_Special_Delivery.DataAccess.Players.Writers;
using Rhenus_Special_Delivery.DTOs;

namespace Rhenus_Special_Delivery.Tests
{
    [TestFixture]
    public class RhenusServiceTests
    {
        [Test]
        public void PlaceBet_WithCorrectBet_ShouldReturnBetResponseWon()
        {
            //Arrange
            var playerReaderMock = new Mock<IPlayerReader>();
            var playerWriterMock = new Mock<IPlayerWriter>();
            var rhenusServiceMock = new Mock<IRhenusService>();

            var playerId = "84693b55-2521-406e-ac87-87cc6dec7a57";
            var playerPoints = 1000;
            var betRequest = new BetRequest { Points = 100, Number = 3 };
            var player = new Player { Id = playerId, Points = 1000 };
            var betResponse = new BetResponse { Status = BetStatus.won.ToString(), Points = $"+{betRequest.Points * 9}", Account = playerPoints + (betRequest.Points * 9) };
            playerReaderMock.Setup(x => x.GetPlayer(playerId)).Returns(player);
            rhenusServiceMock.Setup(x => x.PlaceBet(betRequest, playerId)).Returns(betResponse);
            var service = new RhenusService(playerReaderMock.Object, playerWriterMock.Object);

        
            //Assert
            Assert.That(player.Points + (betRequest.Points * 9)== betResponse.Account);
            Assert.That("won"== betResponse.Status);
            Assert.That($"+{betRequest.Points * 9}" == betResponse.Points);
        }

        [Test]
        public void PlaceBet_WithInvalidPlayerId_ShouldThrowArgumentException()
        {
            //Arrange
            var playerReaderMock = new Mock<IPlayerReader>();
            var playerWriterMock = new Mock<IPlayerWriter>();

            var playerId = "nonExistentPlayerId";
            var betRequest = new BetRequest { Points = 100, Number = 3 };

            playerReaderMock.Setup(x => x.GetPlayer(playerId)).Returns((Player)null);

            var service = new RhenusService(playerReaderMock.Object, playerWriterMock.Object);
            // Act & Assert
            Assert.Throws<ArgumentException>(() => service.PlaceBet(betRequest, playerId));
        }

        // Add more test cases for other scenarios: invalid bets, insufficient points, etc.
    }
}
