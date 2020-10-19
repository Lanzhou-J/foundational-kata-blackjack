﻿namespace BlackJack
{
    public static class Program
    {
        static void Main()
        {
            var newPlayer = new Player();
            newPlayer.PrintHandCard();

            var newDealer = new Dealer();

            var newDeck = new Deck();
            
            var console = new ConsoleInputOutput();
            
            var newGame = new Game(newPlayer, newDealer, newDeck, console);
            newGame.Start();
        }
    }
}