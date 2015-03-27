using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Monopoly
{
    public class PropertySpace:purchasableSpace
    {
        public int NumberOfhouses { get; set; }
        public int Hotel { get; set; }

        public int RentWithOneHouse { get; private set; }
        public int RentWithTwoHouses { get; private set; }
        public int RentWithThreeHouses { get; private set; }
        public int RentWithFourHouses { get; private set; }
        public int RentWithHotel { get; private set; }
        public PropertySpace(string currentName, decimal currentPrice, decimal currentMortgageValue, decimal currentRent,
            int rentWithOneHouse, int rentWithTwoHouses, int rentWithThreeHouses, int rentWithFourHouses, int rentWithHotel)
            : base(currentName, currentPrice, currentMortgageValue, currentRent)
        {
            this.NumberOfhouses = 0;
            this.Hotel = 0;
            this.RentWithOneHouse = rentWithOneHouse;
            this.RentWithTwoHouses = rentWithTwoHouses;
            this.RentWithThreeHouses = rentWithThreeHouses;
            this.RentWithFourHouses = rentWithFourHouses;
            this.RentWithHotel = rentWithHotel;
        }       
    }
}
