using IZT6ZK.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Commands;
internal class UpdateQuestionsTopic : ICommands
{
    public void Execute()
    {
        var dbManager = new DbManager();
        string? inputQuestionId;
        Console.WriteLine("\nWrite 'quit' if you want to quit\n");

        while (true)
        {
            Console.WriteLine("\nThe possible questions: ");
            var allQuestions = dbManager.SelectAllQuestions();
            foreach (var allQuestion in allQuestions)
            {
                Console.WriteLine($"{allQuestion.QuestionId}: {allQuestion.Question}");
            }

            Console.WriteLine("\nWrite the question's id, you want to update: ");
            inputQuestionId = Console.ReadLine();

            if (string.IsNullOrEmpty(inputQuestionId) || string.IsNullOrWhiteSpace(inputQuestionId))
            {
                Console.WriteLine("Write something please!");
                continue;
            }
            inputQuestionId = inputQuestionId.Trim();

            if (inputQuestionId == "quit")
            {
                Console.WriteLine("\nYou quitted \n");
                break;
            }
            int.TryParse(inputQuestionId, out var questionId);
            var questionEntity = dbManager.SelectQuestion(questionId);
            if (questionEntity != null)
            {
                Console.WriteLine("\nThe possible topics: ");
                var allTopics = dbManager.SelectAllTopic();
                foreach (var allTopic in allTopics)
                {
                    Console.WriteLine($"{allTopic.TopicId}: {allTopic.TopicName}");
                }

                Console.WriteLine("\nWrite the new topic id: ");
                Console.WriteLine("If you write 'null', then no topic will be assigned.");
                var newTopicId = Console.ReadLine();
                if (string.IsNullOrEmpty(newTopicId) || string.IsNullOrWhiteSpace(newTopicId))
                {
                    Console.WriteLine("Write something please!");
                    continue;
                }
                newTopicId = newTopicId.Trim();
                if (newTopicId == "quit") {
                    Console.WriteLine("You quitted \n");
                    break;
                }
                if (newTopicId == "null")
                {
                    questionEntity.TopicId = null;
                    dbManager.UpdateQuestion(questionEntity);
                    Console.WriteLine("Congratulations, you updated the question's topic!\n");
                    break;
                }
                int.TryParse(newTopicId, out var topicId);
                var topicEntity = dbManager.SelectTopic(topicId);
                if (topicEntity != null)
                {
                    questionEntity.TopicId = topicId;
                    dbManager.UpdateQuestion(questionEntity);
                    Console.WriteLine("Congratulations, you updated the question's topic!\n");
                    break;
                }
                Console.WriteLine("Please write an existing topic id!");
                continue;
            }
            Console.WriteLine("Please write an existing question id!");
            continue;

        }
    }
}
