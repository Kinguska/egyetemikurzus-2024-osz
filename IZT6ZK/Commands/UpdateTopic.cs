using IZT6ZK.Assists;
using IZT6ZK.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Commands;
internal class UpdateTopic : ICommands
{
    public void Execute()
    {
        var dbManager = new DbManager();
        string? inputTopic;
        
        ConsoleHelper.WriteQuit();

        while (true)
        {
            var allTopics = dbManager.SelectAllTopic();

            if (allTopics.Count == 0)
            {
                Console.WriteLine("There is no topic in the database!");
                break;
            }

            ConsoleHelper.WriteOutAllTopics(allTopics);

            inputTopic = ConsoleHelper.ReadAndWrite("the topic's id, you want to update");
            inputTopic = ValidateInputs.ValidateInputsIfEmptyOrQuit(inputTopic);

            if (inputTopic == String.Empty)
            {
                continue;
            }
            if (inputTopic == "quit")
            {
                Console.WriteLine("You quitted!\n");
                break;
            }

            int.TryParse(inputTopic, out var topicId);
            var topicEntity = dbManager.SelectTopic(topicId);

            if (topicEntity != null)
            {
                var newTopicName = ConsoleHelper.ReadAndWrite("the new topic name");
                newTopicName = ValidateInputs.ValidateInputsIfEmptyOrQuit(newTopicName);

                if (newTopicName == String.Empty)
                {
                    continue;
                }
                if (newTopicName == "quit")
                {
                    Console.WriteLine("You quitted!\n");
                    break;
                }
                if (allTopics.FirstOrDefault(x => x.TopicName.ToLower() == newTopicName.ToLower()) is not null 
                    && topicEntity.TopicName.ToLower() != newTopicName.ToLower())
                {
                    Console.WriteLine("\nThis topic already exists!");
                    continue;
                }
                topicEntity.TopicName = newTopicName;
                dbManager.UpdateTopic(topicEntity);
                Console.WriteLine("\nCongratulations, you updated the topic!\n");
                break;
            }
            Console.WriteLine("Please write an existing topic id!");
            continue;
        }
    }
}
