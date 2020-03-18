using System;
using Poker.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Poker.Domain.Card;
using Poker.Contracts.V1.Responses;

namespace Poker.Services.PokerServices
{
    public interface IPokerService
    {
        bool AddPlayerCard(string Name, string[] cardHand, data values);

        bool DeleteAll();
        bool CheckPokerWinner();
        Dictionary<CardSuits, int> IdentifySuit(Card pokerCards);
        Dictionary<CardRank, int> IdentifyRank(Card pokerCards);

        int handScore(Card pokerCards);
        PokerResponse GetPokerWinner();
    }
}
