using System.Collections.Generic;
using BlackJack;
using Xunit;

namespace BlackJackTests
{
    public class RuleTests
    {

        [Fact]
         public void DetermineBlackjackShould_ReturnTrue_When21()
         {
             var rule = new Rule();
             Card newCard = new Card(CardFace.Ace, Suit.Club);
             Card newCard2 = new Card(CardFace.Ten, Suit.Club);
             Card newCard3 = new Card(CardFace.Jack, Suit.Club);
             List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
             Person newPerson = new Person(new Deck(listOfCardsForTest));
             Assert.True(rule.DetermineBlackjack(newPerson.Deck));
         }
         
         [Fact]
         public void DetermineBlackjackShould_ReturnFalse_WhenLessThan21()
         {
             var rule = new Rule();
             Card newCard = new Card(CardFace.Ace, Suit.Club);
             Card newCard2 = new Card(CardFace.Nine, Suit.Club);
             Card newCard3 = new Card(CardFace.Jack, Suit.Club);
             List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
             Person newPerson = new Person(new Deck(listOfCardsForTest));

             Assert.False(rule.DetermineBlackjack(newPerson.Deck));
         }
         
         [Fact]
         public void DetermineBlackjackShould_ReturnFalse_WhenMoreThan21()
         {
             var rule = new Rule();
             Card newCard = new Card(CardFace.Three, Suit.Club);
             Card newCard2 = new Card(CardFace.Nine, Suit.Club);
             Card newCard3 = new Card(CardFace.Jack, Suit.Club);
             List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
             Person newPerson = new Person(new Deck(listOfCardsForTest));
             Assert.False(rule.DetermineBlackjack(newPerson.Deck));
         }
         
         [Fact]
         public void DetermineBustShould_ReturnTrue_WhenOver21()
         {
             var rule = new Rule();
             Card newCard = new Card(CardFace.Three, Suit.Club);
             Card newCard2 = new Card(CardFace.Nine, Suit.Club);
             Card newCard3 = new Card(CardFace.Jack, Suit.Club);
             List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
             Person newPerson = new Person(new Deck(listOfCardsForTest));
             Assert.True(rule.DetermineBust(newPerson.Deck));
         }
         
         [Fact]
         public void DetermineBustShould_ReturnFalse_WhenLessThan21()
         {
             var rule = new Rule();
             Card newCard = new Card(CardFace.Ace, Suit.Club);
             Card newCard2 = new Card(CardFace.Nine, Suit.Club);
             Card newCard3 = new Card(CardFace.Jack, Suit.Club);
             List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
             Person newPerson = new Person(new Deck(listOfCardsForTest));
             Assert.False(rule.DetermineBust(newPerson.Deck));
         }
         
         [Fact]
         public void DetermineBustShould_ReturnFalse_When21()
         {
             var rule = new Rule();
             Card newCard = new Card(CardFace.Two, Suit.Club);
             Card newCard2 = new Card(CardFace.Nine, Suit.Club);
             Card newCard3 = new Card(CardFace.Jack, Suit.Club);
             List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
             Person newPerson = new Person(new Deck(listOfCardsForTest));
             Assert.False(rule.DetermineBust(newPerson.Deck));
         }
         
         [Fact]
         public void CalculateSum_Should_ReturnSumValueOfCardsInHandWhenThereIsOnlyOneCard()
         {
             var rule = new Rule();
             Card newCard = new Card(CardFace.Nine, Suit.Club);
             List<Card> listOfCardsForTest = new List<Card>(){newCard};
             Person newPerson = new Person(new Deck(listOfCardsForTest));
             Assert.Equal(9,rule.CalculateSum(newPerson.Deck));
         }
         
         [Fact]
         public void CalculateSum_Should_ReturnSumValueOfCardsInHandWhenThereIsMoreThanOneCard()
         {
             var rule = new Rule();
             Card newCard = new Card(CardFace.Nine, Suit.Club);
             Card newCard2 = new Card(CardFace.Jack, Suit.Club);
             List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2};
             Person newPerson = new Person(new Deck(listOfCardsForTest));
             Assert.Equal(19,rule.CalculateSum(newPerson.Deck));
         }
         
