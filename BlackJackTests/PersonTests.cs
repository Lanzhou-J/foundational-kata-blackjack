using System.Collections.Generic;
using BlackJack;
using Xunit;

namespace BlackJackTests
{
    public class PersonTests
    {
        [Fact]
        public void DetermineBlackjackShould_ReturnTrue_When21()
        { 
            // Card firstCard = new Card(CardFace.Eight, Suit.Diamond);
            // Card secondCard = new Card(CardFace.Seven,Suit.Heart);
            // Card thirdCard = new Card(CardFace.Nine,Suit.Spade);
            
            // List<Card> newList = new List<Card>();
            // newList.Add(firstCard);
            // newList.Add(secondCard);
            // newList.Add(thirdCard);
            
            Card newCard = new Card(CardFace.Ace, Suit.Club);
            Card newCard2 = new Card(CardFace.Ten, Suit.Club);
            Card newCard3 = new Card(CardFace.Jack, Suit.Club);
            List<Card> listOfCardsForTest = new List<Card>();
            listOfCardsForTest.Add(newCard);
            listOfCardsForTest.Add(newCard2);
            listOfCardsForTest.Add(newCard3);
            Person newPerson = new Person("bob", new List<Card>());
           Assert.Equal();
        }
        
        [Fact]
        public void DetermineBlackjackShould_ReturnFalse_WhenLessThan21()
        {
           
        }
        
        [Fact]
        public void DetermineBlackjackShould_ReturnFalse_WhenMoreThan21()
        {
           
        }
        
        [Fact]
        public void DetermineBustShould_ReturnTrue_WhenOver21()
        {
           
        }
        
        [Fact]
        public void DetermineBustShould_ReturnFalse_WhenLessThan21()
        {
           
        }
        
        [Fact]
        public void DetermineBustShould_ReturnFalse_When21()
        {
           
        }
    }
}