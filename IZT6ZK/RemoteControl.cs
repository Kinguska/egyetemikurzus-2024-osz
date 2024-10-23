using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK
{
    internal class RemoteControl
    {
        private ICommands _commands;
        public void setCommand(ICommands commands)
        {
            _commands = commands;
        }
        public void ExecuteCommand()
        {
            _commands.execute();
        }
    }
}
