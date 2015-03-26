namespace Monopoly
{
    public class SpaceCard : ChanceCard
    {
        private Space spaceToGo;

        //constructor for a card that takes the player to specific space.
        public SpaceCard(Space space)
        {
            this.SpaceToGo = space;
        }

        //constructor for a card that takes the player to a space and the player pays or get paid.
        public SpaceCard(Space space, CardType type, decimal howMuch)
            : base(type, howMuch)
        {
            this.spaceToGo = space;
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
