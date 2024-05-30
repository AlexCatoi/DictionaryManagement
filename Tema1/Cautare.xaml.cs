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
using Newtonsoft.Json;
using System.IO;
using System.ComponentModel;

namespace Tema1
{
    /// <summary>
    /// Interaction logic for Cautare.xaml
    /// </summary>
    public partial class Cautare : Window
    {
        private List<Files.Mydata> lista_categorii = Files.createList();
        private Files.Mydata cuv_curent;
        public Cautare()
        {
            InitializeComponent();
            Files.InitializeComboBox(ref categorie,true);
            categorie.SelectionChanged += IsChanged;
            InitializeSearchBar();
        }
        
        public void InitializeSearchBar()
        {
            List<string> words = new List<string>();
            foreach (Files.Mydata data in lista_categorii)
            {
                if (data.Categorie == categorie.SelectedItem.ToString() || categorie.SelectedItem.ToString()=="Any")
                    words.Add(data.Cuvant);
            }
            SearchBar.ItemsSource= words;
            SearchBar.SelectionChanged += showWord;
        }

        private void showWord(object sender, SelectionChangedEventArgs e)
        {
            string formatat = "";
            if(SearchBar.SelectedItem!=null)
            {
                formatat = SearchBar.SelectedItem.ToString()+'\n'+'\n';
               foreach(Files.Mydata data in lista_categorii){
                    if (data.Cuvant == SearchBar.SelectedItem.ToString())
                    {
                        formatat += data.Descriere;
                        iamgine.Source= new BitmapImage(new Uri(data.Image));
                        cuv_curent = data;
                        break;
                    }
                }
               display.Text = formatat;
            }
            EditEnable();
        }

        private void IsChanged(object sender, EventArgs e)
        {
            InitializeSearchBar();
        }
        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.Show();
        }
        private void EditEnable()
        {
            if(Login.IsAdmin==true && SearchBar.SelectedItem != null)
                Edit.Visibility = Visibility.Visible;
        }
        private void EditWord(object sender, RoutedEventArgs e)
        {
            Edit.Visibility = Visibility.Hidden;
            Adaugare add = new Adaugare(cuv_curent.Categorie,cuv_curent.Cuvant,cuv_curent.Descriere,cuv_curent.Image);
            Files.DeleteFromJson(cuv_curent);
            this.Close();
            add.Show();
        }
    }
}
