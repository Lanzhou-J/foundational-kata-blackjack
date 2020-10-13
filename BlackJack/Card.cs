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

        public override string ToString()
        {
            var newString = ($"[{CardFace.ToString()}, {Suit.ToString()}]");
            return newString;
        }

    }
}