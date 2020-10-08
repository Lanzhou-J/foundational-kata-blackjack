namespace BlackJack
{
    public class Card
    {
        public Card(CardFace cardFace, Suit suit)
        {
            CardFace = cardFace;
            Suit = suit;
        }

        public CardFace CardFace { get; }
        public Suit Suit { get; }

        public string FormatCardString()
        {
            var newString = ($"[{CardFace.ToString()}, {Suit.ToString()}]");
            return newString;
        }

    }
}