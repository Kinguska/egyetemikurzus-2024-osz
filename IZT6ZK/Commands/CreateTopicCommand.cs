using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IZT6ZK.Assists;
using IZT6ZK.Db;

namespace IZT6ZK.Commands;

internal class CreateTopicCommand : ICommands
{
    public void Execute()
    {
        DbManager dbManager = new DbManager();
        string? inputTopicName = null;

        ConsoleHelper.WriteQuit();

        while (true)
        {
            inputTopicName = ConsoleHelper.ReadAndWrite("your topic's name (for example: cats)");
            inputTopicName = ValidateInputs.ValidateInputsIfEmptyOrQuit(inputTopicName);

            if (inputTopicName == String.Empty)
            {
                continue;
            }
            if (inputTopicName == "quit")
            {
                Console.WriteLine("You quitted!\n");
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
