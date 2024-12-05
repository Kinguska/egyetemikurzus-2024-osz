using IZT6ZK.Assists;
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

        ConsoleHelper.WriteQuit();

        while (true)
        {
            var allQuestions = dbManager.SelectAllQuestions();

            if (allQuestions.Count == 0)
            {
                Console.WriteLine("There are no questions in the database!\n");
                break;
            }

            ConsoleHelper.WriteOutAllQuestions(allQuestions);

            inputQuestionId = ConsoleHelper.ReadAndWrite("the question's id, you want to delete");
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
                Console.WriteLine("Are you sure? Yes or No");
                var yesOrNo = Console.ReadLine();
                yesOrNo = yesOrNo.Trim().ToLower();

                if (yesOrNo == "no")
                {
                    Console.WriteLine("You didn't delete the question!");
                    continue;
                }
                else if (yesOrNo == "yes")
                {
                    dbManager.DeleteQuestion(questionEntity);
                    Console.WriteLine("\nCongratulations, you deleted the question!\n");
                    break;
                }
                else
                {
                    Console.WriteLine("Please write 'yes' or 'no'!");
                    continue;
                }
            }
            Console.WriteLine("Please write an existing question id!");
            continue;
        }
    }
}
