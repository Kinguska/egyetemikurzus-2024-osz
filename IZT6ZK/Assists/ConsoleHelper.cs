using IZT6ZK.Db;
using IZT6ZK.Models;
using IZT6ZK.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Assists;
internal class ConsoleHelper
{
    public static void WriteQuit()
    {
        Console.WriteLine("\nWrite 'quit' if you want to quit.");
    }
    public static void WriteQuitAll()
    {
        Console.WriteLine("Write 'quit all' if you want to quit all of the questions.\n");
    }
    public static string ReadAndWrite(string whatWeWantToAskFromUser)
    {
        Console.WriteLine($"\nWrite {whatWeWantToAskFromUser}: ");
        var input = Console.ReadLine();
        return input ?? "";
    }

    public static void WriteOutAllTopics(List<TopicEntity> allTopics)
    {
        Console.WriteLine("\nThe possible topics: ");

        foreach (var allTopic in allTopics)
        {
            Console.WriteLine($"{allTopic.TopicId}: {allTopic.TopicName}");
        }
    }

    public static void WriteOutAllQuestions(List<QuestionEntity> allQuestions)
    {
        Console.WriteLine("\nThe possible questions: ");

        foreach (var allQuestion in allQuestions)
        {
            Console.WriteLine($"{allQuestion.QuestionId}: {allQuestion.Question}");
        }
    }

    public static void WriteOutTheResultOfTheQuiz(List<QuestionRecordForStatistic> questionRecords, List<QuestionEntity> allQuestions)
    {
        Console.WriteLine("Your result: ");
        var correctAnswers = questionRecords.Count(x => x.CorrectAnswer == x.UserAnswer);
        var incorrectAnswers = questionRecords.Count(x => x.CorrectAnswer != x.UserAnswer);
        var quitedQuestions = allQuestions.Count - questionRecords.Count;

        foreach (var questionRecord in questionRecords)
        {
            Console.WriteLine(questionRecord.ToString());
        }

        Console.WriteLine($"\nNumber of correct answers: {correctAnswers}");
        Console.WriteLine($"Number of incorrect answers: {incorrectAnswers}");
        Console.WriteLine($"Number of quitted questions: {quitedQuestions}\n");
    }
}
