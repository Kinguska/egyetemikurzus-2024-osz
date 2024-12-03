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
        ReadInCW readInCW = new ReadInCW();
        //tömb vagy dict?
        string? input = null;
        string? inputQuestion = null;
        string? inputAnswer1 = null;
        string? inputAnswer2 = null;
        string? inputAnswer3 = null;
        string? inputAnswer4 = null;
        string? inputCorrectAnswer = null;

        string? inputWantTopic = null;
        string? inputTopicId = null;
        int wantedTopicId = 0;

        bool loopGoing = true;

        var stateQuestionReading = CreateQuestionStateMachine.QuestionReading;

        Console.WriteLine("\nWrite 'quit' if you want to quit.");

        while (loopGoing)
        {
            switch (stateQuestionReading)
            {
                case CreateQuestionStateMachine.QuestionReading:
                    //Beolvasas("question");
                    //Console.WriteLine("\nWrite your question: ");
                    //inputQuestion = Console.ReadLine();
                    inputQuestion = readInCW.ReadAndWrite("your question");

                    if (string.IsNullOrEmpty(inputQuestion))
                    {
                        Console.WriteLine("Write something please!");
                        break;
                    }
                    //validálás, esetleg még egy validálás fvg quit all-lal
                    inputQuestion = inputQuestion.Trim();
                    if (inputQuestion == "quit")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.QuitFromCreateQuestion;
                        break;
                    }
                    stateQuestionReading = CreateQuestionStateMachine.Answer1Reading;
                    break;

                case CreateQuestionStateMachine.Answer1Reading:
                    Console.WriteLine("\nWrite the first answer: ");
                    inputAnswer1 = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputAnswer1))
                    {
                        Console.WriteLine("Write something please!");
                        break;
                    }
                    inputAnswer1 = inputAnswer1.Trim();

                    if (inputAnswer1 == "quit")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.QuitFromCreateQuestion;
                        break;
                    }
                    stateQuestionReading = CreateQuestionStateMachine.Answer2Reading;
                    break;

                case CreateQuestionStateMachine.Answer2Reading:
                    Console.WriteLine("\nWrite the second answer: ");
                    inputAnswer2 = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputAnswer2))
                    {
                        Console.WriteLine("Write something please!");
                        break;
                    }
                    inputAnswer2 = inputAnswer2.Trim();

                    if (inputAnswer2 == "quit")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.QuitFromCreateQuestion;
                        break;
                    }
                    else if (inputAnswer2 == inputAnswer1)
                    {
                        Console.WriteLine("Please write something else than the other answers!");
                        break;
                    }
                    stateQuestionReading = CreateQuestionStateMachine.Answer3Reading;
                    break;

                case CreateQuestionStateMachine.Answer3Reading:
                    Console.WriteLine("\nWrite the third answer: ");
                    inputAnswer3 = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputAnswer3))
                    {
                        Console.WriteLine("Write something please!");
                        break;
                    }
                    inputAnswer3 = inputAnswer3.Trim();

                    if (inputAnswer3 == "quit")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.QuitFromCreateQuestion;
                        break;
                    }
                    else if (inputAnswer3 == inputAnswer2 || inputAnswer3 == inputAnswer1)
                    {
                        Console.WriteLine("Please write something else than the other answers!");
                        break;
                    }
                    stateQuestionReading = CreateQuestionStateMachine.Answer4Reading;
                    break;

                case CreateQuestionStateMachine.Answer4Reading:
                    Console.WriteLine("\nWrite the fourth answer: ");
                    inputAnswer4 = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputAnswer4))
                    {
                        Console.WriteLine("Write something please!");
                        break;
                    }
                    inputAnswer4 = inputAnswer4.Trim();

                    if (inputAnswer4 == "quit")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.QuitFromCreateQuestion;
                        break;
                    }
                    else if (inputAnswer4 == inputAnswer3 || inputAnswer4 == inputAnswer2 || inputAnswer4 == inputAnswer1)
                    {
                        Console.WriteLine("Please write something else than the other answers!");
                        break;
                    }
                    stateQuestionReading = CreateQuestionStateMachine.CorrectAnswerReading;
                    break;

                case CreateQuestionStateMachine.CorrectAnswerReading:
                    Console.WriteLine("\nWrite the correct answer: ");
                    inputCorrectAnswer = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputCorrectAnswer))
                    {
                        Console.WriteLine("Write something please!");
                        break;
                    }
                    inputCorrectAnswer = inputCorrectAnswer.Trim();

                    if (inputCorrectAnswer == "quit")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.QuitFromCreateQuestion;
                        break;
                    }
                    else if (inputCorrectAnswer == inputAnswer1 || inputCorrectAnswer == inputAnswer2 
                        || inputCorrectAnswer == inputAnswer3 || inputCorrectAnswer == inputAnswer4)
                    {
                        stateQuestionReading = CreateQuestionStateMachine.WantToReadTopic;
                        break;
                    }
                    Console.WriteLine("Please write a correct answer from the previous answers!");
                    break;

                case CreateQuestionStateMachine.WantToReadTopic:
                    Console.WriteLine("\nDo you want to add topic for your question? Yes or No");
                    inputWantTopic = Console.ReadLine();
                    if (string.IsNullOrEmpty(inputWantTopic))
                    {
                        Console.WriteLine("Write something please!");
                        break;
                    }
                    inputWantTopic = inputWantTopic.Trim().ToLower();
                    if (inputWantTopic == "quit")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.QuitFromCreateQuestion;
                        break;
                    }
                    else if (inputWantTopic == "no")
                    {
                        stateQuestionReading = CreateQuestionStateMachine.EverythingWasFineQuestionCreate;
                        break;
                    }
                    stateQuestionReading = CreateQuestionStateMachine.TopicReading;
                    break;

                case CreateQuestionStateMachine.TopicReading:
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
                        stateQuestionReading = CreateQuestionStateMachine.QuitFromCreateQuestion;
                        break;
                    }
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
                    dbManager.CreateQuestion(inputQuestion, inputAnswer1, inputAnswer2, inputAnswer3, inputAnswer4, inputCorrectAnswer, wantedTopicId);
                    Console.WriteLine("\nCongratulations, you created a question!\n");
                    loopGoing = false;
                    break;

                case CreateQuestionStateMachine.EverythingWasFineQuestionCreate:
                    dbManager.CreateQuestion(inputQuestion, inputAnswer1, inputAnswer2, inputAnswer3, inputAnswer4, inputCorrectAnswer, null);
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
    /*
    string InputAndCWState(CreateQuestionStateMachine createQuestionStateMachine) =>
        createQuestionStateMachine switch
        {
            CreateQuestionStateMachine.QuestionReading => Console.WriteLine()
        }
    */
}
