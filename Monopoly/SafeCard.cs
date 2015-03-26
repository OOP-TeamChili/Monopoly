namespace Monopoly
{
    using System;
    public class SafeCard : ChanceCard, ISavable //this class creates cards that can be kept by the player and are mainly discounts.
    {
        private const int MinDiscount = 0;
        private const int MaxDiscount = 100;

        private int discountInPercent;

        public SafeCard(int currentDiscount)
        {
            this.discountInPercent = currentDiscount;
            this.Cash = this.Cash * (this.DiscountInPercent / 100);
        }

        public int DiscountInPercent
        {
            get
            {
                return this.discountInPercent;
            }
            private set
            {
                if (value < MinDiscount || value > MaxDiscount)
                {
                    throw new ArgumentOutOfRangeException("Discount cannot be lesser than {0}% and greater than {1}%", MinDiscount.ToString(), MaxDiscount.ToString());
                }

                this.discountInPercent = value;
            }
        }

        public void AddToPlayer(Player player)
        {
            player.KeepCard(new SafeCard((int)this.Cash));
        }
    }
}
