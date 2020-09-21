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
            Card firstCard = new Card(CardFace.Eight, Suit.Diamond);
            Card secondCard = new Card(CardFace.Seven,Suit.Heart);
            Card thirdCard = new Card(CardFace.Nine,Suit.Spade);
            
            List<Card> newList = new List<Card>();
            // newList.Add(firstCard);
            // newList.Add(secondCard);
            // newList.Add(thirdCard);
            
            Console.WriteLine("Welcome to Blackjack!");
            
            Player newPlayer = new Player(name: "Liv", isDealer: false, cardsInHand: newList);
            newPlayer.PrintHandCard();
            
            var shuffledCards = new Deck();
            var newListOfCards = shuffledCards.CreateADeck();
            var lastCardInList = newListOfCards[51];
            var randomCard = shuffledCards.DrawCard(newListOfCards);
            Console.WriteLine(randomCard.FormatCardString());

            // var playerChosenInput = new PlayerInput();
            // playerChosenInput.CollectInput();
        }
    }
}