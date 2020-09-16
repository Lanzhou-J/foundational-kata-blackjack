using System;

namespace BlackJack
{
    public enum Rank
    {
      Ace,
      Two,
      Three,
      Four,
      Five,
      Six,
      Seven,
      Eight,
      Nine,
      Ten,
      Jack,
      Queen,
      King
    }
    
    public enum Suit
    {
        Spade,
        Heart,
        Diamond,
        Club
    }
    
    
    public class Card
    {
        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public Rank Rank { get; private set; }
        public Suit Suit { get; private set; }

        public string DisplayCard()
        {
            var newString = ($"[{Rank.ToString()}, {Suit.ToString()}]");
            return newString;
        }

    }
}