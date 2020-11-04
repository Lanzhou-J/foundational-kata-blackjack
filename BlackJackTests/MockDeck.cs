using System.Collections.Generic;
using BlackJack;

namespace BlackJackTests
{
    public class MockDeck : IDeck
    {
        public List<Card> Cards { get; }
        public int Sum { get; }

        public MockDeck(List<Card>listOfCards)
        {
            Cards = listOfCards;
        }
        
        public List<Card> CreateADeck()
        {
            return new List<Card>();
        }

        public Card PopCard()
        {
            var firstCard = Cards[0];
            Cards.Remove(firstCard);
            return firstCard;
        }

        public void DrawCard(Card card)
        {
            throw new System.NotImplementedException();
        }
    }
}