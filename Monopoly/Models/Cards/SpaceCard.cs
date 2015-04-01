namespace Monopoly.Cards
{
    using Monopoly.Interfaces;
    using Monopoly.Players;

    internal class SpaceCard : ChanceCard, ISavable
    {
        private Space spaceToGo;

        //constructor for a card that takes the player to specific space.
        public SpaceCard(string currentDescription, Space space, CardType type) : base(currentDescription, type)
        {
            this.SpaceToGo = space;
        }

        //constructor for a card that takes the player to a space and the player pays or get paid.
        public SpaceCard(string currentDescription, Space space, CardType type, decimal howMuch)
            : base(currentDescription, type, howMuch)
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
            player.KeepCard(new SpaceCard(this.Description, this.SpaceToGo, this.CardType));
        }
    }
}
