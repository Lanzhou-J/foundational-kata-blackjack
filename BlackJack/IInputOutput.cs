namespace BlackJack
{
    public interface IInputOutput
    {
        public string Ask(string question);

        void Output(string message);
    }
}