namespace Monopoly.GameLogic
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;

    using Monopoly.Cards;
    using Monopoly.Dices;
    using Monopoly.Interfaces;
    using Monopoly.Players;
    using MonopolyConsoleClient;

    public class GameManager
    {
        private const int DiceMinValue = 1;
        private const int DiceMaxValue = 6;
        private const int PositionsOnBoard = 40;
        private const int CycleCash = 200;
        private static GameManager instance;
        private IDrawingEngine drawEngine;
        private IDice dice;

        private GameManager(IDrawingEngine drawEngine)
        {
            this.DrawEngine = drawEngine;
            this.Dice = new Dices(5, 0);
        }

        public static GameManager GetInstance(IDrawingEngine drawEngine)
        {
            if (GameManager.instance == null)
            {
                GameManager.instance = new GameManager(drawEngine);
            }

            return GameManager.instance;
        }

        public IDrawingEngine DrawEngine
        {
            get
            {
                return this.drawEngine;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("An implementation of the IDrawEngine class must be provided.");
                }

                this.drawEngine = value;
            }
        }

        private IDice Dice
        {
            get
            {
                return this.dice;
            }

            set
            {
                this.dice = value;
            }
        }
        public void Draw()
        {

            StreamReader reader = new StreamReader(@"../../../Monopoly/Files/field.txt");
            using (reader)
            {
                string currentLine = reader.ReadLine();
                int row = 0;
                while (currentLine != null)
                {
                    for (int i = 0; i < currentLine.Length; i++)
                    {
                        this.drawEngine.DrawText(0, row, currentLine);
                    }
                    row++;
                    currentLine = reader.ReadLine();
                }
            }
        }
        public void Game(Player[] players)
        {


            List<Space> listOfSpaces = new List<Space>();
            int pairs = 0;

            //ChanceSpace ChanceSpaceObject=new ChanceSpace();
            CommunityChestSpace communityChestSpaceObject = new CommunityChestSpace();
            ChanceSpace chanceSpaceObject = new ChanceSpace();
            ParkingSpace parking = new ParkingSpace();

            listOfSpaces.Add(parking);
            PropertySpace oldKentRoad = new PropertySpace("Old Kent Road", 60, 30, 2, 10, 30, 90, 160, 250, Color.Brown);
            listOfSpaces.Add(oldKentRoad);
            listOfSpaces.Add(communityChestSpaceObject);
            PropertySpace whiteChappelRoad = new PropertySpace("White Chapel Road", 60, 30, 4, 20, 60, 180, 320, 450, Color.Brown);
            listOfSpaces.Add(whiteChappelRoad);
            Tax incomeTax = new Tax(200);
            listOfSpaces.Add(incomeTax);
            RailRoad kingsCrossStation = new RailRoad("Kings Cross Station", 200, 100, 25);
            listOfSpaces.Add(kingsCrossStation);
            PropertySpace theAngleIslington = new PropertySpace("The Angel Islington", 100, 50, 6, 30, 90, 270, 400, 550, Color.LightBlue);
            listOfSpaces.Add(theAngleIslington);
            listOfSpaces.Add(chanceSpaceObject);
            PropertySpace eustonRoad = new PropertySpace("Euston Road", 100, 50, 6, 30, 90, 270, 400, 550, Color.LightBlue);
            listOfSpaces.Add(eustonRoad);
            PropertySpace pentonvilleRoad = new PropertySpace("Pentonville Road", 120, 60, 8, 40, 100, 300, 450, 600, Color.LightBlue);
            listOfSpaces.Add(pentonvilleRoad);
            Jail jail = new Jail();
            listOfSpaces.Add(jail);
            PropertySpace pallMall = new PropertySpace("Pall Mall", 140, 70, 10, 50, 150, 450, 625, 750, Color.Pink);
            listOfSpaces.Add(pallMall);
            UtilitySpace electricCompany = new UtilitySpace("Electric Company", 150, 75, 30);
            listOfSpaces.Add(electricCompany);
            PropertySpace whitehall = new PropertySpace("Whitehall", 140, 70, 10, 50, 150, 450, 625, 750, Color.Pink);
            listOfSpaces.Add(whitehall);
            PropertySpace nortamberLandAvenue = new PropertySpace("Northumberland avenue", 160, 80, 12, 60, 180, 500, 700, 900, Color.Pink);
            listOfSpaces.Add(nortamberLandAvenue);
            RailRoad marylibone = new RailRoad("Marylibone station", 200, 100, 25);
            listOfSpaces.Add(marylibone);
            PropertySpace bawStreet = new PropertySpace("Bow Street", 180, 90, 14, 70, 200, 550, 750, 950, Color.Orange);
            listOfSpaces.Add(bawStreet);
            listOfSpaces.Add(communityChestSpaceObject);
            PropertySpace marlboroStreet = new PropertySpace("Marlborough Street", 180, 90, 14, 70, 200, 550, 750, 950, Color.Orange);
            listOfSpaces.Add(marlboroStreet);
            PropertySpace vineStreet = new PropertySpace("Vine Street", 200, 100, 16, 80, 220, 600, 800, 1000, Color.Orange);
            listOfSpaces.Add(vineStreet);
            listOfSpaces.Add(parking);
            PropertySpace strand = new PropertySpace("Strand", 200, 110, 18, 90, 250, 700, 875, 1050, Color.Red);
            listOfSpaces.Add(strand);
            listOfSpaces.Add(chanceSpaceObject);
            PropertySpace fleetStreet = new PropertySpace("Fleet Street", 220, 110, 18, 90, 250, 700, 875, 1050, Color.Red);
            listOfSpaces.Add(fleetStreet);
            PropertySpace trafalfarQuare = new PropertySpace("Trafalgar Square", 240, 120, 20, 100, 300, 750, 925, 1100, Color.Red);
            listOfSpaces.Add(trafalfarQuare);
            RailRoad fanchurchStation = new RailRoad("Fanchurch Station", 200, 100, 25);
            listOfSpaces.Add(fanchurchStation);
            PropertySpace leicesterSquare = new PropertySpace("Leicester square", 260, 130, 22, 110, 330, 800, 975, 1150, Color.Yellow);
            listOfSpaces.Add(leicesterSquare);
            PropertySpace coventryStreet = new PropertySpace("Coventry Street", 260, 130, 22, 110, 330, 800, 975, 1150, Color.Yellow);
            listOfSpaces.Add(coventryStreet);
            UtilitySpace waterCompany = new UtilitySpace("Water Company", 150, 75, 30);
            listOfSpaces.Add(waterCompany);
            PropertySpace piccadilly = new PropertySpace("Piccadilly", 280, 140, 22, 120, 360, 850, 1025, 1200, Color.Yellow);
            listOfSpaces.Add(piccadilly);
            GoToPrison gotoPrison = new GoToPrison();
            listOfSpaces.Add(gotoPrison);
            PropertySpace oxfordStreet = new PropertySpace("Oxford Street", 300, 150, 26, 130, 390, 900, 1100, 1275, Color.Green);
            listOfSpaces.Add(oxfordStreet);
            PropertySpace regentStreet = new PropertySpace("Regent Street", 300, 150, 26, 130, 390, 900, 1100, 1275, Color.Green);
            listOfSpaces.Add(regentStreet);
            listOfSpaces.Add(communityChestSpaceObject);
            PropertySpace bondStreet = new PropertySpace("Bond Street", 320, 160, 28, 150, 450, 1000, 1200, 1400, Color.Green);
            listOfSpaces.Add(bondStreet);
            RailRoad liverpoolStation = new RailRoad("Liverpool Station", 200, 100, 25);
            listOfSpaces.Add(liverpoolStation);
            listOfSpaces.Add(chanceSpaceObject);
            PropertySpace parkLane = new PropertySpace("Park Lane", 350, 175, 35, 175, 500, 1100, 1300, 1500, Color.DarkBlue);
            listOfSpaces.Add(parkLane);
            Tax superTax = new Tax(100);
            listOfSpaces.Add(superTax);
            PropertySpace mayfair = new PropertySpace("Mayfair", 400, 200, 50, 200, 600, 1400, 1700, 2000, Color.DarkBlue);
            listOfSpaces.Add(mayfair);
            this.DrawEngine.ClearScreen();
            int currentPlayerCounter = 0;

            //While LOOP for the game logic - it iterates over each player
            Draw();
            while (true)
            {
                //Dices dices = new Dices(5, 0);
                this.Dice.Roll();
                //dices.FirstDiceValue = 5;
                //dices.SecondDiceValue = 3;
                //this.DrawEngine.DrawDices(dices.FirstDiceValue, dices.SecondDiceValue);
                this.DrawEngine.DrawText(40, 25, string.Format("{0} {1}", this.Dice.FirstDiceValue, this.Dice.SecondDiceValue));
                //Console.WriteLine(dices.FirstDiceValue);
                //Console.WriteLine(dices.SecondDiceValue); 

                if (this.Dice.FirstDiceValue == this.Dice.SecondDiceValue)
                {
                    pairs++;
                    if (pairs == 3)
                    {
                        //TO DO: player goes to prison
                    }
                }

                //Defining which player's turn is
                var player = players[currentPlayerCounter];
                player.Position = (player.Position + this.Dice.FirstDiceValue + this.Dice.SecondDiceValue) % listOfSpaces.Count;

                MovePlayer(player);

                if (player.Position > PositionsOnBoard - 1)
                {
                    player.Position = player.Position - PositionsOnBoard;
                    player.AddCash(CycleCash);
                }
                //Definig where this player is
                var currentSpace = listOfSpaces[player.Position];

                CheckSpaces(players, listOfSpaces, communityChestSpaceObject,
                    chanceSpaceObject, currentPlayerCounter, player, currentSpace);

                //TODO:PLAYER WANTS TO BUILD HOUSES AND HOTEL SOMEWHERE     

                if (this.Dice.FirstDiceValue != this.Dice.SecondDiceValue)
                {
                    currentPlayerCounter++;
                    if (currentPlayerCounter > players.Length - 1)
                    {
                        currentPlayerCounter = 0;
                    }
                }
            }
        }

        private void MovePlayer(Player player)
        {
            int oldX = player.PosX;
            int oldY = player.PosY;
            if (player.Position <= 10)
            {  
                player.PosX = 110 + player.PlayerNumber - player.Position * 11;
                player.PosY = 72;            
            }

            else if (player.Position > 10 && player.Position < 20)
            {  
                player.PosX=player.PlayerNumber;
                player.PosY=72 - (player.Position - 10) * 7;
            }
            else if (player.Position == 20)
            {  
                player.PosX = player.PlayerNumber;
                player.PosY = 1;
            }
            else if (player.Position >= 21 && player.Position < 30)
            {                
                player.PosX = player.PlayerNumber + (player.Position - 20) * 11;
                player.PosY = 7;
            }
            else if (player.Position > 30 && player.Position < 40)
            { 
                player.PosX = 110 + player.PlayerNumber;
                player.PosY = 2 + (player.Position - 30) * 7;
            }

            this.DrawEngine.DrawPlayer(player, oldX, oldY);
        }



        private void CheckSpaces(Player[] players, List<Space> listOfSpaces, CommunityChestSpace CommunityChestSpaceObject, ChanceSpace ChanceSpaceObject, int currentPlayerCounter, Player player, Space currentSpace)
        {
            //Case if the Player stepped on a property space
            if (currentSpace is PropertySpace)
            {
                SteppedOnPropertySpace(players, listOfSpaces, currentPlayerCounter, player, currentSpace);
            }
            //Case if the Player stepped on a Utility space
            if (currentSpace is UtilitySpace)
            {
                SteppedOnUtilitySpace(players, listOfSpaces, currentPlayerCounter, player, currentSpace);
            }
            //Case if the Player stepped on a RailRoad space
            if (currentSpace is RailRoad)
            {
                SteppedOnRailRoadSpace(players, listOfSpaces, currentPlayerCounter, player, currentSpace);
            }
            //Case if the Player stepped on a Chance space
            if (currentSpace is ChanceSpace)
            {
                SteppedOnChanceSpace(players, listOfSpaces, CommunityChestSpaceObject, ChanceSpaceObject,
                    currentPlayerCounter, player, currentSpace);
            }
            //Case if the Player stepped on a Community Chest Space
            if (currentSpace is CommunityChestSpace)
            {
                SteppedOnCommunityChestSpace(players, listOfSpaces, CommunityChestSpaceObject, ChanceSpaceObject,
                    currentPlayerCounter, player, currentSpace);
            }
            if (currentSpace is Tax)
            {
                Tax currentTaxSpace = (Tax)currentSpace;
                player.RemoveCash(currentTaxSpace.TaxToPay);
            }
            if (currentSpace is GoToPrison)
            {
                player.Position = 10;
                currentSpace = listOfSpaces[player.Position];
                CheckSpaces(players, listOfSpaces, CommunityChestSpaceObject, ChanceSpaceObject, currentPlayerCounter, player, currentSpace);
            }           
            //TODO PLAYER IS ON JAIL SPACE
        }

        private void SteppedOnChanceSpace(Player[] players, List<Space> listOfSpaces,
            CommunityChestSpace CommunityChestSpaceObject, ChanceSpace ChanceSpaceObject,
            int currentPlayerCounter, Player player, Space currentSpace)
        {
            ChanceCard drawChanceCard = ChanceSpaceObject.ChanceCardPull();
            if (drawChanceCard is SpaceCard)
            {
                SpaceCard drawChanceCardAsSpaceCard = drawChanceCard as SpaceCard;
                player.Position = drawChanceCardAsSpaceCard.PositionToGo;
                currentSpace = listOfSpaces[player.Position];
                CheckSpaces(players, listOfSpaces, CommunityChestSpaceObject, ChanceSpaceObject, currentPlayerCounter, player, currentSpace);
            }
            if (drawChanceCard is MoveCard)
            {
                MoveCard drawChanceCardAsMoveCard = drawChanceCard as MoveCard;
                player.Position = drawChanceCardAsMoveCard.SquaresToMove + player.Position;
                currentSpace = listOfSpaces[player.Position];
                CheckSpaces(players, listOfSpaces, CommunityChestSpaceObject, ChanceSpaceObject, currentPlayerCounter, player, currentSpace);
            }
            if (drawChanceCard is GoodLuckCard)
            {
                GoodLuckCard drawChanceCardAsMoveCard = drawChanceCard as GoodLuckCard;
                player.AddCash((int)drawChanceCardAsMoveCard.Cash);
            }
        }

        private void SteppedOnCommunityChestSpace(Player[] players, List<Space> listOfSpaces,
            CommunityChestSpace CommunityChestSpaceObject, ChanceSpace ChanceSpaceObject, int currentPlayerCounter,
            Player player, Space currentSpace)
        {
            ChanceCard drawCommunityChestCard = CommunityChestSpaceObject.ChanceCardPull();
            if (drawCommunityChestCard is SpaceCard)
            {
                SpaceCard drawChanceCardAsSpaceCard = drawCommunityChestCard as SpaceCard;
                player.Position = drawChanceCardAsSpaceCard.PositionToGo;
                currentSpace = listOfSpaces[player.Position];
                CheckSpaces(players, listOfSpaces, CommunityChestSpaceObject, ChanceSpaceObject, currentPlayerCounter, player, currentSpace);
            }
            if (drawCommunityChestCard is MoveCard)
            {
                MoveCard drawChanceCardAsMoveCard = drawCommunityChestCard as MoveCard;
                player.Position = drawChanceCardAsMoveCard.SquaresToMove + player.Position;
                currentSpace = listOfSpaces[player.Position];
                CheckSpaces(players, listOfSpaces, CommunityChestSpaceObject, ChanceSpaceObject, currentPlayerCounter, player, currentSpace);
            }
            if (drawCommunityChestCard is GoodLuckCard)
            {
                GoodLuckCard drawChanceCardAsMoveCard = drawCommunityChestCard as GoodLuckCard;
                player.AddCash((int)drawChanceCardAsMoveCard.Cash);
            }
        }

        private void SteppedOnRailRoadSpace(Player[] players, List<Space> listOfSpaces, int currentPlayerCounter, Player player, Space currentSpace)
        {
            RailRoad currentRailroadSpace = (RailRoad)currentSpace;
            if (currentRailroadSpace.Owned == false)
            {
                FreeSpace(players, listOfSpaces, currentPlayerCounter, player, currentRailroadSpace);
                player.OwnedStations = currentRailroadSpace.Owned == true ?
                    player.OwnedStations + 1 :
                    player.OwnedStations;
            }
            else if (currentRailroadSpace.Owned == true &&
              !player.ListOfProperties.Contains(listOfSpaces[player.Position]))
            {
                OtherPlayerOwnRailRoad(players, listOfSpaces, player, currentRailroadSpace);
            }
        }

        private void SteppedOnUtilitySpace(Player[] players, List<Space> listOfSpaces, int currentPlayerCounter, Player player, Space currentSpace)
        {
            UtilitySpace currentUtilitySpace = (UtilitySpace)currentSpace;
            if (currentUtilitySpace.Owned == false)
            {
                FreeSpace(players, listOfSpaces, currentPlayerCounter, player, currentUtilitySpace);
                player.OwnedUtilities = currentUtilitySpace.Owned == true ?
                    player.OwnedUtilities + 1 :
                    player.OwnedUtilities;
            }
            else if (currentUtilitySpace.Owned == true &&
              !player.ListOfProperties.Contains(listOfSpaces[player.Position]))
            {
                OtherPlayerOwnUtility(players, listOfSpaces, player, currentUtilitySpace);
            }
        }

        private void SteppedOnPropertySpace(Player[] players, List<Space> listOfSpaces, int currentPlayerCounter, Player player, Space currentSpace)
        {
            PropertySpace currentPropertySpace = (PropertySpace)currentSpace;
            if (currentPropertySpace.Owned == false)
            {
                FreeSpace(players, listOfSpaces, currentPlayerCounter, player, currentPropertySpace);
            }
            else if (currentPropertySpace.Owned == true &&
                !player.ListOfProperties.Contains(listOfSpaces[player.Position]))
            {
                OtherPlayerOwn(players, listOfSpaces, player, currentPropertySpace);
            }

        }

        private void OtherPlayerOwnUtility(Player[] players, List<Space> listOfSpaces, Player player, UtilitySpace currentUtilitySpace)
        {
            for (int i = 0; i < players.Length; i++)
            {
                var otherPlayer = players[i];
                if (otherPlayer.ListOfProperties.Contains(listOfSpaces[player.Position]))
                {
                    PayingMoney(player, (int)currentUtilitySpace.Rent * otherPlayer.OwnedUtilities, otherPlayer);
                }
            }
        }

        private void OtherPlayerOwnRailRoad(Player[] players, List<Space> listOfSpaces, Player player, RailRoad currentRailRoadSpace)
        {
            for (int i = 0; i < players.Length; i++)
            {
                var otherPlayer = players[i];
                if (otherPlayer.ListOfProperties.Contains(listOfSpaces[player.Position]))
                {
                    PayingMoney(player, (int)currentRailRoadSpace.Rent * otherPlayer.OwnedStations, otherPlayer);
                }
            }
        }

        //Method for FREE PROPERTY SPACE - player has to make decision whether he want to buy it or not
        private void FreeSpace(Player[] players, List<Space> listOfSpaces, int currentPlayer, Player player, PurchasableSpace currentPropertySpace)
        {
            this.DrawEngine.DrawText(40, 30, "Player to decide - buy(1) OR pass(2)");
            int decision = int.Parse(Console.ReadLine());
            if (decision == 1)
            {
                if (player.Bankroll < currentPropertySpace.BuyingPrice)
                {
                    this.DrawEngine.DrawText(0, 1, "Not Enough Money To Buy The Property");
                }
                else
                {
                    player.Bankroll = player.Bankroll - (int)currentPropertySpace.BuyingPrice;
                    player.AddSpace(currentPropertySpace);
                    currentPropertySpace.Owned = true;
                }
            }
        }

        //IF someone else OWNS THE SPACE - player has to PAY
        private void OtherPlayerOwn(Player[] players, List<Space> listOfSpaces, Player player, PropertySpace currentPropertySpace)
        {
            for (int i = 0; i < players.Length; i++)
            {
                var otherPlayer = players[i];
                if (otherPlayer.ListOfProperties.Contains(listOfSpaces[player.Position]))
                {
                    if (currentPropertySpace.NumberOfhouses == 0 && currentPropertySpace.Hotel == 0)
                    {
                        PayingMoney(player, (int)currentPropertySpace.Rent, otherPlayer);
                    }
                    else if (currentPropertySpace.NumberOfhouses == 1 && currentPropertySpace.Hotel == 0)
                    {
                        PayingMoney(player, (int)currentPropertySpace.RentWithOneHouse, otherPlayer);
                    }
                    else if (currentPropertySpace.NumberOfhouses == 2 && currentPropertySpace.Hotel == 0)
                    {
                        PayingMoney(player, (int)currentPropertySpace.RentWithTwoHouses, otherPlayer);
                    }
                    else if (currentPropertySpace.NumberOfhouses == 3 && currentPropertySpace.Hotel == 0)
                    {
                        PayingMoney(player, (int)currentPropertySpace.RentWithThreeHouses, otherPlayer);
                    }
                    else if (currentPropertySpace.NumberOfhouses == 4 && currentPropertySpace.Hotel == 0)
                    {
                        PayingMoney(player, (int)currentPropertySpace.RentWithFourHouses, otherPlayer);
                    }
                    else if (currentPropertySpace.NumberOfhouses == 0 && currentPropertySpace.Hotel == 1)
                    {
                        PayingMoney(player, (int)currentPropertySpace.RentWithHotel, otherPlayer);
                    }
                }
            }
        }

        //THE ACTUAL PAYMENT is HERE
        private void PayingMoney(Player player, int moneyToPay, Player otherPlayer)
        {

            if (player.Bankroll - moneyToPay < 0)
            {
                Console.WriteLine("Do you want to see your properties:");
                Console.WriteLine("Yes(1) or No(2)");
                int decision = int.Parse(Console.ReadLine());
                while (true)
                {
                    if (decision != 1 && decision != 2)
                    {
                        Console.WriteLine("Try again to choose.");
                        decision = int.Parse(Console.ReadLine());
                    }
                    else
                    {
                        break;
                    }
                }

                if (decision == 1)
                {
                    ShowPlayerProperties(player);
                    int mortgagePropertiesValue = 0;
                    while (player.Bankroll + mortgagePropertiesValue - moneyToPay < 0)
                    {
                        Console.WriteLine("Enter the numbers in list the Properties to mortgage (ex. 1,2...):");
                        string inputNumbers = Console.ReadLine();
                        int[] propertiesToMortgage = inputNumbers.Split(new char[] { ',' },
                            StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                        for (int i = 0; i < propertiesToMortgage.Length; i++)
                        {
                            mortgagePropertiesValue = mortgagePropertiesValue + (int)player.ListOfProperties[propertiesToMortgage[i]].MortgageValue;
                        }

                        if (player.Bankroll + mortgagePropertiesValue - moneyToPay >= 0)
                        {
                            for (int j = 0; j < propertiesToMortgage.Length; j++)
                            {
                                player.ListOfProperties[propertiesToMortgage[j]].Mortgaged = true;
                                player.Bankroll = player.Bankroll + (int)player.ListOfProperties[propertiesToMortgage[j]].MortgageValue;
                            }

                            player.RemoveCash(moneyToPay);
                            otherPlayer.AddCash(moneyToPay);
                        }
                        else if (player.Bankroll + mortgagePropertiesValue - moneyToPay < 0
                            && propertiesToMortgage.Length < player.ListOfProperties.Count)
                        {
                            mortgagePropertiesValue = 0;
                        }
                        else
                        {
                            //TO DO: player is bankrupt
                        }
                    }
                }
            }
            else
            {
                player.RemoveCash(moneyToPay);
                otherPlayer.AddCash(moneyToPay);
            }

        }

        private void ShowPlayerProperties(Player player)
        {
            for (int i = 0; i < player.ListOfProperties.Count; i++)
            {
                Console.WriteLine("Number in List:{0} Name:{1} Price:{2} ", i + 1,
                    player.ListOfProperties[i].Name, player.ListOfProperties[i].BuyingPrice);
                Console.WriteLine("Selling Price:{0} Mortgaged:{1}", player.ListOfProperties[i].SellingPrice, player.ListOfProperties[i].Mortgaged);
                Console.WriteLine("Mortgage value:{0}", player.ListOfProperties[i].MortgageValue);
                Console.WriteLine("-----------------");
            }
        }
    }
}


