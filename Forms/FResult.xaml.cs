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

namespace WPFQuestionnaire.Forms
{
    /// <summary>
    /// Interaction logic for FResult.xaml
    /// </summary>
    public partial class FResult : Window
    {
        public FResult()
        {
            InitializeComponent();
        }

        private void repeatBt_Click(object sender, RoutedEventArgs e)
        {
            var mainWin = new MainWindow();
            mainWin.Show();
            this.Close();
        }

        private void exitBt_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
