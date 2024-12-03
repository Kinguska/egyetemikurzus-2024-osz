using IZT6ZK.Db;
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

        Console.WriteLine("\nWrite 'quit' if you want to quit this question.");
        Console.WriteLine("Write 'quit all' if you want to quit all of the questions.\n");

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
                }

                Console.WriteLine("Incorrect answer, try again!\n");
                continue;
            }

        }
        Console.WriteLine("End of the questions.\n");


    }
}
