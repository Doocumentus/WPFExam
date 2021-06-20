using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFQuestionnaire.Models;

namespace WPFQuestionnaire.Abstract
{
    public interface IDBOperations
    {
        IEnumerable<Question> GetQuestions();
        Question GetQuestion(int id);
        IEnumerable<User> GetAllUser();
        IEnumerable<User> GetUsersByID(int id);
        User GetUserByID(int id);

        IEnumerable<ResultQuestionnaire> GetResultsQuestionnaire();
        IEnumerable<ResultQuestionnaire> GetResultsQuestionnaireByDate(DateTime fromDate,DateTime beforeDate);
        IEnumerable<ResultQuestionnaire> GetResultsQuestionnaireByUserID(int userID);

        int Create(User user);
        int Create(Question question);
        int Create(ResultQuestionnaire resultQuestionnaire);
        void Delete(Question quest);
        void Delete(User user);
        void Update(Question quest);
        bool CheckAnswer(string answer,int quesID);

 
    }
}
