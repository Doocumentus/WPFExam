using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFQuestionnaire.Models
{
    [Table("ResultsQuestionnaire")]
    public class ResultQuestionnaire
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int QuestionCount { get; set; }
        public int CorrectAnswers { get; set; }
        public string TimeSpent { get; set; }
        public double CompletionPercent { get; set; }
        public DateTime DateSurvey { get; set; }
    }
}
