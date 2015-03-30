namespace Monopoly.Cards
{
    using System;
    public abstract class ChanceCard
    {
        private const decimal MinCash = 0;

        private decimal cash;
        private CardType cardType;

        public ChanceCard()
        {

        }

        //constructor for cards that will pay the player or will make him/her pay.
        public ChanceCard(CardType type, decimal howMuch)
        {
            this.Cash = howMuch;
            this.CardType = type;
        }

              

        public decimal Cash
        {
            get
            {
                return this.cash;
            }
            protected set
            {
                if (value < MinCash)
                {
                    throw new ArgumentOutOfRangeException("You cannot create a card with minumum cash to pay or be paid");
                }

                this.cash = value;
            }
        }

        public CardType CardType
        {
            get
            {
                return this.cardType;
            }

            private set
            {
                this.cardType = value;
            }
        }

        
    }
}
