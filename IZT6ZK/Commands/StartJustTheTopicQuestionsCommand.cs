using IZT6ZK.Db;
using IZT6ZK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Commands;
internal class StartJustTheTopicQuestionsCommand : ICommands
{
    public void Execute()
    {
        var dbManager = new DbManager();
        string? inputTopicId = null;
        int wantedTopicId = 0;


        List<QuestionEntity> allQuestionsFromATopic = new List<QuestionEntity>();
        bool outerLoopGoing = true;
        bool innerLoopGoing = true;

        Console.WriteLine("Write 'quit' if you want to quit this question\n");

        Console.WriteLine("Write 'quit all' if you want to quit all of the questions\n");

        while (outerLoopGoing)
        {
            Console.WriteLine("\nThe possible topics: ");
            var allTopics = dbManager.SelectAllTopic();
            foreach (var allTopic in allTopics)
            {
                Console.WriteLine($"{allTopic.TopicId}: {allTopic.TopicName}");
            }
            Console.WriteLine("\nWrite the id of the topic: ");
            inputTopicId = Console.ReadLine();

            if (string.IsNullOrEmpty(inputTopicId))
            {
                Console.WriteLine("Write something please!");
                break;
            }
            inputTopicId = inputTopicId.Trim();

            if (inputTopicId == "quit")
            {
                Console.WriteLine("You quitted\n");
                outerLoopGoing = false;
                break;
            }
            int.TryParse(inputTopicId, out wantedTopicId);
            allQuestionsFromATopic = dbManager.SelectAllQuestionsFromOneTopic(wantedTopicId);

            if (dbManager.SelectTopic(wantedTopicId) == null)
            {
                Console.WriteLine("Please write an existing topic id!");
                continue;
            }

            if (allQuestionsFromATopic.Count == 0)
            {
                Console.WriteLine("Sadly there is no question in this topic!");
                outerLoopGoing = false;
                break;
            }

            foreach (var question in allQuestionsFromATopic)
            {
                while (innerLoopGoing)
                {
                    Console.WriteLine(question.ToString());

                    var inputAnswer = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputAnswer))
                    {
                        Console.WriteLine("Write something please!");
                        break;
                    }
                    inputAnswer = inputAnswer.Trim();

                    if (inputAnswer.Equals(question.CorrectAnswer))
                    {
                        Console.WriteLine("Correct answer!\n");
                        innerLoopGoing = false;
                        break;
                    }
                    if (inputAnswer == "quit")
                    {
                        Console.WriteLine("You quitted the question\n");
                        break;
                    }
                    if (inputAnswer == "quit all")
                    {
                        Console.WriteLine("You quitted  all of the questions\n");
                        outerLoopGoing = false;
                        break;
                    }
                    Console.WriteLine("Incorrect answer, try again!");
                    continue;
                }
            }
            outerLoopGoing = false;
            break;
            
        }
        Console.WriteLine("End of the questions");
    }
}
