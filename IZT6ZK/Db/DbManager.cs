using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace IZT6ZK.Db
{
    internal class DbManager : IDbManager
    {
        
        public void CreateQuestion(string question, string answer1, string answer2, string answer3, string answer4, string correctAnswer, TopicEntity? topicEntity)
        {

            //var Db = DbConnect();
            using var Db = new MyDbContext();

            Db.Questions.Add(new QuestionEntity() { Question = question, Answer1 = answer1, Answer2 = answer2, Answer3 = answer3, Answer4 = answer4, CorrectAnswer = correctAnswer});
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
        }

        public void SelectQuestion()
        {
            throw new NotImplementedException();
        }

        public void SelectTopic()
        {
            throw new NotImplementedException();
        }
    }
}
