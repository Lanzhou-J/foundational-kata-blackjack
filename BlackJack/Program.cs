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
            Card firstCard = new Card(CardFace.Eight,Suit.Diamond);
            Card secondCard = new Card(CardFace.Seven, Suit.Heart);
            Card thirdCard = new Card(CardFace.Nine, Suit.Spade);
            List<Card> newList = new List<Card>();
            newList.Add(firstCard);
            newList.Add(secondCard);
            newList.Add(thirdCard);
            var newString = firstCard.DisplayCard();
            Console.WriteLine("Welcome to Blackjack!");
            // Console.WriteLine(newString);
            Player newPlayer = new Player(name: "Liv", isDealer: false, cardsInHand: newList);
            newPlayer.PrintHandCard();
        }
    }
}