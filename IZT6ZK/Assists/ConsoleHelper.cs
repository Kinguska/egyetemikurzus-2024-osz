using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Assists;
internal class ConsoleHelper
{
    public static void WriteQuit()
    {
        Console.WriteLine("\nWrite 'quit' if you want to quit.");
    }
    public static void WriteQuitAll()
    {
        Console.WriteLine("Write 'quit all' if you want to quit all of the questions.\n");
    }
    public static string ReadAndWrite(string whatWeWantToAskFromUser)
    {
        Console.WriteLine($"Write {whatWeWantToAskFromUser}: ");
        var input = Console.ReadLine();
        return input ?? "";
    }
}
