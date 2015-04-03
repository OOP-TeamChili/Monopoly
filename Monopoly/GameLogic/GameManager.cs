﻿namespace Monopoly.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Monopoly.Dices;
    using Monopoly.Players;

    public class GameManager
    {
        private const int DiceMinValue = 1;
        private const int DiceMaxValue = 6;
        private const int PositionsOnBoard = 42;
        private const int CycleCash = 200;

        public static void Game(Player[] players)
        {
            List<Space> listOfSpaces = new List<Space>();
            int pairs = 0;
            //PROPERTIES JUST FOR EXAMPLE
            for (int i = 0; i < 42; i++)
            {
                string propertyName = "Property" + i;
                if (i > 12)
                {
                    PropertySpace newProperty = new PropertySpace(propertyName, i * 10 + 2, i * 10 / 2 + 2, i + 5, i + 200, i + 250, i + 300, i + 350, i + 500);

                    listOfSpaces.Add(newProperty);
                }
                else
                {
                    RailRoad  newRailRoad= new RailRoad(propertyName, 300 + i, 200 + i, 25);
                    listOfSpaces.Add(newRailRoad);
                }

                
            }

            Console.Clear();
            int currentPlayerCounter = 0;          
  
            //While LOOP for the game logic - it iterates over each player
            while (true)
            {

                Dices dices = new Dices(5, 0);
                dices.ThrowDices();         
                //dices.FirstDiceValue = 2;
                //dices.SecondDiceValue = 1;
                //Console.WriteLine(dices.FirstDiceValue);
                //Console.WriteLine(dices.SecondDiceValue);
                
                
                if (dices.FirstDiceValue == dices.SecondDiceValue)
                {
                    pairs++;
                    if (pairs == 3)
                    {
                        //TO DO: player goes to prison
                    }
                }

                //Defining which player's turn is
                var player = players[currentPlayerCounter];
                player.Position = player.Position + dices.FirstDiceValue + dices.SecondDiceValue;
                                
                if (player.Position > PositionsOnBoard - 1)
                {
                    player.Position = player.Position - PositionsOnBoard;
                    player.AddCash(CycleCash);
                }
                //Definig where this player is
                var currentSpace = listOfSpaces[player.Position];
                
                //Case if the Player stepped on a property space
                if (currentSpace is PropertySpace)
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
                if (currentSpace is UtilitySpace)
                {
                    UtilitySpace currentUtilitySpace = (UtilitySpace)currentSpace;
                    if (currentUtilitySpace.Owned == false)
                    {
                        FreeSpace(players, listOfSpaces, currentPlayerCounter, player, currentUtilitySpace);
                        player.OwnedUtilities = currentUtilitySpace.Owned == true ? 
                            player.OwnedUtilities+1 :
                            player.OwnedUtilities;
                    }
                    else if (currentUtilitySpace.Owned == true &&
                      !player.ListOfProperties.Contains(listOfSpaces[player.Position]))
                    {
                        OtherPlayerOwnUtility(players, listOfSpaces, player, currentUtilitySpace);
                    }
                }

                if (currentSpace is RailRoad)
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

                //TODO:PLAYER WANTS TO BUILD HOUSES AND HOTEL SOMEWHERE     
                
                //TODO:currentSpace is BadLuckCard
                //TODO:currentSpace is LuckySpace
                //TODO:currentSpace is GoodLuckCard
                //TODO:currentSpace is parking
                //TODO:currentSpace is Jail/JustVisiting
                if (dices.FirstDiceValue != dices.SecondDiceValue)
                {
                    currentPlayerCounter++;
                    if (currentPlayerCounter > players.Length - 1)
                    {
                        currentPlayerCounter = 0;
                    }
                }   
            }
        }

        private static void OtherPlayerOwnUtility(Player[] players, List<Space> listOfSpaces, Player player, UtilitySpace currentUtilitySpace)
        {
            for (int i = 0; i < players.Length; i++)
            {
                var otherPlayer = players[i];
                if (otherPlayer.ListOfProperties.Contains(listOfSpaces[player.Position]))
                {
                    PayingMoney(player, (int)currentUtilitySpace.Rent*otherPlayer.OwnedUtilities, otherPlayer);
                }
            }
        }

        private static void OtherPlayerOwnRailRoad(Player[] players, List<Space> listOfSpaces, Player player, RailRoad currentRailRoadSpace)
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
        private static void FreeSpace(Player[] players, List<Space> listOfSpaces, int currentPlayer, Player player, PurchasableSpace currentPropertySpace)
        {
            Console.WriteLine("Player to decide - buy(1) OR pass(2)");
            int decision = int.Parse(Console.ReadLine());
            if (decision == 1)
            {
                if (player.Bankroll < currentPropertySpace.BuyingPrice)
                {
                    Console.WriteLine("Not Enough Money To Buy The Property");
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
        private static void OtherPlayerOwn(Player[] players, List<Space> listOfSpaces, Player player, PropertySpace currentPropertySpace)
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
        private static void PayingMoney(Player player, int moneyToPay, Player otherPlayer)
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

        private static void ShowPlayerProperties(Player player)
        {
            for (int i = 0; i < player.ListOfProperties.Count; i++)
            {
                Console.WriteLine("Number in List:{0} Name:{1} Price:{2} ",i+1,
                    player.ListOfProperties[i].Name, player.ListOfProperties[i].BuyingPrice);
                Console.WriteLine("Selling Price:{0} Mortgaged:{1}", player.ListOfProperties[i].SellingPrice, player.ListOfProperties[i].Mortgaged);
                Console.WriteLine("Mortgage value:{0}", player.ListOfProperties[i].MortgageValue);
                Console.WriteLine("-----------------");
            }
        }
    }
}
        
    
