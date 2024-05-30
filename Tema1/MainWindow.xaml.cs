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

namespace Tema1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Login.IsAdmin==true)
            {
                login_in.Visibility = Visibility.Hidden;
                Adauga.Visibility = Visibility.Visible;
            }
        }
        private void login_clicked(object sender,RoutedEventArgs e)
        {
            Login login = new Login();
            this.Close();
            login.Show();
        }
        private void add_clicked(object sender, RoutedEventArgs e)
        {
            Adaugare addNewWord = new Adaugare();
            this.Close();
            addNewWord.Show();
        }
        private void search_clicked(object sender, RoutedEventArgs e)
        {
            Cautare search = new Cautare();
            this.Close();
            search.Show();
        }
        private void game_click(object sender, RoutedEventArgs e)
        {
            Entertainment game = new Entertainment();
            this.Close();
            game.Show();
        }
    }
}
