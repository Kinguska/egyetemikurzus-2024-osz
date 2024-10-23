using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK
{
    internal record class StopCommand : ICommands
    {
        public void execute()
        {
            Environment.Exit(0);
        }
    }

}
