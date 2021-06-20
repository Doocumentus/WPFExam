using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFQuestionnaire.Forms;
using WPFQuestionnaire.Implementations;
using WPFQuestionnaire.Models;

namespace WPFQuestionnaire.UseControls
{    public partial class QuestionUserControl : UserControl
    {
        public MainWindow mainWin;
        DBOperationEntity service;
        List<Question> questions;
        int numCorrectAnswers;
        int index;
        Stopwatch time;
        double percentageCompletion;

        public QuestionUserControl()
        {
            InitializeComponent();

            numCorrectAnswers = 0;
            index = 0;

            time = new Stopwatch();
            time.Start();
            service = new DBOperationEntity();
            questions = service.GetQuestions().ToList();

            questionTb.Text = questions[index].Issue;
        }

        private void contBt_Click(object sender, RoutedEventArgs e)
        {
            if (service.CheckAnswer(answerTb.Text, questions[index].Id) && answerTb.Text != "")
            {
                numCorrectAnswers++;
            }
            index++;
            if (index < questions.Count())
            {
                questionTb.Text = questions[index].Issue;
            }
            else
            {
                time.Stop();
                percentageCompletion = ((double)numCorrectAnswers / (double)questions.Count) * 100.0;
                var user = service.GetAllUser();
                service.Create(new ResultQuestionnaire
                {
                    UserID = user.Max(p => p.Id),
                    QuestionCount = questions.Count,
                    CorrectAnswers = numCorrectAnswers,
                    TimeSpent = time.Elapsed.ToString(),
                    CompletionPercent = percentageCompletion,
                    DateSurvey = DateTime.Now
                });
                var resultForm = new FResult();
                resultForm.questAllCountTb.Text = questions.Count.ToString();
                resultForm.answerCountTb.Text = numCorrectAnswers.ToString();
                resultForm.timeTb.Text = time.Elapsed.ToString();
                resultForm.percentTb.Text = percentageCompletion.ToString() + "%";
                resultForm.Show();
                mainWin.Close();
            }
        }
    }
}
