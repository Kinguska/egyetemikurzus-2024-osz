using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IZT6ZK.Db;

namespace IZT6ZK.Commands;

internal class CreateQuestionCommand : ICommands
{
    public void Execute()
    {
        DbManager dbManager = new DbManager();

        string? input = null;
        string? inputQuestion = null;
        string? inputAnswer1 = null;
        string? inputAnswer2 = null;
        string? inputAnswer3 = null;
        string? inputAnswer4 = null;
        string? inputCorrectAnswer = null;
        string? inputTopicName = null;

        //bool notQuittedYet = true;
        bool loopGoing = true;

        var stateQuestionReading = CreateQuestionStateMachine.QuestionReading;
        var stateQuestionInputAndCW = QuestionInputsStateMachine.QuestionInput;

        Console.WriteLine("\nWrite 'quit' if you want to quit\n");

        while (loopGoing)
        {
            switch (stateQuestionReading)
            {
                case CreateQuestionStateMachine.QuestionReading:
                    Console.WriteLine("\nWrite your question: ");
                    inputQuestion = Console.ReadLine();

                    if (string.IsNullOrEmpty(inputQuestion))
                    {
                        Console.WriteLine("Write something please!");
                        break;
                    }

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
                    else if(inputAnswer2 == inputAnswer1)
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
                    stateQuestionReading = CreateQuestionStateMachine.EverythingWasFineQuestionCreated;
                    break;

                case CreateQuestionStateMachine.EverythingWasFineQuestionCreated:
                    TopicEntity topic = new TopicEntity();
                    topic.TopicName = inputTopicName;
                    dbManager.CreateQuestion(inputQuestion, inputAnswer1, inputAnswer2, inputAnswer3, inputAnswer4, inputCorrectAnswer, topic);
                    Console.WriteLine("Congratulations, you created a question!\n");
                    loopGoing = false;
                    break;

                case CreateQuestionStateMachine.QuitFromCreateQuestion:
                    Console.WriteLine("You quitted \n");
                    loopGoing = false;
                    break;

                default:
                    loopGoing = false;
                    break;
            }
        

        }
        /*
        while (notQuittedYet)
        {
            Console.WriteLine("\nWrite your question: ");
            inputQuestion = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputQuestion))
            {
                inputQuestion = inputQuestion.Trim();

                if (inputQuestion == "quit")
                {
                    Console.WriteLine("You quit \n");
                    notQuittedYet = false;
                    break;
                }
                break;
            }
            else
            {
                Console.WriteLine("Write something please!");
            }
        }
        while (notQuittedYet)
        {

            Console.WriteLine("\nWrite the first answer: ");
            inputAnswer1 = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputAnswer1))
            {
                inputAnswer1 = inputAnswer1.Trim();

                if (inputAnswer1 == "quit")
                {
                    Console.WriteLine("You quit \n");
                    notQuittedYet = false;
                    break;
                }
                break;
            }
            else
            {
                Console.WriteLine("Write something please!");
            }
        }
        while (notQuittedYet)
        {

            Console.WriteLine("\nWrite the second answer: ");
            inputAnswer2 = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputAnswer2))
            {
                inputAnswer2 = inputAnswer2.Trim();

                if (inputAnswer2 == "quit")
                {
                    Console.WriteLine("You quit \n");
                    notQuittedYet = false;
                    break;
                }
                break;
            }
            else
            {
                Console.WriteLine("Write something please!");
            }
        }
        while (notQuittedYet)
        {

            Console.WriteLine("\nWrite the third answer: ");
            inputAnswer3 = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputAnswer3))
            {
                inputAnswer3 = inputAnswer3.Trim();

                if (inputAnswer3 == "quit")
                {
                    Console.WriteLine("You quit \n");
                    notQuittedYet = false;
                    break;
                }
                break;
            }
            else
            {
                Console.WriteLine("Write something please!");
            }
        }
        while (notQuittedYet)
        {

            Console.WriteLine("\nWrite the fourth answer: ");
            inputAnswer4 = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputAnswer4))
            {
                inputAnswer4 = inputAnswer4.Trim();

                if (inputAnswer4 == "quit")
                {
                    Console.WriteLine("You quit \n");
                    notQuittedYet = false;
                    break;
                }
                break;
            }
            else
            {
                Console.WriteLine("Write something please!");
            }
        }
        
        while (notQuittedYet)
        {
            Console.WriteLine("\nWrite the correct answer: ");
            inputCorrectAnswer = Console.ReadLine();

            if (!string.IsNullOrEmpty(inputCorrectAnswer))
            {
                inputCorrectAnswer = inputCorrectAnswer.Trim();

                if (inputCorrectAnswer == "quit")
                {
                    Console.WriteLine("You quit \n");
                    notQuittedYet = false;
                    break;
                }
                
                if (inputCorrectAnswer != inputAnswer1 && inputCorrectAnswer != inputAnswer2 && inputCorrectAnswer != inputAnswer3 && inputCorrectAnswer != inputAnswer4)
                {
                    Console.WriteLine("The correct answer must match one of the given answers!");
                    continue;
                }
                break;
            }
            else
            {
                Console.WriteLine("Write something please!");
            }
        }
        if (notQuittedYet)
        {
            TopicEntity topic = new TopicEntity();
            topic.TopicName = inputTopicName;
            dbManager.CreateQuestion(inputQuestion, inputAnswer1, inputAnswer2, inputAnswer3, inputAnswer4, inputCorrectAnswer, topic);
        }
        */

    }
}
