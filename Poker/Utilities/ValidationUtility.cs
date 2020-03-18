using Poker.Contracts.V1.Requests;
using Poker.Domain;
using Poker.Services;
using Poker.Services.CardService;
using Poker.Services.PokerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.Utilities
{
    public class ValidationUtility
    {
        public static bool validateCards(PokerRequest pokerRequest,ICardService _cardService, IPokerService _pokerService)
        {
            foreach (PokerData data in pokerRequest.data)
            {
                string[] playerCards = data.playerCards;
                data values = new data();
                values.rankList = new Card.CardRank[playerCards.Length];
                values.suitsList = new Card.CardSuits[playerCards.Length];
                for (int i = 0; i < playerCards.Length; i++)
                {
                    values = _cardService.CheckCard(playerCards[i], values, i);
                    // validate players card
                    if (!values.exist)
                        return false;
                }
                // save players card
                _pokerService.AddPlayerCard(data.Name, playerCards, values);
            }
            return true;
        }
    }
}
