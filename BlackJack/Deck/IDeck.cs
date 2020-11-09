using System.Collections.Generic;

namespace BlackJack
{
    public interface IDeck
    {
        public List<Card> CreateADeck();
        public List<Card> Cards { get; }
        public Card PopCard();
        public void DrawCard(Card card);
    }
}