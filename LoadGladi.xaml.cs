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
        
        public static Gladiator Gladi {get;set;}
        public LoadGladi()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {   
            string query = "SELECT * FROM SAVES";
            SqlConnection connection = new SqlConnection(@"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = Gladiaddi; Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
            SqlCommand getSaves = new SqlCommand(query, connection);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(getSaves);
            DataTable table = new DataTable("Saves");
            connection.Open();
            dataAdapter.Fill(table);
            DataGridSaves.ItemsSource = table.DefaultView;
            connection.Close();
                        

        }

        public void SelectionToGladi()
        {
             
        }
        private void OnClickLoad(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new NewGladi(Gladi));
        }
    }
}
