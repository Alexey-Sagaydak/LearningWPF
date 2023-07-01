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

namespace LearningWPF
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {

        public AuthWindow()
        {
            InitializeComponent();
            MainWindow window = new MainWindow();
            window.Show();
        }

        private void ButtonAuthClick(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim(),
                pass1 = TextPassBox.Password.Trim();

            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Некорректный ввод";
                TextBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass1.Length < 5)
            {
                TextPassBox.ToolTip = "Некорректный ввод";
                TextPassBox.Background = Brushes.DarkRed;
            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;

                TextPassBox.ToolTip = "";
                TextPassBox.Background = Brushes.Transparent;

                User authUser = null;

                using (AppContext db = new AppContext())
                {
                    authUser = db.Users.Where(b => b.login == login && b.password == pass1).FirstOrDefault();
                }

                if (authUser != null)
                    MessageBox.Show("Пользователь найден!");
                else
                    MessageBox.Show("Пользователь не найден!");
            }
        }
    }
}
