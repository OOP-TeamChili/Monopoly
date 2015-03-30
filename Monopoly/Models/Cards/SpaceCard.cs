namespace Monopoly.Cards
{
    using Monopoly.Interfaces;
    using Monopoly.Players;

    public class SpaceCard : ChanceCard, ISavable
    {
        private Space spaceToGo;

        //constructor for a card that takes the player to specific space.
        //this consutrcor can be used for GetOutOfJail free card. No separate class as it is only 1 of a kind.
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

        public void AddToPlayer(Player player)
        {
            player.KeepCard(new SpaceCard(this.SpaceToGo));
        }
    }
}
