using System;
using System.Linq;

namespace BlackJack
{
    public class ConsoleInputOutput: IInputOutput
    {
        public string Ask(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        
        public void Output(string message)
        {
            Console.WriteLine(message);
        }

        public void Output(Deck deck)
        {
            foreach (var cardString in deck.Cards.Select(card => card.ToString()))
            {
                Console.WriteLine(cardString);
            }
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}