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

namespace LearningWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new AppContext();

            List<User> users = db.Users.ToList();
            string str = "";

            foreach (User user in users)
            {
                str += user.password + " | ";
            }

            TempTextBlock.Text = str;
        }

        private void ButtonRegClick(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim(),
                pass1 = TextPassBox1.Password.Trim(),
                pass2 = TextPassBox2.Password.Trim(),
                email = TextBoxEmail.Text.Trim().ToLower();

            if (login.Length < 5)
            {
                TextBoxLogin.ToolTip = "Некорректный ввод";
                TextBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass1.Length < 5)
            {
                TextPassBox1.ToolTip = "Некорректный ввод";
                TextPassBox1.Background = Brushes.DarkRed;
            }
            else if (pass1 != pass2)
            {
                TextPassBox2.ToolTip = "Пароли не совпадают!";
                TextPassBox2.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                TextBoxEmail.ToolTip = "Некорректный ввод";
                TextBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                TextBoxLogin.ToolTip = "";
                TextBoxLogin.Background = Brushes.Transparent;

                TextPassBox1.ToolTip = "";
                TextPassBox1.Background = Brushes.Transparent;

                TextPassBox2.ToolTip = "";
                TextPassBox2.Background = Brushes.Transparent;

                TextBoxEmail.ToolTip = "";
                TextBoxEmail.Background = Brushes.Transparent;

                db.Users.Add(new User(login, pass1, email));
                db.SaveChanges();

                MessageBox.Show("Всё хорошо!");
            }
        }
    }
}
