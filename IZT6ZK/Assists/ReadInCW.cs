using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Assists;
internal class ReadInCW
{
    public string ReadAndWrite(string whatWeWantToAskFromUser)
    {
        Console.WriteLine($"Write {whatWeWantToAskFromUser}: ");
        var input = Console.ReadLine();
        return input ?? "";
    }
}
