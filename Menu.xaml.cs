using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
using static gladiaddi.NewGladi;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace gladiaddi
{
    /// <summary>
    /// Interaktionslogik für Page3.xaml
    /// </summary>
    partial class Menu : Page
    {
        public static List<string> saveGames = new List<string>();
        public Gladiator Gladi;
        
        public Menu()
        {

        }
        public Menu (Gladiator gladiator)
        
        {      
           
            InitializeComponent();
            GladiName.Text = gladiator.Name;
            GladiStamina.Text = gladiator.Stamina.ToString();
            GladiAttack.Text = gladiator.Attack.ToString();
            GladiDefense.Text = gladiator.Defense.ToString();
            GladiLevel.Text = SetLevel(gladiator).ToString();
            GladiXp.Text = gladiator.Xp.ToString();
            Gladi = gladiator;
            Gladi.Level = SetLevel(gladiator);
            CoinTxt.Text =   gladiator.Coins.ToString();
            string bitmapPath = @"C:\Users\tanzm\source\repos\gladiaddi\Images\";
            BitmapImage bitmapImage = new BitmapImage(new Uri(bitmapPath + gladiator.ImgUrl, UriKind.Absolute));
            if(bitmapImage == null)
            {
                bitmapImage = new BitmapImage(new Uri(bitmapPath + "GladiFace001.png"));
            }
            GladiImg.Source = bitmapImage;

        }
        public int SetLevel(Gladiator gladiator)
        {
           int level = 1;
            for (int i = 0; i < 1000; i++)
            {
                if (gladiator.Xp / 100 == i)
                    level = i + 1;
            }
                    
           
            
            return level;
        }
        public void setGladiator()
        {        
            
        }

        private void OnFightBtnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Fight(Gladi));
        }

        private void OnClickStatBtn(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1(Gladi));
        }

        private void OnClickTrain(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Training(Gladi));
        }

        private void OnClickMenu(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2(Gladi));
        }

        private void OnClickSave(object sender, RoutedEventArgs e)
        {
           
            string output = JsonConvert.SerializeObject(Gladi);
            
            FileStream file = new FileStream(@"C:\Users\tanzm\source\repos\gladiaddi\Saves\saves.json", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(file);
            
            sw.WriteLine(sw.NewLine);
            sw.WriteLine(output);
            sw.Flush();
            sw.Close();
            file.Close();

            /*
            string query = "Insert into Gladiators (Name,Stamina,Attack,Defense,Fights,Won,Level,Xp,ImgUrl,Coins) values (@Name,@Stamina,@Attack,@Defense,@Fights,@Won,@Level,@Xp,@ImgUrl,@Coins)";
            SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tanzm\Documents\Gladiators.mdf;Integrated Security=True;Connect Timeout=30");
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
            */
        }
    }
}
