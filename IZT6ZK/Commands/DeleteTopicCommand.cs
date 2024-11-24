using IZT6ZK.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Commands;
internal class DeleteTopicCommand : ICommands
{
    public void Execute()
    {
        DbManager dbManager = new DbManager();
        string? inputTopicId;
        Console.WriteLine("\nWrite 'quit' if you want to quit\n");

        while (true)
        {
            Console.WriteLine("\nThe possible topics: ");
            var allTopics = dbManager.SelectAllTopic();
            foreach (var allTopic in allTopics)
            {
                Console.WriteLine($"{allTopic.TopicId}: {allTopic.TopicName}");
            }

            Console.WriteLine("\nWrite the topic's id, you want to delete: ");
            inputTopicId = Console.ReadLine();

            if (string.IsNullOrEmpty(inputTopicId) || string.IsNullOrWhiteSpace(inputTopicId))
            {
                Console.WriteLine("Write something please!");
                continue;
            }
            inputTopicId = inputTopicId.Trim();

            if (inputTopicId == "quit")
            {
                Console.WriteLine("\nYou quitted \n");
                break;
            }
            int.TryParse(inputTopicId, out var topicId);
            var topicEntity = dbManager.SelectTopic(topicId);
            if (topicEntity != null)
            {
                dbManager.DeleteTopic(topicEntity);
                Console.WriteLine("Congratulations, you deleted the topic!\n");
                break;
            }
            Console.WriteLine("Please write an existing topic id!");
            continue;

        }
    }
}
