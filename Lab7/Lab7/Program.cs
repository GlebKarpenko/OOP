using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Lab7
{
    class ExecuteCommand
    {
        string commandName;
        public ExecuteCommand(string name, string[] allCommands)
        {
            commandName = name;
        }
    }

    class ConfigReader
    {
        private List<string> keys;

        public ConfigReader()
        {
            
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.start();
        }
    }
}