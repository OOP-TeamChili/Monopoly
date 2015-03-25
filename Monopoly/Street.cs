namespace Monopoly
{
    using System;
    using System.Collections.Generic;

    public class Street 
        //: Property
    {
        private const byte MinBuildings = 0;
        private const byte MaxBuildings = 4;

        private List<Building> buildings;
        private Color color;

        public Street(string currentName, Color currentColor, decimal currentPrice, decimal currentMortgageValue, decimal currentRent, decimal currentBuildingBuyPrice, decimal currentBuildingSellPrice)
           // : base(currentName, currentPrice, currentMortgageValue, currentRent)
        {
            this.Color = currentColor;
            this.buildings = new List<Building>();            
        }


        public Color Color
        {
            get
            {
                return this.color;
            }
            private set
            {
                //no check - Color is enum
                this.color = value;
            }
        }

        public byte NumberOfBuildings
        {
            get
            {
                return (byte)buildings.Count;
            }
        }

        public List<Building> Buildings
        {
            get
            {
                return new List<Building>(buildings);
            }
        }

        public void Build(Building building)
        {
            this.buildings.Add(building);
        }

        public void Demolish(Building building)
        {
            this.buildings.Remove(building);
        }

        
    }
}
