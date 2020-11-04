using System;
using System.Collections.Generic;
using static System.Linq.Enumerable;

namespace BlackJack
{
    public class Deck:IDeck
    {
        public List<Card> Cards { get; }
        public int Sum { get; private set; }

        public Deck()
        {
            Cards = CreateADeck();
            Sum = 0;
        }
        
        public Deck(List<Card> cards)
        {
            Cards = cards;
            Sum = CalculateSum();
        }
        public List<Card> CreateADeck()
        {
            var newList = (from CardFace name in Enum.GetValues(typeof(CardFace)) from Suit suitName in Enum.GetValues(typeof(Suit)) select new Card(name, suitName)).ToList();
            var shuffledList = newList.OrderBy(x => Guid.NewGuid()).ToList();
            return shuffledList;
        }

        public Card PopCard()
        {
            var firstCard = Cards[0];
            Cards.Remove(firstCard);
            return firstCard;
        }
        
        public void DrawCard(Card card)
        {
            Cards.Add(card);
            Sum = CalculateSum();
        }

        private int CalculateSum()
        {
            var sum = 0;
            foreach (var card in Cards)
            {
                if (card.CardFace == CardFace.Jack || card.CardFace == CardFace.Queen || card.CardFace == CardFace.King)
                {
                    sum += 10;
                }
                else
                {
                    var i = Convert.ToInt32(card.CardFace);
                    sum += i;
                }
            }

            if (sum <= 11 && Cards.Any(i=> i.CardFace==CardFace.Ace))
            {

                sum = sum - 1 + 11;
            }

            return sum;
        }
    }
}