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
using System.IO;

namespace Tema1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public static bool IsAdmin=false;
        public Login()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }
        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            string username = Username.Text;
            string password = Password.Password;
            string[] contents = File.ReadAllLines("../../admin.txt");
            if (username == contents[0] && password == contents[1])
            {
                IsAdmin = true;
                MainWindow main = new MainWindow();
                this.Close();
                main.Show();
            }
            else
            {
                MessageBox.Show("Username or password is invalid!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
