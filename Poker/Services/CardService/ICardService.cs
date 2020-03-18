using Poker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Poker.Services.CardService
{
    public interface ICardService
    {
        data CheckCard(string scard, data values, int index);
        bool AddPlayerCard(string[] cardHand, data values);
        bool CheckRank(string rank);
        bool CheckSuit(char suit);
        bool DeleteAll();
    }
}
