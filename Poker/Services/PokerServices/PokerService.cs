using Poker.Contracts.V1.Responses;
using Poker.Domain;
using Poker.Services.CardService;
using System;
using System.Collections.Generic;
using static Poker.Domain.Card;

namespace Poker.Services.PokerServices
{
    public class PokerService : IPokerService
    {
        private readonly List<Card> _pokerCard;
        private readonly ICardService _cardService;

        public PokerService(ICardService cardService)
        {
            _pokerCard = new List<Card>();
            _cardService = cardService;
        }
        public bool AddPlayerCard(string Name, string[] cardHand, data values)
        {
            _pokerCard.Add(new Card
            {
                Name = Name,
                playerCards = cardHand,
                playerCardsRank = values.rankList,
                playerCardsSuit = values.suitsList,
            });

            return true;
        }
        public bool CheckPokerWinner()
        {
            bool IsRoyalFlush = true;
            bool IsFlush = true;
            foreach (Card playerCard in _pokerCard)
            {
                Dictionary<CardSuits, int> SuitDict = IdentifySuit(playerCard);
                Dictionary<CardRank, int> RankDict = IdentifyRank(playerCard);

                
                if (SuitDict.Count == 1)
                {
                    // Royal flush
                    IsRoyalFlush = CheckRoyalFlush(playerCard);
                    // Straight Flush & Flush
                    if (!IsRoyalFlush)
                        IsFlush = CheckFlush(playerCard);
                }
                // full house
                CheckFullHouse(playerCard, RankDict);
                if (SuitDict.Count == 4)
                {
                    if (RankDict.Count == 2)
                    {
                        //four of a kind
                        CheckFourOfKind(playerCard, RankDict);
                    }
                    // Straight
                    if (!IsRoyalFlush && !IsFlush)
                        CheckStraight(playerCard);
                }
                // high card
                playerCard.Score = handScore(playerCard);
                if(playerCard.Score > 40 && playerCard.Type == PokerHandRanks.None)
                {
                    playerCard.Type = PokerHandRanks.HighCard;
                }
            }

            _pokerCard.Sort();

            return true;
        }
        public PokerResponse GetPokerWinner()
        {
            PokerResponse res = new PokerResponse();
            res.data = new List<PlayerData>();
            int count = 1;
            foreach (Card playerCard in _pokerCard)
            {
                if(count == 1)
                {
                    res.WinnerName = playerCard.Name;
                }
                res.data.Add(new PlayerData
                {
                    Name = playerCard.Name,
                    playerCards = playerCard.playerCards,
                    Type = playerCard.Type.ToString()
                });
                count++;
            }
            DeleteAll();
            _cardService.DeleteAll();
            return res;
        }
        public Dictionary<CardSuits, int> IdentifySuit(Card pokerCards)
        {
            Dictionary<CardSuits, int> dict = new Dictionary<CardSuits, int>();

            foreach (CardSuits suit in pokerCards.playerCardsSuit)
            {
                if (dict.ContainsKey(suit))
                    dict[suit]++;
                else
                    dict[suit] = 1;
            }

            return dict;
        }
        public Dictionary<CardRank, int> IdentifyRank(Card pokerCards)
        {
            Dictionary<CardRank, int> dict = new Dictionary<CardRank, int>();

            foreach (CardRank rank in pokerCards.playerCardsRank)
            {
                if (dict.ContainsKey(rank)) 
                    dict[rank]++;
                else 
                    dict[rank] = 1;
            }

            return dict;
        }

        public int handScore(Card pokerCards)
        {
            int score = 0;

            foreach (CardRank rank in pokerCards.playerCardsRank)
            {
                score += (int)rank;
            }

            return score;
        }
        public CardRank[] handSort(Card pokerCards)
        {
            Array.Sort(pokerCards.playerCardsRank);
            return pokerCards.playerCardsRank;
        }

        public bool CheckRoyalFlush(Card playerCard)
        {
            if (handScore(playerCard) == (int)PokerHandRanks.RoyalFlush)
            {
                playerCard.Score = handScore(playerCard);
                playerCard.Type = PokerHandRanks.RoyalFlush;
                return true;
            }
            return false;
        }
        public bool CheckFlush(Card playerCard)
        {
            bool check = false;
            CardRank[] rank = handSort(playerCard);
            for (int i = 0; i < rank.Length; i++)
            {
                if ((i + 1) == rank.Length)
                {
                    break;
                }
                else
                {
                    int diff = rank[i + 1] - rank[i];
                    if (diff == 1)
                    {
                        playerCard.Score = handScore(playerCard);
                        playerCard.Type = PokerHandRanks.StraightFlush;
                        check = true;
                        return check;
                    }
                    else
                    {
                        playerCard.Score = handScore(playerCard);
                        playerCard.Type = PokerHandRanks.Flush;
                        check = true;
                        break;
                    }
                }
            }
            return check;
        }
        public bool CheckFourOfKind(Card playerCard, Dictionary<CardRank, int> RankDict)
        {
            foreach(var pair in RankDict)
            {
                if (pair.Value == 4)
                {
                    playerCard.Score = handScore(playerCard);
                    playerCard.Type = PokerHandRanks.FourOfAKind;
                    return true;
                }
            }
            return false;
        }
        public bool CheckFullHouse(Card playerCard, Dictionary<CardRank, int> RankDict)
        {
            if (RankDict.ContainsValue(3) && RankDict.ContainsValue(2))
            {
                playerCard.Score = handScore(playerCard);
                playerCard.Type = PokerHandRanks.FullHouse;
                return true;
            }
            return false;
        }
        public bool CheckStraight(Card playerCard)
        {
            bool check = false;
            CardRank[] rank = handSort(playerCard);
            for (int i = 0; i < rank.Length; i++)
            {
                if ((i + 1) == rank.Length)
                {
                    break;
                }
                else
                {
                    int diff = rank[i + 1] - rank[i];
                    if (diff == 1)
                    {
                        playerCard.Score = handScore(playerCard);
                        playerCard.Type = PokerHandRanks.Straight;
                        check = true;
                        return check;
                    }
                }
            }
            return check;
        }

        public bool DeleteAll()
        {
            _pokerCard.Clear();
            return true;
        }
    }
}
