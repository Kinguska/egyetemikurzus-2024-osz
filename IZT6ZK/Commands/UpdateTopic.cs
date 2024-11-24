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
        Console.WriteLine("\nWrite 'quit' if you want to quit\n");

        while (true)
        {
            Console.WriteLine("\nThe possible topics: ");
            var allTopics = dbManager.SelectAllTopic();
            foreach (var allTopic in allTopics)
            {
                Console.WriteLine($"{allTopic.TopicId}: {allTopic.TopicName}");
            }

            Console.WriteLine("Write the topic's id, you want to update: ");
            inputTopic = Console.ReadLine();

            if (string.IsNullOrEmpty(inputTopic) || string.IsNullOrWhiteSpace(inputTopic))
            {
                Console.WriteLine("Write something please!");
                continue;
            }
            inputTopic = inputTopic.Trim();

            if (inputTopic == "quit")
            {
                Console.WriteLine("You quitted \n");
                break;
            }
            int.TryParse(inputTopic, out var topicId);
            var topicEntity = dbManager.SelectTopic(topicId);
            if (topicEntity != null)
            {
                Console.WriteLine("Write the new topic name: ");
                var newTopicName = Console.ReadLine();
                if (string.IsNullOrEmpty(newTopicName) || string.IsNullOrWhiteSpace(newTopicName))
                {
                    Console.WriteLine("Write something please!");
                    continue;
                }
                newTopicName = newTopicName.Trim();
                if (newTopicName == "quit")
                {
                    Console.WriteLine("You quitted \n");
                    break;
                }
                topicEntity.TopicName = newTopicName;
                dbManager.UpdateTopic(topicEntity);
                Console.WriteLine("Congratulations, you updated the topic!\n");
                break;
            }
            Console.WriteLine("Please write an existing topic id!");
            continue;
        }
    }
}
