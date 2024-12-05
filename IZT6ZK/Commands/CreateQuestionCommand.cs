using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IZT6ZK.Assists;
using IZT6ZK.Db;
using IZT6ZK.StateMachine;

namespace IZT6ZK.Commands;

internal class CreateQuestionCommand : ICommands
{
    public void Execute()
    {
        DbManager dbManager = new DbManager();
        string? input = null;
        List<string>? inputQuestionAndAnswers = new List<string>();

        string? inputWantTopic = null;
        string? inputTopicId = null;
        int wantedTopicId = 0;

        bool loopGoing = true;
        var stateQuestionReading = CreateQuestionStateMachine.QuestionReading;

        ConsoleHelper.WriteQuit();

        while (loopGoing)
        {
            switch (stateQuestionReading)
            {
                case CreateQuestionStateMachine.QuestionReading:
                    input = ConsoleHelper.ReadAndWrite("your question");
                    input = ValidateInputs.ValidateInputsIfEmptyOrQuit(input);

                    if (input == String.Empty)
                    {
                        break;
                    }
                    else if (input == "quit")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.QuitFromCreateQuestion;
                        break;
                    }
                    inputQuestionAndAnswers.Add(input);
                    stateQuestionReading = CreateQuestionStateMachine.Answer1Reading;
                    break;

                case CreateQuestionStateMachine.Answer1Reading:
                    input = ConsoleHelper.ReadAndWrite("the first answer");
                    input = ValidateInputs.ValidateInputsIfEmptyOrQuit(input);

                    if (input == String.Empty)
                    {
                        break;
                    }
                    else if (input == "quit")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.QuitFromCreateQuestion;
                        break;
                    }
                    inputQuestionAndAnswers.Add(input);
                    stateQuestionReading = CreateQuestionStateMachine.Answer2Reading;
                    break;

                case CreateQuestionStateMachine.Answer2Reading:
                    input = ConsoleHelper.ReadAndWrite("the second answer");
                    input = ValidateInputs.ValidateInputsIfEmptyOrQuit(input);

                    if (input == String.Empty)
                    {
                        break;
                    }
                    else if (input == "quit")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.QuitFromCreateQuestion;
                        break;
                    }
                    else if (inputQuestionAndAnswers.Contains(input))
                    {
                        Console.WriteLine("Please write something else than the other answers!");
                        break;
                    }
                    inputQuestionAndAnswers.Add(input);
                    stateQuestionReading = CreateQuestionStateMachine.Answer3Reading;
                    break;

                case CreateQuestionStateMachine.Answer3Reading:
                    input = ConsoleHelper.ReadAndWrite("the third answer");
                    input = ValidateInputs.ValidateInputsIfEmptyOrQuit(input);

