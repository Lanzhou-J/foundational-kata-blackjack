using System.Net;

namespace BlackJack
{
    public static class GameInstructions
    {
        public static string PlayerCardsAndSum(int sum, string deckString)
        {
            return $"You are currently at: {sum}\n"
                   + "with a hand of: \n"
                   + $"{deckString}";
        }
        
        public static string DealersTurnMessage()
        {
            return "Dealers turn to play...";
        }
        
        public static string DealerBustMessage()
        {
            return "The dealer has busted. Player is the winner!!";
        }

        public static string DealerDrawNewCard()
        {
            return "Dealer draws a new card:";
        }

        public static string PlayerGotBlackJack()
        {
            return "Player has got Blackjack!!! Yay!";
        }

        public static string DealerFirstTwoCards()
        {
            return "The dealers first two cards are:";
        }

        public static string PlayerBustMessage()
        {
            return "Player is busted. Dealer wins!!";
        }
    }
}