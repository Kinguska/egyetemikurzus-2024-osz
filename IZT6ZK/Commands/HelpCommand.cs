using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Commands
{
    internal class HelpCommand : ICommands
    {
        public void execute()
        {
            Console.WriteLine("You can use these commands: ");
            foreach (var command in CommandsDict.commandsDict.Keys)
            {
                Console.Write($"{command} | ");
            }
            Console.WriteLine();
        }
    }
}
