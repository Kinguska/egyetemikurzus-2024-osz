using IZT6ZK.Assists;
using IZT6ZK.Db;
using IZT6ZK.Records;

namespace IZT6ZK.Commands;

internal class StartAllQuestionsCommand : ICommands
{
    public void Execute()
    {
        var dbManager = new DbManager();
        var allQuestions = dbManager.SelectAllQuestions();
        bool loopGoing = true;

        var questionRecords = new List<QuestionRecordForStatistic>();

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

                Console.WriteLine("Incorrect answer! You can try again after you finished this round.\n");
                questionRecords.Add(new QuestionRecordForStatistic(question.Question, question.CorrectAnswer, inputAnswer));
                break;
            }
        }

        if (questionRecords.Count == 0)
        {
            return;
        }
        Console.WriteLine("End of the questions.\n");
        ConsoleHelper.WriteOutTheResultOfTheQuiz(questionRecords, allQuestions);
    }
}
