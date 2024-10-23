using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK
{
    internal class CommandsDict
    {
        public static Dictionary<string, ICommands> commandsDict = new Dictionary<string, ICommands>()
        {
            {"stop", new StopCommand() },
            {"exit", new StopCommand() },
        };

    }
}
