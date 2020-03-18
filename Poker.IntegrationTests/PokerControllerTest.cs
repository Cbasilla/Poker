using FluentAssertions;
using Poker.Contracts.V1;
using Poker.Contracts.V1.Requests;
using Poker.Contracts.V1.Responses;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using static Poker.Domain.Card;

namespace Poker.IntegrationTests
{
    public class PokerControllerTest : IntegrationTest
    {
        [Fact]
        public async Task checkPoker_WhenValidCards_ReturnsPokerWinner_RoyalFlush_FourOfAKind_FullHouse()
        {
            // Arrange
            var data = new List<Domain.PokerData>();
            String[,] cards = new String[3, 5]
                {
                    { "6D", "6S", "6H", "3C", "3S" },
                    { "9H", "9S", "9C", "9D", "3D" },
                    { "AH", "10H", "JH", "QH", "KH" }
                };

            String[] Names = new string[3] { "Jon", "Jae", "Joe" };

            for (int i = 0; i < 3; i++)
            {
                String[] card = new string[5];
                for (int j = 0; j < 5; j++)
                {
                    card[j] = cards[i, j];
                }

                data.Add(new Domain.PokerData
                {
                    Name = Names[i],
                    playerCards = card,
                });
            }
            // Act
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Poker.GetPokerWinner, new PokerRequest
            {
                data = data,
            });

            // Assert
            var returnedPost = await response.Content.ReadAsAsync<PokerResponse>();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            returnedPost.WinnerName.Should().Be(Names[2]);
            foreach(var player in returnedPost.data)
            {
                if(player.Name == Names[2])
                    player.PokerHand.Should().Be(PokerHandRanks.RoyalFlush.ToString());
                if (player.Name == Names[1])
                    player.PokerHand.Should().Be(PokerHandRanks.FourOfAKind.ToString());
                if (player.Name == Names[0])
                    player.PokerHand.Should().Be(PokerHandRanks.FullHouse.ToString());
            }
        }
        [Fact]
        public async Task checkPoker_WhenValidCards_ReturnsPokerWinner_StraightFlush_Flush_Straight()
        {
            // Arrange
            var data = new List<Domain.PokerData>();
            String[,] cards = new String[3, 5]
                {
                    { "2H", "7H", "AH", "JH", "4H" },
                    { "7D", "8D", "9D", "10D", "JD" },
                    { "3D", "4C", "5D", "6S", "7H" }
                };

            String[] Names = new string[3] { "Joe", "Jon", "Jae" };

            for (int i = 0; i < 3; i++)
            {
                String[] card = new string[5];
                for (int j = 0; j < 5; j++)
                {
                    card[j] = cards[i, j];
                }

                data.Add(new Domain.PokerData
                {
                    Name = Names[i],
                    playerCards = card,
                });
            }
            // Act
            var response = await TestClient.PostAsJsonAsync(ApiRoutes.Poker.GetPokerWinner, new PokerRequest
            {
                data = data,
            });

            // Assert
            var returnedPost = await response.Content.ReadAsAsync<PokerResponse>();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            returnedPost.WinnerName.Should().Be(Names[1]);
            foreach (var player in returnedPost.data)
            {
                if (player.Name == Names[1])
                    player.PokerHand.Should().Be(PokerHandRanks.StraightFlush.ToString());
                if (player.Name == Names[0])
                    player.PokerHand.Should().Be(PokerHandRanks.Flush.ToString());
                if (player.Name == Names[2])
                    player.PokerHand.Should().Be(PokerHandRanks.Straight.ToString());
            }
        }
    }
}
