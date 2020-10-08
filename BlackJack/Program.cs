using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace BlackJack
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player newPlayer = new Player(name: "Liv");
            newPlayer.PrintHandCard();

            Dealer newDealer = new Dealer(name: "Lan");

            Deck newDeck = new Deck();
            
            ConsoleInputOutput console = new ConsoleInputOutput();
            
            Game newGame = new Game(newPlayer, newDealer, newDeck, console);
            newGame.Start();
        }
    }
}