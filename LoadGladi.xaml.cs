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
      
        }

        public void LoadData()
        {
            List<Gladiator> gladiators = new List<Gladiator>();
            using (StreamReader sr = File.OpenText(@"~/Saves/saves.json"))
            {
                while (!sr.EndOfStream)
                {
                    JsonSerializer serializer = new JsonSerializer();
                    Gladiator gladiJson = (Gladiator)serializer.Deserialize(sr, typeof(Gladiator));
                    gladiators.Add(gladiJson);
                }

            }
            int i = 0;
            DataTable loadTable = new DataTable();
            loadTable.Columns.Add("Name");
            loadTable.Columns.Add("Level");
            loadTable.Columns.Add("Datum");

            List<Gladiator> tableGladiators = new List<Gladiator>();
            foreach (var item in gladiators)
            {
                DataRow row = loadTable.NewRow();
                row.BeginEdit();
                row.SetField(0, item.Name);
                row.SetField(1, item.Level);
                row.SetField(2, item.StartDate);
                row.EndEdit();
            }
            DataSet LoadData = new DataSet();
            LoadData.Tables.Add(loadTable);
         
        }

        private void OnClickLoad(object sender, RoutedEventArgs e)
        {

        }
    }
}
