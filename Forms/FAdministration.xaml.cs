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
using System.Windows.Shapes;
using WPFQuestionnaire.Implementations;
using WPFQuestionnaire.Models;

namespace WPFQuestionnaire.Forms
{
    public partial class FAdministration : Window
    {
        DBOperationEntity service;
        public FAdministration()
        {
            InitializeComponent();
            service = new DBOperationEntity();

            userDg.ItemsSource = service.GetAllUser();
            questDg.ItemsSource = service.GetQuestions();
            resultDg.ItemsSource = service.GetResultsQuestionnaire();
        }

        private void resultDg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int userID = (resultDg.SelectedItem as ResultQuestionnaire).UserID;
            userDg.ItemsSource = service.GetUsersByID(userID);
        }

        private void userDg_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int userID = (userDg.SelectedItem as User).Id;
            resultDg.ItemsSource = service.GetResultsQuestionnaireByUserID(userID);
        }
        private void userMenu_Click(object sender, RoutedEventArgs e) => userDg.ItemsSource = service.GetAllUser();

        private void deleteMenu_Click(object sender, RoutedEventArgs e)
        {
            if (userDg.SelectedIndex == -1)
            {
                MessageBox.Show("Ошибка: Не выбрана запись для удаления");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены что хотите удалить выбранную запись?", "Подтверждение удаления", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                service.Delete((userDg.SelectedItem as User));
            }

        }

        private void allQuestionMenu_Click(object sender, RoutedEventArgs e) => questDg.ItemsSource = service.GetQuestions();

        private void questDeleteMenu_Click(object sender, RoutedEventArgs e)
        {
            if (questDg.SelectedIndex == -1)
            {
                MessageBox.Show("Ошибка: Не выбрана запись для удаления");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы уверены что хотите удалить выбранную запись?", "Подтверждение удаления", MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (messageBoxResult == MessageBoxResult.OK)
            {
                service.Delete((questDg.SelectedItem as Question));
            }
        }

        private void questAddMenu_Click(object sender, RoutedEventArgs e)
        {
            var addForm = new FQuestionAdd();
            addForm.ShowDialog();
        }

        private void questUpdateMenu_Click(object sender, RoutedEventArgs e)
        {
            if (questDg.SelectedIndex == -1)
            {
                MessageBox.Show("Ошибка: Не выбрана запись для удаления");
                return;
            }
            var updateFrom = new FQuestionUpdate();
            updateFrom.idTb.Text = (questDg.SelectedItem as Question).Id.ToString();
            updateFrom.questTb.Text = (questDg.SelectedItem as Question).Issue;
            updateFrom.answerTb.Text = (questDg.SelectedItem as Question).Answer;
            updateFrom.ShowDialog();
        }

        private void resultAllMenu_Click(object sender, RoutedEventArgs e) => resultDg.ItemsSource = service.GetResultsQuestionnaire();


        private void backMenu_Click(object sender, RoutedEventArgs e)
        {
            var authMenu = new FAuthorization();
            authMenu.Show();
            this.Close();
        }

        private void resultReportMenu_Click(object sender, RoutedEventArgs e)
        {
            var fReport = new FReport();
            fReport.Show();
            this.Close();
        }
    }
}
