namespace Monopoly
{
    using System;
    public class MoveCard : ChanceCard
    {
        private const int MinSquaresToMove = 0;
        //private const int MaxSquaresToMove = Max element of the field. - Add it please :)
        
        private int squaresToMove;

        //Constructor for card that will only move player
        public MoveCard(int moveSquares)
        {
            this.SquaresToMove = moveSquares;
        }

        //constructor for cards that will move the player and money will be exchanged.
        public MoveCard(int moveSquares, CardType type, decimal howMuch)
            : base(type, howMuch)
        {
            this.SquaresToMove = moveSquares;
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
    }
}
