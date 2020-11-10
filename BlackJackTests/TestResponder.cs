using System.Collections.Generic;
using BlackJack;

namespace BlackJackTests
{
    public class TestResponder: IInputOutput
    {
        private readonly Queue <string>_testResponses = new Queue<string>();
        
        public TestResponder(IEnumerable<string> testResponse)
        {
            foreach (var response in testResponse)
            {
                _testResponses.Enqueue(response);
            }
        }
        
        public string Ask(string question)
        {
            var response = _testResponses.Dequeue();
            return response;
        }

        public void Output(string message)
        {
        }

        public void Output(Deck deck)
        {
        }

        public void Clear()
        {
        }
    }
}