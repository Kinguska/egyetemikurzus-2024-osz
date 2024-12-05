using IZT6ZK.Assists;
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

        ConsoleHelper.WriteQuit();

        while (true)
        {
            var allQuestions = dbManager.SelectAllQuestions();
            if (allQuestions.Count == 0)
            {
                Console.WriteLine("There is no question in the database!");
                break;
            }
            ConsoleHelper.WriteOutAllQuestions(allQuestions);

            /*Console.WriteLine("\nWrite the question's id, you want to update: ");
            inputQuestionId = Console.ReadLine();

            if (string.IsNullOrEmpty(inputQuestionId) || string.IsNullOrWhiteSpace(inputQuestionId))
            {
                Console.WriteLine("Write something please!");
                continue;
            }
            inputQuestionId = inputQuestionId.Trim();

            if (inputQuestionId == "quit")
            {
                Console.WriteLine("You quitted! \n");
                break;
            }*/
            inputQuestionId = ConsoleHelper.ReadAndWrite("the question's id, you want to update");
            inputQuestionId = ValidateInputs.ValidateInputsIfEmptyOrQuit(inputQuestionId);

            if (inputQuestionId == String.Empty)
            {
                continue;
            }
            if (inputQuestionId == "quit")
            {
                Console.WriteLine("You quitted!\n");
                break;
            }

            int.TryParse(inputQuestionId, out var questionId);
            var questionEntity = dbManager.SelectQuestion(questionId);

            if (questionEntity != null)
            {
                var allTopics = dbManager.SelectAllTopic();
                if (allTopics.Count == 0)
                {
                    Console.WriteLine("There is no topic in the database!");
                    break;
                }
                ConsoleHelper.WriteOutAllTopics(allTopics);

                Console.WriteLine("You can write 'null' if you don't want to assign a topic to the question.");
                var newTopicId = ConsoleHelper.ReadAndWrite("the new topic id");
                newTopicId = ValidateInputs.ValidateInputsIfEmptyOrQuit(newTopicId);

                if (newTopicId == String.Empty)
                {
                    continue;
                }
                if (newTopicId == "quit")
                {
                    Console.WriteLine("You quitted!\n");
                    break;
                }

                /*Console.WriteLine("\nWrite the new topic id: ");
                Console.WriteLine("If you write 'null', then no topic will be assigned.");
                var newTopicId = Console.ReadLine();
                if (string.IsNullOrEmpty(newTopicId) || string.IsNullOrWhiteSpace(newTopicId))
                {
                    Console.WriteLine("Write something please!");
                    continue;
                }
                newTopicId = newTopicId.Trim();
                if (newTopicId == "quit") {
                    Console.WriteLine("You quitted! \n");
                    break;
                }*/
                if (newTopicId == "null")
                {
                    questionEntity.TopicId = null;
                    dbManager.UpdateQuestion(questionEntity);
                    Console.WriteLine("\nCongratulations, you updated the question's topic!\n");
                    break;
                }

                int.TryParse(newTopicId, out var topicId);
                var topicEntity = dbManager.SelectTopic(topicId);

                if (topicEntity != null)
                {
                    questionEntity.TopicId = topicId;
                    dbManager.UpdateQuestion(questionEntity);
                    Console.WriteLine("\nCongratulations, you updated the question's topic!\n");
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
