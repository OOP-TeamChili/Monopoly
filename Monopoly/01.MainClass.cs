namespace Monopoly
{
    using System;
    using System.Threading;
    using System.IO;
    using ConsoleStuffs;

    class MainClass
    {
        static void Main()
        {
            int playersCount = new int();
            bool isGameOver = false;

            #region Console and font resizing and intro screen
            //resize the console 
            ConsoleHelper.SetConsoleFont(8); //Set the font size to  the smallest possible
            Console.WindowHeight = Console.LargestWindowHeight - 1;
            Console.WindowWidth = Console.LargestWindowWidth - 4;
            ConsoleUtils.CenterConsole();
            //SplashScreen.splashScreen();
           // SplashScreen.WellcomeScreen();
            #endregion Console and font resizing and intro screen

            //#region PlayersCount
            //while (true)
            //{
            //    Console.Write("Type number of players as number on a single line : [2 , 3 or 4] : ");
            //    string playerCountAsString = Console.ReadLine();

            //    if (int.TryParse(playerCountAsString, out playersCount))
            //    {
            //        playersCount = int.Parse(playerCountAsString);



            //        if (playersCount > 1 && playersCount <= 4)
            //        {
            //            // here will be player initializing and all this will goes to method or class playerInitializing
            //            // for now it will be here so you can understand it easly
            //            break;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Invalid Input!");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid Input!");
            //    }
            //}

            //#endregion PlayersCount

            //#region playersInitializing
            //Player[] players = new Player[playersCount];

            //if (playersCount == 2)
            //{
            //    Console.Write("Enter 1st player's name : ");
            //    players[0] = new Player(1, Console.ReadLine());
            //    Console.Write("Enter 2nd player's name : ");
            //    players[1] = new Player(2, Console.ReadLine());

            //    //TODO Trqbva da e v masiv za da moje da se izvikvat pored
            //}
            //if (playersCount == 3)
            //{
            //    Console.Write("Enter 1st player's name : ");
            //    players[0] = new Player(1, Console.ReadLine());
            //    Console.Write("Enter 2nd player's name : ");
            //    players[1] = new Player(2, Console.ReadLine());
            //    Console.Write("Enter 3rd player's name : ");
            //    players[2] = new Player(3, Console.ReadLine());
            //}
            //if (playersCount == 4)
            //{
            //    Console.Write("Enter 1st player's name : ");
            //    players[0] = new Player(1, Console.ReadLine());
            //    Console.Write("Enter 2nd player's name : ");
            //    players[1] = new Player(2, Console.ReadLine());
            //    Console.Write("Enter 3rd player's name : ");
            //    players[2] = new Player(3, Console.ReadLine());
            //    Console.Write("Enter 4th player's name : ");
            //    players[3] = new Player(4, Console.ReadLine());
            //}
            //#endregion playersInitializingplayer

           
            //Тук му подаваме кординати при инициализация на нов зар и печата рандом пъти рандом зар от заровете, вкарани в масив от матрици в класа зар. Печата ги един върху друг и използва Thread.Sleep за да се вижда добре и да не ги дава прекалено бързо. Заровете зарежда от папка Dices в Files и ги тъпче в матрици. 

            // Има проблем, че когато се инициализира втори зар обаче се държи неадекватно и печата джиджуфляци
            //Направил съм го с Multiple Threading за да се движат и въртят паралелно заровете и започна да ги чупи 

            //Първоначалното ми решение :
            //Направих клас SecondDice и наследих Dice там, и първия път заработи коректно, а от втория опит пак се чупиха по същия начин с начупването. Направих тест с ReferenceEquals, и там изкара FALSE, което е супер, но не
            //разбирам защо се чупи.
            //После създадох метод в класа Зар, който прави дълбоко копиране на обекта и би трябвало да се държи
            //като супер различен обект, но не. Сега зара си работи коректно, само че два НЕ могат да работят заедно.
            

            Dice firstDice = new Dice(10,5);
            //SecondDice secondDice = new SecondDice(50, 25);
            var thirdPoint = firstDice.Clone(20,30);

            //firstDice.ShowDiceRotation();
            Thread firstThread = new Thread(new ThreadStart(firstDice.ShowDiceRotation));
            firstThread.Start();
            //thirdPoint.ShowDiceRotation();
            Thread secondThread = new Thread(new ThreadStart(thirdPoint.ShowDiceRotation));
            //thirdPoint.ShowDiceRotation();
            //firstThread.Start();
             secondThread.Start();
            
        }
    }
}
