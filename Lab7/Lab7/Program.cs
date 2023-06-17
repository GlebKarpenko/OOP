using System;

namespace Lab7
{
    class Program
    {
        public static void Main(string[] args)
        {
            Program main = new Program();
            Console.WriteLine("Програма для роботи з трикутниками введiть команду 'help', " +
                "щоб отримати iнструкцiю з використання.");
            Menu menu1 = new Menu();
            menu1.mainMenu();
        }
    }
}