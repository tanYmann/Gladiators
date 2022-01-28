using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gladiaddi
{
    /// <summary>
    /// Interaktionslogik für LoadGladi.xaml
    /// </summary>
    public partial class LoadGladi : Page
    {
        public static DataGridView dataGrid = new DataGridView();
        public static Gladiator Gladi { get; set; }

        public LoadGladi()
        {
            InitializeComponent();
            LoadData();
        }

        public Gladiator LoadData()
        {

            TextReader tr = File.OpenText(@"C:\Users\tanzm\source\repos\gladiaddi\Saves\saves.json");
            JsonSerializer serializer = new JsonSerializer();
            Gladiator gladiJson = (Gladiator)serializer.Deserialize(tr, typeof(Gladiator));




            return gladiJson;
         
        }

        private void OnClickLoad(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu(LoadData()));
        }
    }
}
