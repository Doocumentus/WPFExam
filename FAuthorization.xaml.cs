using NLog;
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
using WPFQuestionnaire.Forms;
using WPFQuestionnaire.Implementations;
using WPFQuestionnaire.Models;

namespace WPFQuestionnaire
{
    /// <summary>
    /// Interaction logic for FAuthorization.xaml
    /// </summary>
    public partial class FAuthorization : Window
    {
        DBOperationEntity service;
        static Logger log = LogManager.GetCurrentClassLogger();
        public FAuthorization()
        {
            InitializeComponent();
            service = new DBOperationEntity();
        }

        private void okBt_Click(object sender, RoutedEventArgs e)
        {
            if(cb.IsChecked == true)
            {
                var adminWin = new FAdministration();
                adminWin.Show();
                this.Close();
                return;
            }
            string fName = fNameTb.Text;
            string lName = lNameTb.Text;
            if(fName == "" || lName == "")
            {
                MessageBox.Show("Error:The First and Last Name fields cannot be empty!");
            }
            else
            {
                var user = new User()
                {
                    FirstName = fName,
                    LastName = lName
                };
                int id = service.Create(user);
                var mainWin = new MainWindow();
                log.Info($"Добавлен новый пользователь");
                mainWin.Show();
                this.Close();
            }
        }

        private void cancelBt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cb_Click(object sender, RoutedEventArgs e)
        {
            if(cb.IsChecked == true)
            {
                fNameTb.IsEnabled = false;
                lNameTb.IsEnabled = false;
            }
            else
            {
                fNameTb.IsEnabled = true;
                lNameTb.IsEnabled = true;
            }
        }
    }
}
