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
using WPFQuestionnaire.Models;
using WPFQuestionnaire.UseControls;

namespace WPFQuestionnaire.Forms
{
    public partial class FReport : Window
    {

        public FReport()
        {
            InitializeComponent();
            grid.Children.Add(GetSearchUserControl());
        }

        private UserControl GetSearchUserControl()
        {
            SearchUserControl searchUc = new SearchUserControl();
            searchUc.Width = 300;
            searchUc.Height = 300;
            searchUc.Margin = new Thickness(0, 20, 0, 0);
            searchUc.fReport = this;
            return searchUc;
        }

        private void dateBt_Click(object sender, RoutedEventArgs e)
        {
            grid.Children.Add(GetSearchUserControl());
        }

        private void backBt_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
