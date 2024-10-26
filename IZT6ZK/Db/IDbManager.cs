using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IZT6ZK.Db;

internal interface IDbManager
{
    public void CreateTopic(string topicName);
    public TopicEntity SelectTopic(int topicId);
    public List<TopicEntity> SelectAllTopic();
    public void UpdateTopic();
    public void DeleteTopic(TopicEntity topicEntity);

    public void CreateQuestion(string question, string answer1, string answer2, string answer3, string answer4, string correctAnswer, int topicId);
    public QuestionEntity SelectQuestion(int questionId);
    public List<QuestionEntity> SelectAllQuestionsFromOneTopic(int topicId);
    public List<QuestionEntity> SelectAllQuestions();
    public void UpdateQuestion();
    public void DeleteQuestion(QuestionEntity question);

}
