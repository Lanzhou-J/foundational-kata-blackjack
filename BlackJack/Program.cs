namespace BlackJack
{
    public static class Program
    {
        static void Main()
        {
            var newPlayer = new Player();
            var newDealer = new Player();
            var newDeck = new Deck();
            var consoleInputOutput = new ConsoleInputOutput();
            var rule = new Rule();
            consoleInputOutput.Clear();
            var newGame = new Game(newPlayer, newDealer, newDeck, consoleInputOutput, rule);
            newGame.Start();
            newGame.Play();
        }
    }
}