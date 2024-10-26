using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK;
internal enum CreateQuestionStateMachine
{
    QuestionReading,
    Answer1Reading,
    Answer2Reading,
    Answer3Reading,
    Answer4Reading,
    CorrectAnswerReading,
    WantToReadTopic,
    TopicReading,
    QuitFromCreateQuestion,
    EverythingWasFineQuestionCreate,
}
