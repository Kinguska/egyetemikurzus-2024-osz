using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK
{
    internal record class Commands
    {
        public static Dictionary<string, Action> commandsDict = new Dictionary<string, Action>();

        public Commands()
        {

            commandsDict.Add("stop", () => Environment.Exit(0));
            commandsDict.Add("exit", () => Environment.Exit(0));


        }
    }
}
