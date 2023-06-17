using System;
using System.Configuration;
using System.Net.Sockets;
using System.Reflection;

namespace Lab7
{
    class Command
    {
        protected string[] value;
        protected List<string> parameters;
        protected List<string> messages;

        public Command()
        {

        }

        public Command(string input)
        {
            input += " ";
            value = input.Split(" ");
        }

        public bool existsAsCommand(AllCommands possibleCommands)
        {
            if (containsRightCommand(possibleCommands.allCommands) && containsRightParameter(possibleCommands.allParameters))
            {
                return true;
            }
            return false;
        }

        bool containsRightCommand(List<string> commands)
        {
            if (commands.Contains(value[0]))
            {
                return true;
            }
            return false;
        }

        bool containsRightParameter(List<string> parameters)
        {
            if (value.Length == 1)
            {
                return true;
            }
            for (int i = 0; i < value.Length; i++)
            {
                Console.WriteLine(parameters[i], value[i]);
                if (parameters.Contains(value[i]))
                {
                    return true;
                }
            }
            return false;
        }
    }

    class HelpCommand : Command
    {
        public HelpCommand()
        {
            try
            {
                getHelpMessages();
            }
            catch
            {
                Console.WriteLine("!ERROR!: Unable to get help message.");
            }
        }

        void getHelpMessages()
        {
            Input helpMessages = new Input(ConfigurationManager.AppSettings["help-messages-names"]);
            string[] allMessageNames = helpMessages.getAsArray();
            foreach (string messageName in allMessageNames)
            {
                messages.Add(ConfigurationManager.AppSettings[messageName]);
            }
        }

        public void execute()
        {
            foreach (string message in  messages)
            {
                Console.WriteLine(message);
            }
        }
    }

    class AllCommands
    {
        public List<string> allCommands;
        public List<string> allParameters;

        public AllCommands()
        {
            Input commands = new Input(ConfigurationManager.AppSettings["all-command-names"]);
            Input parameters = new Input(ConfigurationManager.AppSettings["all-parameter-names"]);
            allCommands = new List<string>(commands.getAsArray());
            allParameters = new List<string>(parameters.getAsArray());
        }
    }
}
