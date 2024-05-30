using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;

namespace Tema1
{
    internal class Files
    {
        public class Mydata
        {
            public string Categorie { get; set; }
            public string Cuvant { get; set; }
            public string Descriere { get; set; }
            public string Image { get; set; }
        }
        public static void saveToJsonFile(List<Mydata> list)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText("../../cuvinte.json", json);
        }
        public static Mydata generateObject(string cat,string cuv,string desc,string img)
        {
            Mydata data = new Mydata()
            {
                Categorie = cat,
                Cuvant = cuv,
                Descriere = desc,
                Image = img
            };
            return data;
        }
        public static List<Mydata> createList()
        {
            var file = File.ReadAllText("../../cuvinte.json");
            var list = JsonConvert.DeserializeObject<List<Mydata>>(file) ?? new List<Mydata>();
            return list;
        }
        public static void InitializeComboBox(ref System.Windows.Controls.ComboBox container,bool ok)
        {
                List<string> differentCategories = new List<string>();
                List<Mydata> list = createList();
                if (ok)
                {
                    container.Items.Add("Any");
                }
                foreach (Mydata data in list)
                {
                    if (!differentCategories.Contains(data.Categorie))
                    {
                        differentCategories.Add(data.Categorie);
                    }
                }
                foreach (string word in differentCategories)
                {
                    container.Items.Add(word);
                }
        }
        public static void DeleteFromJson(Mydata data)
        {
            List<Mydata> list = createList();
            foreach (Mydata data1 in list) {
                if (data1.Cuvant == data.Cuvant)
                {
                    list.Remove(data1);
                    break;
                }
            }
            saveToJsonFile(list);
        }
    }
}
