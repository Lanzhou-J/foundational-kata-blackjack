using System;

namespace BlackJack
{
    public class Game
    {
        public void Start()
        {
            Console.Clear();
            var newPlayerInput = new PlayerInput();
            newPlayerInput.CollectInput();
        }

        public void CheckForWinner()
        {
        }

        public void CheckForGameEnd()
        {
        }
    }
}