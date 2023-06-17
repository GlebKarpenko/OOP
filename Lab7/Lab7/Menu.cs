using System;
using System.Configuration;
using System.Linq;

namespace Lab7
{
    class MainMenu
    {
        //набір всіх повідомлень меню, які містяться в app.config
        Dictionary<string, string> menuMessages = new Dictionary<string, string>();

        //основне меню використовується для вводу користувачем команда та передання на їх обробку
        public MainMenu()
        {
            menuMessages.Add("instruction-message", ConfigurationManager.AppSettings["work-instruction"]);
        }

        //початок головного меню, спочатку виводиться коротка інструкція по роботі з програмою
        public void start()
        {
            Console.WriteLine(menuMessages["instruction-message"]);
            CommandInput userInput = new CommandInput();


        }
    }

    //об'єкт обробляє входження текстових даних від користувача та файлу кофігурації
    class Input
    {
        string value;

        public Input(string input)
        {
            value = input;
        }

        public string get()
        {
            return value;
        }

        //повертає отриманий рядок як масив значень
        public string[] getAsArray()
        {
            char[] removables1 = {'[', '\''};
            char[] removables2 = { '\'', ']'};

            string[] result = value.Trim(removables1).Trim(removables2).Split("', '");
            return result;
        }
    }

    class InputReader
    {
        protected Input input;

        public InputReader()
        {
            Console.Write(">");
            input = new Input(Console.ReadLine());
        }
    }

    class CommandInput : InputReader
    {
        //об'єкт вводу команд містить введену команду та набір усіх можливих
        //команд і параметрів для перевірки на правильність вводу
        Command command;
        AllCommands possibleCommands;

        public CommandInput()
        {
            command = new Command(input.get());
            possibleCommands = new AllCommands();

            if (!command.existsAsCommand(possibleCommands))
            {
                string commandError = ConfigurationManager.AppSettings["wrong-command"];
                Console.WriteLine(commandError);
                return;
            }
        }
    }
}
