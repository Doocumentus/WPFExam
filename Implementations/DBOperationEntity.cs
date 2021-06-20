using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFQuestionnaire.Abstract;
using WPFQuestionnaire.DBContext;
using WPFQuestionnaire.Models;

namespace WPFQuestionnaire.Implementations
{
    class DBOperationEntity : IDBOperations
    {
        public bool CheckAnswer(string answer,int quesID)
        {
            using (var db = new Context())
            {
                var ques = db.Questions.FirstOrDefault(p => p.Id == quesID);
                if (ques.Answer == answer)
                {
                    return true;
                }
                return false;
            }
        }

        public int Create(User user)
        {
            using (var db = new Context())
            {
                db.Users.Add(user);
                db.SaveChanges();
                return db.Users.Max(p => p.Id);
            }
        }

        public int Create(Question question)
        {
            using (var db = new Context())
            {
                db.Questions.Add(question);
                db.SaveChanges();
                return question.Id;
            }
        }

        public int Create(ResultQuestionnaire resultQuestionnaire)
        {
            using (var db = new Context())
            {
                db.ResultQuestionnaires.Add(resultQuestionnaire);
                db.SaveChanges();
                return resultQuestionnaire.Id;
            }
        }

        public void Delete(Question question)
        {
            using(var db = new Context())
            {
                string sqlDelete = $@"DELETE FROM Questions WHERE Id = @id;";
                db.Database.ExecuteSqlCommand(sqlDelete, new System.Data.SqlClient.SqlParameter { ParameterName = "@id", Value = question.Id });
            }
        }

        public void Delete(User user)
        {
            using(var db = new Context())
            {
                string sqlDelete = $@"DELETE FROM Users WHERE Id = @id;";
                db.Database.ExecuteSqlCommand(sqlDelete, new System.Data.SqlClient.SqlParameter { ParameterName = "@id", Value = user.Id });
            }
        }

        public IEnumerable<User> GetAllUser()
        {
            using (var db = new Context())
            {
                return db.Users.ToList();
            }
        }

        public Question GetQuestion(int id)
        {
            using (var db = new Context())
            {
                return db.Questions.FirstOrDefault(p => p.Id == id);
            }
        }

        public (int min, int max) GetQuestionMinAndMaxID()
        {

            int min = 0, max = 0;
            using (var db = new Context())
            {
                var question = db.Questions.ToList();
                min = question.Min(p => p.Id);
                max = question.Min(p => p.Id);
            }
            return (min, max);
        }

        public IEnumerable<Question> GetQuestions()
        {
            using(var db = new Context())
            {
                return db.Questions.ToList();
            }
        }

        public IEnumerable<ResultQuestionnaire> GetResultsQuestionnaire()
        {
            using(var db = new Context())
            {
                return db.ResultQuestionnaires.ToList();
            }
        }

        public IEnumerable<ResultQuestionnaire> GetResultsQuestionnaireByDate(DateTime fromDate, DateTime beforeDate)
        {
            using(var db = new Context())
            {
                return db.ResultQuestionnaires.Where(p => p.DateSurvey >= fromDate && p.DateSurvey <= beforeDate).ToList();
            }
        }

        public IEnumerable<ResultQuestionnaire> GetResultsQuestionnaireByUserID(int userID)
        {
            using(var db = new Context())
            {
                return  db.ResultQuestionnaires.Where(p => p.UserID == userID).ToList();
            }
        }

        public User GetUserByID(int id)
        {
           using(var db = new Context())
            {
                return db.Users.FirstOrDefault(p => p.Id == id);
            }
        }

        public IEnumerable<User> GetUsersByID(int id)
        {
            using(var db = new Context())
            {
                return db.Users.Where(p => p.Id == id).ToList();
            }
        }

        public void Update(Question quest)
        {
            using(var db = new Context())
            {
                var question = db.Questions.FirstOrDefault(p => p.Id == quest.Id);
                question.Issue = quest.Issue;
                question.Answer = quest.Answer;
                db.SaveChanges();
            }
        }
    }
}
