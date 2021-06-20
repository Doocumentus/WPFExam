using System;
using System.Collections.Generic;
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
{
    public partial class SearchUserControl : UserControl
    {
        public FReport fReport;
        DBOperationEntity service;
        public SearchUserControl()
        {
            InitializeComponent();
            service = new DBOperationEntity();
            beforeDp.SelectedDate = DateTime.Now;
        }

        private void searchBt_Click(object sender, RoutedEventArgs e)
        {
            var resultQuestion = service.GetResultsQuestionnaireByDate(fromDp.SelectedDate.Value, beforeDp.SelectedDate.Value).ToList();
            var users = new List<User>();
            foreach(var item in resultQuestion)
            {
                users.Add(service.GetUserByID(item.UserID));
            }
            var reportList = new List<Report>();

            int i = 0;
            int j = 0;

            do
            {
                if (i >= users.Count && j >= resultQuestion.Count) break;

                reportList.Add(new Report
                {
                    LastName = users[i].LastName,
                    FirstName = users[i].FirstName,
                    ResultPrecent = resultQuestion[j].CompletionPercent,
                    DateSurvey = resultQuestion[j].DateSurvey
                });

                if (i < users.Count) i++;
                if (j < resultQuestion.Count) j++;

            } while (true);

            fReport.reportDg.ItemsSource = reportList;
            fReport.grid.Children.Remove(this);
        }
    }
}
