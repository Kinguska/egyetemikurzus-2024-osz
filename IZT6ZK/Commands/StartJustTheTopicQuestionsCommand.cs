using IZT6ZK.Assists;
using IZT6ZK.Db;
using IZT6ZK.Models;
using IZT6ZK.Records;
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

        var questionRecords = new List<QuestionRecordForStatistic>();

        ConsoleHelper.WriteQuit();
        ConsoleHelper.WriteQuitAll();

        while (outerLoopGoing)
        {
            var allTopics = dbManager.SelectAllTopic();

            if (allTopics.Count == 0)
            {
                Console.WriteLine("There is no topic, sorry!");
                break;
            }

            ConsoleHelper.WriteOutAllTopics(allTopics);

            inputTopicId = ConsoleHelper.ReadAndWrite("the id of the topic");
            inputTopicId = ValidateInputs.ValidateInputsIfEmptyOrQuit(inputTopicId);

            if (inputTopicId == string.Empty)
            {
                continue;
            }
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
                Console.WriteLine("Sadly there is no question in this topic!\n");
                continue;
            }

            foreach (var question in allQuestionsFromATopic)
            {
                while (innerLoopGoing)
                {
                    Console.WriteLine(question.ToString());

                    var inputAnswer = Console.ReadLine();
                    inputAnswer = ValidateInputs.ValidateInputsIfEmptyOrQuitOrQuitAll(inputAnswer);

                    if (inputAnswer == string.Empty)
                    {
                        continue;
                    }
                    if (inputAnswer == "quit")
                    {
                        Console.WriteLine("\nYou quitted the question!\n");
                        break;
                    }
                    if (inputAnswer == "quit all")
                    {
                        Console.WriteLine("\nYou quitted  all of the questions!\n");
                        innerLoopGoing = false;
                        outerLoopGoing = false;
                        break;
                    }
                    if (inputAnswer != question.Answer1 && inputAnswer != question.Answer2
                    && inputAnswer != question.Answer3 && inputAnswer != question.Answer4)
                    {
                        Console.WriteLine("There is no such answer! Try again!");
                        continue;
                    }
                    if (inputAnswer.Equals(question.CorrectAnswer))
                    {
                        Console.WriteLine("Correct answer!\n");
                        questionRecords.Add(new QuestionRecordForStatistic(question.Question, question.CorrectAnswer, inputAnswer));
                        break;
                    }

                    Console.WriteLine("Incorrect answer! You can try again after you finished this round.\n");
                    questionRecords.Add(new QuestionRecordForStatistic(question.Question, question.CorrectAnswer, inputAnswer));
                    break;
                }
            }
            outerLoopGoing = false;
            break;

        }
        if (questionRecords.Count == 0)
        {
            return;
        }
        Console.WriteLine("End of the questions.\n");
        ConsoleHelper.WriteOutTheResultOfTheQuiz(questionRecords, allQuestionsFromATopic);
    }
}
