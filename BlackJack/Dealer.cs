using System;
using System.IO;
using System.Text.RegularExpressions;
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
            PrintHandCard();
            while (Sum() < 17)
            {
                DrawCard(cards[index]);
                index++;
                Console.WriteLine($"Dealer's sum = {Sum()}");
                PrintHandCard();
                if (DetermineBust())
                {
                    return true;
                }
            }
                
            return false;
        }

        public Dealer(List<Card> cardsInHand) : base(cardsInHand)
        {
        }
        
        public Dealer(string name) : base(name)
        {
        }
    }
}