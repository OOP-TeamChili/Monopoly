using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStuffs
{
    public static class SplashScreen
    {
        public static void splashScreen()
        {
            StreamReader splashScreenReader = new StreamReader(@"../../Files/SplashScreen.txt");
            using (splashScreenReader)
            {
                string currentLine = splashScreenReader.ReadLine();
                while (currentLine != null)
                {
                    Console.WriteLine(String.Format("      {0}", currentLine));
                    currentLine = splashScreenReader.ReadLine();
                }
            }
        }
        public static void WellcomeScreen()
        {
            Console.WriteLine("                                                                 WELLCOME TO MONOPOLY MULTIPLAYER");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