                    if (input == String.Empty)
                    {
                        break;
                    }
                    else if (input == "quit")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.QuitFromCreateQuestion;
                        break;
                    }
                    else if (inputQuestionAndAnswers.Contains(input))
                    {
                        Console.WriteLine("Please write something else than the other answers!");
                        break;
                    }
                    inputQuestionAndAnswers.Add(input);
                    stateQuestionReading = CreateQuestionStateMachine.Answer4Reading;
                    break;

                case CreateQuestionStateMachine.Answer4Reading:
                    input = ConsoleHelper.ReadAndWrite("the fourth answer");
                    input = ValidateInputs.ValidateInputsIfEmptyOrQuit(input);

                    if (input == String.Empty)
                    {
                        break;
                    }
                    else if (input == "quit")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.QuitFromCreateQuestion;
                        break;
                    }
                    else if (inputQuestionAndAnswers.Contains(input))
                    {
                        Console.WriteLine("Please write something else than the other answers!");
                        break;
                    }
                    inputQuestionAndAnswers.Add(input);
                    stateQuestionReading = CreateQuestionStateMachine.CorrectAnswerReading;
                    break;

                case CreateQuestionStateMachine.CorrectAnswerReading:
                    input = ConsoleHelper.ReadAndWrite("the correct answer");
                    input = ValidateInputs.ValidateInputsIfEmptyOrQuit(input);

                    if (input == String.Empty)
                    {
                        break;
                    }
                    else if (input == "quit")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.QuitFromCreateQuestion;
                        break;
                    }
                    else if (!inputQuestionAndAnswers.Contains(input))
                    {
                        Console.WriteLine("Please write a correct answer from the previous answers!");
                        break;
                    }
                    inputQuestionAndAnswers.Add(input);
                    stateQuestionReading = CreateQuestionStateMachine.WantToReadTopic;
                    break;


                case CreateQuestionStateMachine.WantToReadTopic:
                    Console.WriteLine("\nDo you want to add topic for your question? Yes or No");
                    inputWantTopic = Console.ReadLine();
                    inputWantTopic = ValidateInputs.ValidateInputsIfEmptyOrQuit(inputWantTopic);
                    inputWantTopic = inputWantTopic.ToLower();

                    if (input == String.Empty)
                    {
                        break;
                    }
                    else if (input == "quit")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.QuitFromCreateQuestion;
                        break;
                    }
                    else if (inputWantTopic == "no")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.EverythingWasFineQuestionCreate;
                        break;
                    }
                    else if (inputWantTopic == "yes")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.TopicReading;
                        break;
                    }
                    Console.WriteLine("Please write Yes or No!");
                    break;

                case CreateQuestionStateMachine.TopicReading:
                    var allTopics = dbManager.SelectAllTopic();

                    if (allTopics.Count == 0)
                    {
                        Console.WriteLine("There is no topic in the database!");
                        stateQuestionReading = CreateQuestionStateMachine.EverythingWasFineQuestionCreate;
                        break;
                    }
                    ConsoleHelper.WriteOutAllTopics(allTopics);

                    inputTopicId = ConsoleHelper.ReadAndWrite("the id of the topic");
                    inputTopicId = ValidateInputs.ValidateInputsIfEmptyOrQuit(inputTopicId);

                    int.TryParse(inputTopicId, out wantedTopicId);
                    var topicEntity = dbManager.SelectTopic(wantedTopicId);

                    if (topicEntity != null)
                    {
                        stateQuestionReading = CreateQuestionStateMachine.EverythingWasFineQuestionCreateWithTopic;
                        break;
                    }
                    Console.WriteLine("Please write an existing topic id!");
                    break;


                case CreateQuestionStateMachine.EverythingWasFineQuestionCreateWithTopic:
                    //dbManager.CreateQuestion(inputQuestion, inputAnswer1, inputAnswer2, inputAnswer3, inputAnswer4, inputCorrectAnswer, wantedTopicId);
                    dbManager.CreateQuestion(inputQuestionAndAnswers[0], inputQuestionAndAnswers[1], inputQuestionAndAnswers[2], inputQuestionAndAnswers[3], inputQuestionAndAnswers[4], inputQuestionAndAnswers[5], wantedTopicId);
                    Console.WriteLine("\nCongratulations, you created a question!\n");
                    loopGoing = false;
                    break;

                case CreateQuestionStateMachine.EverythingWasFineQuestionCreate:
                    //dbManager.CreateQuestion(inputQuestion, inputAnswer1, inputAnswer2, inputAnswer3, inputAnswer4, inputCorrectAnswer, null);
                    dbManager.CreateQuestion(inputQuestionAndAnswers[0], inputQuestionAndAnswers[1], inputQuestionAndAnswers[2], inputQuestionAndAnswers[3], inputQuestionAndAnswers[4], inputQuestionAndAnswers[5], null);
                    Console.WriteLine("\nCongratulations, you created a question!\n");
                    loopGoing = false;
                    break;

                case CreateQuestionStateMachine.QuitFromCreateQuestion:
                    Console.WriteLine("You quitted! \n");
                    loopGoing = false;
                    break;

                default:
                    loopGoing = false;
                    break;
            }
        }
    }
}