         [Fact]
         public void CalculateSumShould_Return21_WhenPlayerHasTenAndAce()
         {
             var rule = new Rule();
             Card newCard = new Card(CardFace.Ace, Suit.Club);
             Card newCard2 = new Card(CardFace.Ten, Suit.Club);
             List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2};
             Person newPerson = new Person(new Deck(listOfCardsForTest));
             Assert.Equal(21,rule.CalculateSum(newPerson.Deck));
         }
         
         [Fact]
         public void SumShould_Return21_WhenPlayerHasJackAndAce()
         {
             var rule = new Rule();
             Card newCard = new Card(CardFace.Ace, Suit.Club);
             Card newCard2 = new Card(CardFace.Jack, Suit.Club);
             List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2};
             Person newPerson = new Person(new Deck(listOfCardsForTest));
             Assert.Equal(21,rule.CalculateSum(newPerson.Deck));
         }
         
         [Fact]
         public void SumShould_Return17_WhenPlayerHasSevenNineAndAce()
         {
             var rule = new Rule();
             Card newCard = new Card(CardFace.Ace, Suit.Club);
             Card newCard2 = new Card(CardFace.Seven, Suit.Club);
             Card newCard3 = new Card(CardFace.Nine, Suit.Club);
             List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
             Person newPerson = new Person(new Deck(listOfCardsForTest));
             Assert.Equal(17,rule.CalculateSum(newPerson.Deck));
         }
         
         [Fact]
         public void SumShould_Return21_WhenPlayerHasAceNineAndAce()
         {
             var rule = new Rule();
             Card newCard = new Card(CardFace.Ace, Suit.Club);
             Card newCard2 = new Card(CardFace.Ace, Suit.Spade);
             Card newCard3 = new Card(CardFace.Nine, Suit.Club);
             List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
             Person newPerson = new Person(new Deck(listOfCardsForTest));
             Assert.Equal(21,rule.CalculateSum(newPerson.Deck));
         }
         
         [Fact]
         public void SumShould_Return21_WhenPlayerHasAceAceEightAndAce()
         {
             var rule = new Rule();
             Card newCard = new Card(CardFace.Ace, Suit.Club);
             Card newCard2 = new Card(CardFace.Ace, Suit.Spade);
             Card newCard3 = new Card(CardFace.Ace, Suit.Club);
             Card newCard4 = new Card(CardFace.Eight, Suit.Club);
             List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3, newCard4};
             Person newPerson = new Person(new Deck(listOfCardsForTest));
             Assert.Equal(21,rule.CalculateSum(newPerson.Deck));
         }
         
         [Fact]
         public void SumShould_Return14_WhenPlayerHasAceTwoAndAce()
         {
             var rule = new Rule();
             Card newCard = new Card(CardFace.Ace, Suit.Club);
             Card newCard2 = new Card(CardFace.Two, Suit.Spade);
             Card newCard3 = new Card(CardFace.Ace, Suit.Club);
             List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
             Person newPerson = new Person(new Deck(listOfCardsForTest));
             Assert.Equal(14,rule.CalculateSum(newPerson.Deck));
         }
         
         [Fact]
         public void SumShould_Return19_WhenPlayerHasEightTenAndAce()
         {
             var rule = new Rule();
             Card newCard = new Card(CardFace.Eight, Suit.Club);
             Card newCard2 = new Card(CardFace.Ten, Suit.Spade);
             Card newCard3 = new Card(CardFace.Ace, Suit.Club);
             List<Card> listOfCardsForTest = new List<Card>(){newCard, newCard2, newCard3};
             Person newPerson = new Person(new Deck(listOfCardsForTest));
             Assert.Equal(19,rule.CalculateSum(newPerson.Deck));
         }

    }
}