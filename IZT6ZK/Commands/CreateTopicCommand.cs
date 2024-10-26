using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IZT6ZK.Db;

namespace IZT6ZK.Commands;

internal class CreateTopicCommand : ICommands
{
    public void Execute()
    {
        DbManager dbManager = new DbManager();
        string? inputTopicName;
        Console.WriteLine("\nWrite 'quit' if you want to quit\n");

        while (true)
        {
            Console.WriteLine("Write your topic's name (for example: cats): ");
            inputTopicName = Console.ReadLine();

            if (string.IsNullOrEmpty(inputTopicName) || string.IsNullOrWhiteSpace(inputTopicName))
            {
                Console.WriteLine("Write something please!");
                continue;
            }
            inputTopicName = inputTopicName.Trim();

            if (inputTopicName == "quit")
            {
                Console.WriteLine("You quit \n");
                break;
            }
            dbManager.CreateTopic(inputTopicName);
            Console.WriteLine("Congratulations, you created a topic!\n");
            break;
        }
    }
}
