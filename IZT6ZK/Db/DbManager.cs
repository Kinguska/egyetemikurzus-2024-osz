using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace IZT6ZK.Db
{
    internal class DbManager : IDbManager
    {
        public MyDbContext DbConnect()
        {
            using var Db = new MyDbContext();

            Db.Database.Migrate();
            return Db;
        }

        public void CreateQuestion(string question, string answer1, string answer2, string answer3, string answer4, string correctAnswer, TopicEntity? topicEntity)
        {

            //var Db = DbConnect();
            using var Db = new MyDbContext();

            Db.Database.Migrate();

            Db.Add(new QuestionEntity() { Question = question, Answer1 = answer1, Answer2 = answer2, Answer3 = answer3, Answer4 = answer4, CorrectAnswer = correctAnswer});
            Db.SaveChanges();
        }

        public void CreateTopic(string topicName)
        {
            using var Db = new MyDbContext();

            Db.Database.Migrate();

            Db.Add(new TopicEntity() { TopicName = topicName });
            Db.SaveChanges();
        }

       

        public void DeleteQuestion()
        {
            throw new NotImplementedException();
        }

        public void DeleteTopic()
        {
            throw new NotImplementedException();
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
