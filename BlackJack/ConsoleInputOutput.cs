using System;

namespace BlackJack
{
    public class ConsoleInputOutput: IInputOutput
    {
        public string Ask(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
        
        public void Output(string message)
        {
            Console.WriteLine(message);
        }
    }
}