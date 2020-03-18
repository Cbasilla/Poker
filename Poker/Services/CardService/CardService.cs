using Poker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Poker.Domain.Card;

namespace Poker.Services.CardService
{

    public class CardService : ICardService
    {
        private readonly List<Card> _card;

        public CardService()
        {
            _card = new List<Card>();
        }

        public data CheckCard(string scard, data values, int index)
        {
            char[] char_arr = scard.ToCharArray();
            bool rankExist, suitExist;
            CardRank rankValue;
            CardSuits suitValue;
            if (char_arr.Length > 1 && char_arr.Length < 3)
            {
                rankExist = CheckRank(char_arr[0].ToString());
                suitExist = CheckSuit(char_arr[1]);
                rankValue = IdentifyRank(char_arr[0].ToString());
                suitValue = IdentifySuits(char_arr[1]);
            }
            else
            {
                if (char_arr.Length == 3)
                {
                    string val = new string(char_arr, 0, 2);
                    rankExist = CheckRank(val);
                    suitExist = CheckSuit(char_arr[2]);
                    rankValue = IdentifyRank(val);
                    suitValue = IdentifySuits(char_arr[2]);
                }
                else
                {
                    rankExist = false;
                    suitExist = false;
                    rankValue = 0;
                    suitValue = 0;
                }

            }
            var exist = rankExist && suitExist;

            values.exist = exist;
            values.rank = rankValue;
            values.rankList[index] = rankValue;
            values.suitsList[index] = suitValue;

            return values;
        }

        public bool CheckRank(string rank)
        {
            if (Int32.TryParse(rank, out int iRank))
            {
                if (System.Enum.IsDefined(typeof(CardRank), iRank))
                {
                    foreach (var value in Enum.GetValues(typeof(CardRank)))
                    {
                        // (CardRank)value 
                        if ((int)value == iRank)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            else
            {
                if(rank == "A" || rank == "J" || rank == "K" || rank == "Q")
                {
                    return true;
                }
                return false;
            }
        }
        public bool CheckSuit(char suit)
        {
            foreach (var value in Enum.GetValues(typeof(CardSuits)))
            {
                // 
                var cSuit = (CardSuits)value;
                if (cSuit.ToString() == suit.ToString())
                {
                    return true;
                }
            }
            return false;
        }

        public bool AddPlayerCard(string[] cardHand, data values)
        {
            _card.Add(new Card
            {
                playerCards = cardHand,
                playerCardsRank = values.rankList,
                playerCardsSuit = values.suitsList,
            });

            return true;
        }

        public CardRank IdentifyRank(string card)
        {
            if (Int32.TryParse(card, out int iRank))
            {
                if (System.Enum.IsDefined(typeof(CardRank), iRank))
                {
                    foreach (var value in Enum.GetValues(typeof(CardRank)))
                    {
                        // (CardRank)value 
                        if ((int)value == iRank)
                        {
                            return (CardRank)value;
                        }
                    }
                }
                return 0;
            }
            else
            {
                if (card == "A" || card == "J" || card == "K" || card == "Q")
                {
                    var value = Enum.Parse(typeof(CardRank), card);
                    return (CardRank)value;
                }
                return 0;
            }
        }
        public CardSuits IdentifySuits(char suit)
        {
            foreach (var value in Enum.GetValues(typeof(CardSuits)))
            {
                // 
                var cSuit = (CardSuits)value;
                if (cSuit.ToString() == suit.ToString())
                {
                    return cSuit;
                }
            }
            return 0;
        }

        public bool DeleteAll()
        {
            _card.Clear();
            return true;
        }
    }
}
