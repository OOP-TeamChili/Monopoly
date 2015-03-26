﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly.GameLogic
{
    class GameManager
    {
        const int DiceMinValue = 1;
        const int DiceMaxValue = 6;
        const int PositionsOnBoard = 42;
        const int CycleCash = 200;
        public static void Game(Player[] players)
        {
            List<Space> listOfSpaces = new List<Space>();
            int pairs = 0;
            //PROPERTIES JUST FOR EXAMPLE
            for (int i = 0; i < 42; i++)
            {
                string propertyName = "Property" + i;
                PropertySpace newProperty = new PropertySpace(propertyName, i * 10 + 2, i * 10 / 2 + 2, i + 5,i+200,i+250,i+300,i+350,i+500);
                listOfSpaces.Add(newProperty);
            }
            Console.Clear();
            int currentPlayerCounter = 0;
            while (true)
            {
                Dice dice1 = new Dice();
                Dice dice2 = new Dice();
                Random rand = new Random();                            
                dice1.ValueDice = rand.Next(DiceMinValue, DiceMaxValue + 1);
                dice2.ValueDice = rand.Next(DiceMinValue, DiceMaxValue + 1);
                Console.WriteLine(dice1.ValueDice);
                Console.WriteLine(dice2.ValueDice);
                if (dice1.ValueDice == dice2.ValueDice)
                {
                    pairs++;
                    if (pairs == 3)
                    {
                        //TO DO: player goes to prison
                    }
                }
                var player = players[currentPlayerCounter];
                player.Position = player.Position + dice1.ValueDice + dice2.ValueDice;
                    ;                
                if (player.Position > PositionsOnBoard - 1)
                {
                    player.Position = player.Position - PositionsOnBoard;
                    player.AddCash(CycleCash);
                }
                var currentSpace = listOfSpaces[player.Position];
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
                //TODO:PLAYER WANTS TO BUILD HOUSES AND HOTEL SOMEWHERE
                //TODO:currentSpace is Utility
                //TODO:currentSpace is RailRoad
                //TODO:currentSpace is BadLuckCard
                //TODO:currentSpace is LuckySpace
                //TODO:currentSpace is GoodLuckCard
                //TODO:currentSpace is parking
                //TODO:currentSpace is Jail/JustVisiting
                if (dice1.ValueDice != dice2.ValueDice)
                {
                    currentPlayerCounter++;
                    if (currentPlayerCounter > players.Length - 1)
                    {
                        currentPlayerCounter = 0;
                    }
                }             
               

            }
        }

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

        private static void FreeSpace(Player[] players, List<Space> listOfSpaces, int currentPlayer, Player player, PropertySpace currentPropertySpace)
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
    }
}
        
    