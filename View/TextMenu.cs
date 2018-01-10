using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_ToyLanguage.View
{
    class TextMenu
    {
        Dictionary<string, Command> knownCommands;

        public TextMenu()
        {
            knownCommands = new Dictionary<string, Command>();
        }

        public void AddCommand(Command command)
        {
            knownCommands[command.Option] = command;
        }

        public void PrintMenu()
        {
            Console.WriteLine();
            foreach (Command c in knownCommands.Values)
                Console.WriteLine(c.ToString());
        }

        public void show()
        {
            while (true)
            {
                PrintMenu();
                Console.WriteLine();
                Console.Write("Input option -> ");

                string option = Console.ReadLine();
                if (knownCommands.ContainsKey(option))
                    knownCommands[option].Execute();
                else
                    Console.WriteLine("Invalid Option! Please try again!");
            }
        }
    }
}
