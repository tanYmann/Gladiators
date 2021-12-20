using LinqKit;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Interaktionslogik für Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Gladiator Gladi = new Gladiator();
        public Page2(Gladiator gladiator)
        {
            Gladi = gladiator;
            InitializeComponent();
        }

        private void OnClickSave(object sender, RoutedEventArgs e)
        {
            string query = "Insert into Saves (Name,Stamina,Attack,Defense,Fights,Won,Level,Xp,ImgUrl,Coins) values (@Name,@Stamina,@Attack,@Defense,@Fights,@Won,@Level,@Xp,@ImgUrl,@Coins)";
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Gladiaddi;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            SqlCommand saveCommand = new SqlCommand(query, connection);
            saveCommand.Parameters.AddWithValue("@Name", Gladi.Name);
            saveCommand.Parameters.AddWithValue("@Stamina", Gladi.Stamina);
            saveCommand.Parameters.AddWithValue("@Attack", Gladi.Attack);
            saveCommand.Parameters.AddWithValue("@Defense", Gladi.Defense);
            saveCommand.Parameters.AddWithValue("@Fights", Gladi.Fights);
            saveCommand.Parameters.AddWithValue("@Won", Gladi.Wins);
            saveCommand.Parameters.AddWithValue("@Level", Gladi.Level);
            saveCommand.Parameters.AddWithValue("@Xp", Gladi.Xp);
            saveCommand.Parameters.AddWithValue("@ImgUrl", Gladi.ImgUrl);
            saveCommand.Parameters.AddWithValue("@Coins", Gladi.Coins);
            connection.Open();
            saveCommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}

  