using Poker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Poker.Domain.Card;

namespace Poker.Contracts.V1.Responses
{
    public class PokerResponse
    {
        public List<PlayerData> data { get; set; }
        public string WinnerName { get; set; }

    }
}
