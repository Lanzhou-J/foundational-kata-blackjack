using System.Xml;

namespace BlackJack
{
    public class Card
    {
        public Card(CardFace cardFace, Suit suit, int uniqueId)
        {
            CardFace = cardFace;
            Suit = suit;
            UniqueId = uniqueId;
        }

        public CardFace CardFace { get; private set; }
        public Suit Suit { get; private set; }

        public int UniqueId { get; private set; }

        public string FormatCardString()
        {
            var newString = ($"[{CardFace.ToString()}, {Suit.ToString()}]");
            return newString;
        }

    }
}