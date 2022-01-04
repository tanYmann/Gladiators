using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
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
        public static DataGridView dataGrid= new DataGridView();
        public static Gladiator Gladi {get;set;}
        public LoadGladi()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            dataGrid.DataSource = DataGridSaves;
            dataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGrid.MultiSelect = false;
            string query = "SELECT * FROM GLADIATORS";
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tanzm\Documents\Gladiators.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand getSaves = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(getSaves);
            DataTable table = new DataTable("Gladiators");
            connection.Open();
            dataAdapter.Fill(table);
            dataGrid.DataSource = table.DefaultView;
            connection.Close();
     
            
            List<string> gladiData = new List<string>();
            foreach(var entry in dataGrid.SelectedCells)
            {
                gladiData.Add(entry.ToString());
            }
        }

        DataSet dset = new DataSet();
        /*
        public void SelectionToGladi(
        {

            
            List<string> gladiData = new List<string>();
            foreach (var entry in )
            {
                gladiData.Add(entry.ToString());
            }

        }
*/
        private void OnClickLoad(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu(Gladi));
        }
    }
}
