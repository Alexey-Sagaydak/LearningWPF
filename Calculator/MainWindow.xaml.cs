using System;
using System.Collections.Generic;
using System.Data;
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

namespace Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement el in MainGrid.Children)
                if (el is Button)
                    ((Button)el).Click += ButtonClick;
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            string str = ((Button)e.OriginalSource).Content.ToString();

            if (str == "AC")
                TextLabel.Text = string.Empty;
            else if (str == "=")
                TextLabel.Text = new DataTable().Compute(TextLabel.Text, null).ToString();
            else
                TextLabel.Text += str;
        }
    }
}
