using IZT6ZK.Assists;
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
        
        ConsoleHelper.WriteQuit();

        while (true)
        {
            Console.WriteLine("\nThe possible topics: ");
            var allTopics = dbManager.SelectAllTopic();
            foreach (var allTopic in allTopics)
            {
                Console.WriteLine($"{allTopic.TopicId}: {allTopic.TopicName}");
            }

            inputTopicId = ConsoleHelper.ReadAndWrite("the topic's id, you want to delete");
            inputTopicId = ValidateInputs.ValidateInputsIfEmptyOrQuit(inputTopicId);

            if (inputTopicId == String.Empty)
            {
                continue;
            }
            if (inputTopicId == "quit")
            {
                Console.WriteLine("You quitted!\n");
                break;
            }
            int.TryParse(inputTopicId, out var topicId);
            var topicEntity = dbManager.SelectTopic(topicId);

            if (topicEntity != null)
            {
                Console.WriteLine("Are you sure? Yes or No");
                var yesOrNo = Console.ReadLine();
                yesOrNo = yesOrNo.Trim().ToLower();

                if (yesOrNo == "no")
                {
                    Console.WriteLine("You didn't delete the topic!");
                    continue;
                }
                else if (yesOrNo == "yes")
                {
                    dbManager.DeleteTopic(topicEntity);
                    Console.WriteLine("\nCongratulations, you deleted the topic!\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Please write 'yes' or 'no'!");
                    continue;
                }
            }
            Console.WriteLine("Please write an existing topic id!");
            continue;

        }
    }
}
