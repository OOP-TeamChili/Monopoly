using System;
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
                Random rand1 = new Random();
                Random rand2 = new Random();                
                dice1.ValueDice = rand1.Next(DiceMinValue, DiceMaxValue + 1);
                dice2.ValueDice = rand2.Next(DiceMinValue, DiceMaxValue + 1);
                Console.WriteLine(dice1.ValueDice);
                Console.WriteLine(dice2.ValueDice);
                var player = players[currentPlayerCounter];
                player.Position = player.Position + dice1.ValueDice + dice2.ValueDice;
                var currentProperty = listOfSpaces[player.Position];
                if (player.Position > PositionsOnBoard - 1)
                {
                    player.Position = player.Position - PositionsOnBoard;
                    player.AddCash(CycleCash);
                }
                if (currentProperty is PropertySpace)
                {
                    PropertySpace currentPropertySpace = (PropertySpace)currentProperty;
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
            player.RemoveCash(moneyToPay);
            if (player.Bankroll < 0)
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
                }
            }
            otherPlayer.AddCash(moneyToPay);
        }

        private static void ShowPlayerProperties(Player player)
        {
            for (int i = 0; i < player.ListOfProperties.Count; i++)
            {
                Console.WriteLine("Name:{0} Price:{1} ",
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
                if (player.Bankroll < currentPropertySpace.SellingPrice)
                {
                    Console.WriteLine("Not Enough Money To Buy The Property");
                }
                else
                {
                    player.Bankroll = player.Bankroll - (int)currentPropertySpace.SellingPrice;
                    player.AddSpace(currentPropertySpace);
                }
            }
        }
    }
}
        
    
