using IZT6ZK.StateMachine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Assists;
internal class ValidateInputs
{
    public static string ValidateInputsIfEmptyOrQuit(string input)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Write something please!");
            return String.Empty;
        }

        input = input.Trim();

        if (input == "quit")
        {
            return "quit";
        }
        return input;
    }

    public static string ValidateInputsIfEmptyOrQuitOrQuitAll(string input)
    {
        if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Write something please!");
            return String.Empty;
        }

        input = input.Trim();

        if (input == "quit")
        {
            return "quit";
        }
        if (input == "quit all")
        {
            return "quit all";
        }
        return input;
    }

}
