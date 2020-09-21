using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Blackjack
{
    public class PlayerInput
    {
        private string input;
        private void Ask()
        {
            Console.WriteLine("Hit or stay? (Hit = 1, Stay = 0)");
        }

        public int CollectInput()
        {
            Ask();
            var playerChosenInput = Console.ReadLine();
            return int.Parse(playerChosenInput);
        }
    }
}