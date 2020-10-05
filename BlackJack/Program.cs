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
            // Card firstCard = new Card(CardFace.Eight, Suit.Diamond);
            // Card secondCard = new Card(CardFace.Seven,Suit.Heart);
            // Card thirdCard = new Card(CardFace.Nine,Suit.Spade);
            // //
            // List<Card> newList = new List<Card>();
            // newList.Add(firstCard);
            // newList.Add(secondCard);
            // newList.Add(thirdCard);
            
            // Console.WriteLine("Welcome to Blackjack!");
            //
            Player newPlayer = new Player(name: "Liv");
            newPlayer.PrintHandCard();

            Dealer newDealer = new Dealer(name: "Lan");

            Deck newDeck = new Deck();
            
            Game newGame = new Game(newPlayer, newDealer, newDeck);
            newGame.Start();
            // Console.WriteLine("New Dealers cards in hand: ");
            // newDealer.PrintHandCard();
            //
            // Console.WriteLine("New Players cards in hand: ");
            // newPlayer.PrintHandCard();
            //
            // Console.WriteLine("Players sum: ");
            // Console.WriteLine(newPlayer.Sum());
            //
            // Console.WriteLine("Dealers sum: ");
            // Console.WriteLine(newDealer.Sum());
            
            
            // var shuffledCards = new Deck();
            // var newListOfCards = shuffledCards.CreateADeck();
            // var lastCardInList = newListOfCards[51];
            // var randomCard = shuffledCards.DrawCard(newListOfCards);
            // Console.WriteLine(randomCard.FormatCardString());

            // var playerChosenInput = new PlayerInput();
            // playerChosenInput.CollectInput();


        }
    }
}