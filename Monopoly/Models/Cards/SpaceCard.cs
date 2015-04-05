﻿namespace Monopoly.Cards
{
    using Monopoly.Interfaces;
    using Monopoly.Players;

    public class SpaceCard : ChanceCard, ISavable
    {
        private int positionToGo;

        //constructor for a card that takes the player to specific space.
        public SpaceCard(string currentDescription, int positionToGo,CardType type) : base(currentDescription, type)
        {
            this.PositionToGo = positionToGo;
        }

        //constructor for a card that takes the player to a space and the player pays or get paid.
       // public SpaceCard(string currentDescription, int positionToGo, CardType type, decimal howMuch)
       //     : base(currentDescription, type, howMuch)
       // {
       //     this.PositionToGo = positionToGo;
       // }

        public int PositionToGo
        {
            get
            {
                return this.positionToGo;
            }
            private set
            {
                this.positionToGo = value;
            }
        }

        public void AddToPlayer(Player player)
        {
            //TODO: check why this is added
            //player.KeepCard(new SpaceCard(this.Description, this.positionToGo, this.CardType));
        }

       
    }
}
