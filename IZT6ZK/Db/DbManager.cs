using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace IZT6ZK.Db;

internal class DbManager : IDbManager
{
    
    public void CreateQuestion(string question, string answer1, string answer2, string answer3, string answer4, string correctAnswer, int topicId)
    {

        using var Db = new MyDbContext();

        Db.Questions.Add(new QuestionEntity() { Question = question, Answer1 = answer1, Answer2 = answer2, Answer3 = answer3, Answer4 = answer4, CorrectAnswer = correctAnswer, TopicId = topicId });
        Db.SaveChanges();
    }

    public void CreateTopic(string topicName)
    {
        using var Db = new MyDbContext();

        Db.Add(new TopicEntity() { TopicName = topicName });
        Db.SaveChanges();
    }

   

    public void DeleteQuestion(QuestionEntity question)
    {
        using var Db = new MyDbContext();

        Db.Questions.Remove(question);
        Db.SaveChanges();
    }

    public void DeleteTopic(TopicEntity topicEntity)
    {
        using var Db = new MyDbContext();

        Db.Topics.Remove(topicEntity);
        Db.SaveChanges();
        //összekapcsolt kulcs esetén még nem lehet törölni
    }

    public List<QuestionEntity> SelectAllQuestions()
    {
        using var Db = new MyDbContext();

        var allQuestions = Db.Questions.ToList();
        return allQuestions;
    }

    public List<QuestionEntity> SelectAllQuestionsFromOneTopic(int topicId)
    {
        using var Db = new MyDbContext();

        var allQuestionsFromTopic = Db.Questions.Where(x => x.TopicId == topicId).ToList();
        return allQuestionsFromTopic;
        
    }

    public List<TopicEntity> SelectAllTopic()
    {
        using var Db = new MyDbContext();

        var allTopics = Db.Topics.ToList();
        return allTopics;
    }

    public QuestionEntity SelectQuestion(int questionId)
    {
        using var Db = new MyDbContext();

        var question = Db.Questions.Where(x => x.QuestionId == questionId).FirstOrDefault();
        return question;
    }

    public TopicEntity SelectTopic(int topicId)
    {
        using var Db = new MyDbContext();

        var topic = Db.Topics.Where(x => x.TopicId == topicId).FirstOrDefault();
        return topic;
    }

    public void UpdateQuestion()
    {
        throw new NotImplementedException();
    }

    public void UpdateTopic()
    {
        throw new NotImplementedException();
    }
}
