namespace Monopoly.Cards
{
    using System;
    public class ChanceCard
    {
        private const decimal MinCash = 0;
        private const int MinDescLen = 1;

        private string description;
        private decimal cash;
        private CardType cardType;

        public ChanceCard(string currentDescription, CardType type)
        {
            this.Description = currentDescription;
            this.CardType = type;
        }

        //constructor for cards that will pay the player or will make him/her pay.
        public ChanceCard(string currentDescription, CardType type, decimal howMuch)
        {
            this.Description = currentDescription;
            this.Cash = howMuch;
            this.CardType = type;
        }


        public string Description
        {
            get
            {
                return this.description;
            }
            private set
            {
                if (value.Length < MinDescLen)
                {
                    throw new ArgumentException("Card description length lower than {0}", MinDescLen.ToString());
                }

                this.description = value;
            }
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
