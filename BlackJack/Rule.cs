using System;
using System.Linq;

namespace BlackJack
{
    public class Rule
    {
        public int CalculateSum(Deck deck)
        {
            var sum = 0;
            foreach (var card in deck.Cards)
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

            if (sum <= 11 && deck.Cards.Any(i=> i.CardFace==CardFace.Ace))
            {

                sum = sum - 1 + 11;
            }

            return sum;
        }
        
        public bool DetermineBust(Deck deck)
        {
            return CalculateSum(deck) > 21;
        }
        
        public bool DetermineBlackjack(Deck deck)
        {
            
            return CalculateSum(deck) == 21;
        }
    }
}