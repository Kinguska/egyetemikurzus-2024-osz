using IZT6ZK.Assists;
using IZT6ZK.Db;
using IZT6ZK.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Commands;

internal class StartAllQuestionsCommand : ICommands
{
    public void Execute()
    {
        var dbManager = new DbManager();
        var allQuestions = dbManager.SelectAllQuestions();
        bool loopGoing = true;

        var questionRecords = new List<QuestionRecordForStatistic>();

        //List, amiben vannak a recordok, amiben a kérdés, a válasz, és a felhasználó által adott válasz van
        //a végén egy statisztika, hogy hány kérdés volt, hány helyes válasz, hány helytelen válasz
        //Incorrect válasz esetén a felhasználó újra válaszolhat, ezen akkor változtatni kell

        //Console.WriteLine("\nWrite 'quit' if you want to quit this question.");
        //Console.WriteLine("Write 'quit all' if you want to quit all of the questions.\n");
        ConsoleHelper.WriteQuit();
        ConsoleHelper.WriteQuitAll();

        foreach (var question in allQuestions)
        {
            if (question == null)
            {
                Console.WriteLine("There is no question, sorry!");
                break;
            }

            while (loopGoing)
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
                    loopGoing = false;
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
                /*
                if (string.IsNullOrEmpty(inputAnswer))
                {
                    Console.WriteLine("Write something please!");
                    break;
                }
                inputAnswer = inputAnswer.Trim();

                if (inputAnswer.Equals(question.CorrectAnswer))
                {
                    Console.WriteLine("Correct answer!\n");
                    break;
                }
                if (inputAnswer == "quit")
                {
                    Console.WriteLine("\nYou quitted the question!\n");
                    break;
                }
                if (inputAnswer == "quit all")
                {
                    Console.WriteLine("\nYou quitted  all of the questions!\n");
                    loopGoing = false;
                    break;
                }*/

                Console.WriteLine("Incorrect answer! You can try again after you finished this round.\n");
                questionRecords.Add(new QuestionRecordForStatistic(question.Question, question.CorrectAnswer, inputAnswer));
                break;
            }
        }
        Console.WriteLine("End of the questions.\n");

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
