using System;
using System.Collections.Generic;

namespace BlackJack
{
    public class Dealer: Person
    {

        public bool Play(List<Card> cards)
        {
            Console.WriteLine("Dealers turn to play...\n");
            int index = 0;
            Console.WriteLine("The dealers first two cards are: \n");
            // PrintHandCard();
            Console.WriteLine($"Dealer's sum = {Sum()}");
            Console.WriteLine();
            while (Sum() < 17)
            {
                Console.WriteLine("Dealer draws a new card: ");
                Console.WriteLine();
                Deck.DrawCard(cards[index]);
                index++;
                // PrintHandCard();
                Console.WriteLine($"Dealer's sum = {Sum()}");
                Console.WriteLine();
                if (DetermineBust())
                {
                    return true;
                }
            }
            return false;
        }

        public Dealer(Deck deck) : base(deck)
        {
        }
        
        public Dealer()
        {
        }
    }
}