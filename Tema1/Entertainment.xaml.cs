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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tema1
{
    /// <summary>
    /// Interaction logic for Entertainment.xaml
    /// </summary>
    public partial class Entertainment : Window
    {
        private int nrIntrebareCurenta=1;
        private int score = 0;
        private List<Files.Mydata> lista = Files.createList();
        private int NrCuvant;
        public Entertainment()
        {
            InitializeComponent();
            generateQuestion();
        }
        private void generateQuestion()
        {
            curent.Content = "Intrebarea curenta: " + nrIntrebareCurenta + "/5";
            Random rnd = new Random();
            NrCuvant = rnd.Next(0,lista.Count());
            int textOrImage=rnd.Next(0,2);
            if(textOrImage==0)
            {
                Descriere.Visibility = Visibility.Visible;
                Imagine.Visibility= Visibility.Hidden;
                Descriere.Text = lista[NrCuvant].Descriere;
            }
            else
            {
                Imagine.Visibility= Visibility.Visible;
                Descriere.Visibility = Visibility.Hidden;
                Imagine.Source = new BitmapImage(new Uri(lista[NrCuvant].Image));
            }
        }

        private void validate_Click(object sender, RoutedEventArgs e)
        {
            if (input.Text == "")
                return;
            else
            {
                if (input.Text.ToLower() == lista[NrCuvant].Cuvant.ToLower())
                {
                    game.Background = Brushes.LimeGreen;
                    score += 1;
                    MessageBox.Show("Raspuns Corect!", "Congrats", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    game.Background = Brushes.Red;
                    MessageBox.Show($"Raspuns Gresit!\n Raspunsul Corect: {lista[NrCuvant].Cuvant}", "Close", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                game.Background= Brushes.Beige;
                input.Text = "";
                nrIntrebareCurenta += 1;
                if (nrIntrebareCurenta > 5)
                {
                    Descriere.Visibility = Visibility.Visible;
                    input.Visibility = Visibility.Hidden;
                    Imagine.Visibility = Visibility.Hidden;
                    input.Visibility= Visibility.Hidden;
                    label.Visibility = Visibility.Hidden;
                    curent.Visibility = Visibility.Hidden;
                    Descriere.Text = $"Your final score: {score}/5";
                    Descriere.HorizontalAlignment = HorizontalAlignment.Center;
                    Descriere.VerticalAlignment = VerticalAlignment.Center;
                    Descriere.FontSize = 40;
                    back.Visibility = Visibility.Visible;
                }
                else
                {
                    generateQuestion();
                }
            }
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }
    }
}
