using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Commands
{
    internal record class ExitCommand : ICommands
    {
        public void execute()
        {
            Environment.Exit(0);
        }
    }

}
