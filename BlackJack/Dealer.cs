namespace BlackJack
{
    public class Dealer: Person
    {

        public Dealer(Deck deck) : base(deck)
        {
        }
        
        public void Hit(Card card)
        {
            Deck.DrawCard(card);
        }
        public Dealer()
        {
        }
    }
}