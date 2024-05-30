using Microsoft.Win32;
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
using System.Xml.Serialization;
using System.IO;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Markup;
using System.Collections;
namespace Tema1
{
    /// <summary>
    /// Interaction logic for Adaugare.xaml
    /// </summary>
    public partial class Adaugare : Window
    {
        public Adaugare(string cat,string cuv,string desc,string img)
        {
            InitializeComponent();
            Files.InitializeComboBox(ref categorie, false);
            categorie.SelectedValue = cat;
            cuvant.Text=cuv;
            descriere.Text=desc;
            Imagine.Source = new BitmapImage(new Uri(img));
            Cancel.Content = "Delete";
            addIt.Content = "Save";
        }
        public Adaugare()
        {
            InitializeComponent();
            Files.InitializeComboBox(ref categorie,false);
        }

            private void Cancel_clicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult response=MessageBoxResult.None;
            MainWindow main = new MainWindow();
            if (Cancel.Content == "Delete")
                { 
                response=MessageBox.Show("Are you sure you wanna delete it!", "Delete", MessageBoxButton.OKCancel, MessageBoxImage.Information);
                if (response == MessageBoxResult.OK)
                {
                    this.Close();
                    main.Show();
                }
            }
            else
            { 
                this.Close();
                main.Show();
            }
        }
        private void Adauga_clicked(object sender, RoutedEventArgs e)
        {
            string imageSource = "C:\\Users\\Alex\\Pictures\\Camera Roll\\not_found.jpg";
            if (Imagine.Source is BitmapImage bitmapImage)
            {
                imageSource = bitmapImage.UriSource.OriginalString;
            }
            if (Verificare())
            {
                Files.Mydata data=Files.generateObject(categorie.Text, cuvant.Text, descriere.Text, imageSource);
                List<Files.Mydata> list = Files.createList();
                list.Add(data);
                Files.saveToJsonFile(list);
                MainWindow main = new MainWindow();
                this.Close();
                main.Show();
            }
            else
            {
                categorie.Text = "";
                cuvant.Text = "";
                descriere.Text = "";
                Imagine.Source = new BitmapImage(new Uri("C:\\Users\\Alex\\Pictures\\Camera Roll\\not_found.jpg"));
            }
        }

        private void Add_Image(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.png;*.jpg;*.jpeg;*.gif;*.webp";
            openFileDialog.FilterIndex = 0;
            if(openFileDialog.ShowDialog()==true)
            {
                Imagine.Source=new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private Boolean Verificare()
        {
            if(categorie.Text=="" || descriere.Text=="" || cuvant.Text=="")
            {
                MessageBox.Show("One or more fields are not completed!","Error" ,MessageBoxButton.OK,MessageBoxImage.Error);  
                return false;
            }
            else if(Imagine.Source==null)
            {
                Imagine.Source = new BitmapImage(new Uri("C:\\Users\\Alex\\Pictures\\Camera Roll\\not_found.jpg"));
            }
            return true;
        }
    }
}