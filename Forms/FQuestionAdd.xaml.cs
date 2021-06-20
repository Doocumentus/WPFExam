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
using WPFQuestionnaire.Abstract;
using WPFQuestionnaire.Implementations;
using WPFQuestionnaire.Models;

namespace WPFQuestionnaire.Forms
{
    public partial class FQuestionAdd : Window
    {
        DBOperationEntity service;
        public FQuestionAdd()
        {
            InitializeComponent();
            service = new DBOperationEntity();
        }

        private void addBt_Click(object sender, RoutedEventArgs e)
        {
            if(questTb.Text == "" || answerTb.Text == "")
            {
                MessageBox.Show($@"Error:The Enter question and Enter answer fields cannot be empty");
            }
            else
            {
                service.Create(new Question
                {
                    Issue = questTb.Text,
                    Answer = answerTb.Text
                });
            }
            this.Close();
        }
    }
}
