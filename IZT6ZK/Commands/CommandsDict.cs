using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Commands
{
    internal class CommandsDict
    {
        public static Dictionary<string, ICommands> commandsDict = new Dictionary<string, ICommands>()
        {
            //{"stop", new ExitCommand() },
            {"exit", new ExitCommand() },
            {"help", new HelpCommand() },
            {"start", new StartCommand() },
        };

    }
}
