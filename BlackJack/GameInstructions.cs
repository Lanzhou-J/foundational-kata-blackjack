using System.Net;

namespace BlackJack
{
    public static class GameInstructions
    {
        public static string PlayerStay = "0";
        public static string PlayerCardsAndSum(int sum, string deckString)
        {
            return $"You are currently at: {sum}\n"
                   + "with a hand of: \n"
                   + $"{deckString}";
        }
        
        public static string DealerCardsAndSum(int sum, string deckString)
        {
            return $"The dealer is currently at: {sum}\n"
                   + "with a hand of: \n"
                   + $"{deckString}";
        }
        
        public static string PlayersTurnMessage()
        {
            return "Player's turn to play...";
        }
        
        public static string DealersTurnMessage()
        {
            return "Dealer's turn to play...";
        }
        
        public static string PlayerBustMessage()
        {
            return "Player is busted. Dealer wins!!";
        }
        
        public static string DealerBustMessage()
        {
            return "The dealer has busted. Player is the winner!!";
        }
        
        public static string PlayerDrawNewCard()
        {
            return "Player draws a new card:";
        }

        public static string DealerDrawNewCard()
        {
            return "Dealer draws a new card:";
        }

        public static string PlayerGotBlackJack()
        {
            return "Player has got Blackjack!!! Yay!";
        }
        
        public static string AskChoiceMessage()
        {
            return "Hit or stay? (Hit = 1, Stay = 0)";
        }
        
        public static string GameResultTie()
        {
            return "Player and dealer have tied. Nobody wins.";
        }
        
        public static string GameResultPlayerWin()
        {
            return "Players hand of cards is larger. Player has won!!";
        }
        
        public static string GameResultDealerWin()
        {
            return "Dealers hand of cards is larger. Dealer has won!!";
        }


    }
}