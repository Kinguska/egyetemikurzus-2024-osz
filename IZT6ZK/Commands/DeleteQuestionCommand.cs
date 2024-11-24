using IZT6ZK.Db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Commands;
internal class DeleteQuestionCommand : ICommands
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

            Console.WriteLine("Write the question's id, you want to delete: ");
            inputQuestionId = Console.ReadLine();

            if (string.IsNullOrEmpty(inputQuestionId) || string.IsNullOrWhiteSpace(inputQuestionId))
            {
                Console.WriteLine("Write something please!");
                continue;
            }
            inputQuestionId = inputQuestionId.Trim();

            if (inputQuestionId == "quit")
            {
                Console.WriteLine("You quitted \n");
                break;
            }
            int.TryParse(inputQuestionId, out var questionId);
            var questionEntity = dbManager.SelectQuestion(questionId);
            if (questionEntity != null)
            {
                dbManager.DeleteQuestion(questionEntity);
                Console.WriteLine("Congratulations, you deleted the question!\n");
                break;
            }
            Console.WriteLine("Please write an existing question id!");
            continue;

        }
    }
}
