using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Poker.Domain.Card;

namespace Poker.Domain
{
    public class Card : IComparable<Card>
    {
        public string Name { get; set; }
        public string[] playerCards { get; set; }
        public CardRank[] playerCardsRank { get; set; }
        public CardSuits[] playerCardsSuit { get; set; }

        public int Score { get; set; }
        public PokerHandRanks Type { get; set; }
        public enum CardRank
        {
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            J = 11, //Jack
            Q = 12, //Queen
            K = 13, //King
            A = 14 //Ace
        };

        public enum CardSuits
        {
            //  Club: 0, Diamond : 1, Heart: 2, Spade: 3
            C, D, H, S
        }
        public enum PokerHandRanks
        {
            None = 0,
            HighCard = 2,
            Straight = 3,
            Flush = 5,
            FullHouse = 7,
            FourOfAKind = 15,
            StraightFlush = 30,
            RoyalFlush = 60,
        }
        public int CompareTo(Card other)
        {
            return other.Score.CompareTo(this.Score);
        }
        public virtual bool isNull()
        {
            return false;
        }
    }
    public class data
    {
        public bool exist { get; set; }
        public CardRank rank { get; set; }
        public CardRank[] rankList { get; set; }
        public CardSuits[] suitsList { get; set; }
    }

    public class NullCard : Card
    {
        public override bool isNull()
        {
            return true;
        }
        public NullCard(PokerHandRanks type, int score)
        {
            this.Score = score;
            this.Type = type;
        }
        private static Card instance = new NullCard(PokerHandRanks.None, 0);

        public static Card Instance
        {
            get { return instance; }
        }
    }
}
