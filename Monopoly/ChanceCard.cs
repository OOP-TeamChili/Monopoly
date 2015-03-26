namespace Monopoly
{
    using System;
    public class ChanceCard : NotPurchasableSpace
    {
        private const int MinSquaresToMove = 0;
        //private const int MaxSquaresToMove = Max element of the field. - Add it please :)
        private const decimal MinCash = 0;

        private int squaresToMove;
        private decimal cash;
        private bool payFee; // if true the card will be Bad, if false, the card will be Luck as the player will receive money.
        private Space spaceToGo;

        //Constructor for card that will only move player
        public ChanceCard(int moveSquares)
        {
            this.SquaresToMove = moveSquares;
            this.Cash = 0;
            this.PayFee = false;
        }

        //constructor for cards that will pay the player or will make him/her pay.
        public ChanceCard(bool pay, decimal howMuch)
        {
            this.squaresToMove = 0;
            this.Cash = howMuch;
            this.PayFee = pay;
        }

        //constructor for cards that will move the player and money will be exchanged.
        public ChanceCard(int moveSquares, bool pay, decimal howMuch) : this(pay, howMuch)
        {
            this.SquaresToMove = moveSquares;
        }

        //constructor for a card that takes the player to specific space.
        public ChanceCard(Space space)
        {
            this.SpaceToGo = space;
        }

        //constructor for a card that takes the player to a space and the player pays or get paid.
        public ChanceCard(Space space, bool pay, decimal howMuch) : this(pay, howMuch)
        {
            this.SpaceToGo = space;
        }

        public int SquaresToMove
        {
            get
            {
                return this.squaresToMove;
            }
            private set
            {
                if (value < MinSquaresToMove /* || value > MaxSquaresToMove */)
                {
                    throw new ArgumentOutOfRangeException("Invalid position to move from the chance card");
                }

                this.squaresToMove = value;
            }
        }

        public decimal Cash
        {
            get
            {
                return this.cash;
            }
            private set
            {
                if (value < MinCash)
                {
                    throw new ArgumentOutOfRangeException("You cannot create a card with minumum cash to pay or be paid");
                }

                this.cash = value;
            }
        }

        public bool PayFee
        {
            get
            {
                return this.payFee;
            }

            private set
            {
                this.payFee = value;
            }
        }

        public Space SpaceToGo
        {
            get
            {
                return this.spaceToGo;
            }
            private set
            {
                this.spaceToGo = value;
            }
        }
    }
}
