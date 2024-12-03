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
        Console.WriteLine("\nWrite 'quit' if you want to quit.");

        while (true)
        {
            Console.WriteLine("\nWrite your topic's name (for example: cats): ");
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
            var allTopics = dbManager.SelectAllTopic();
            if (allTopics.FirstOrDefault(x => x.TopicName.ToLower() == inputTopicName.ToLower()) is not null)
            {
                Console.WriteLine("This topic already exists!");
                continue;
            }
            dbManager.CreateTopic(inputTopicName);
            Console.WriteLine("\nCongratulations, you created a topic!\n");
            break;

        }
    }
}
