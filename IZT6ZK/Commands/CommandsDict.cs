using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Commands;

internal class CommandsDict
{
    public static Dictionary<string, ICommands> commandsDict = new Dictionary<string, ICommands>()
    {
        {"help", new HelpCommand() },
        {"exit", new ExitCommand() },
        {"start all", new StartAllQuestionsCommand() },
        {"start one topic", new StartJustTheTopicQuestionsCommand()},
        {"create question", new CreateQuestionCommand() },
        {"create topic", new CreateTopicCommand() },
        {"update question", new UpdateQuestionsTopic() },
        {"update topic", new UpdateTopic() },
        {"delete question", new DeleteQuestionCommand() },
        {"delete topic", new DeleteTopicCommand() },
    };

}
