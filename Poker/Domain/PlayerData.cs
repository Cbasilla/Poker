using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Poker.Domain.Card;

namespace Poker.Domain
{
    public class PlayerData
    {
        public string Name { get; set; }
        public string[] playerCards { get; set; }
        public string PokerHand { get; set; }
    }
}
