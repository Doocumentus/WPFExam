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
    public partial class FQuestionUpdate : Window
    {
        DBOperationEntity service;
        public FQuestionUpdate()
        {
            InitializeComponent();
            service = new DBOperationEntity();
        }

        private void updateBt_Click(object sender, RoutedEventArgs e)
        {
            service.Update(new Question {
                Id = int.Parse(idTb.Text),
                Issue = questTb.Text,
                Answer = answerTb.Text
            });
            this.Close();
        }
    }
}
