using System;
using System.Collections.Generic;
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
using static gladiaddi.MainWindow;

namespace gladiaddi
{
    /// <summary>
    /// Interaktionslogik für Page1.xaml
    /// </summary>
    public partial class NewGladi : Page
    {
        public int Index { get; set; }
        public static List  <Gladiator> gladiList = new List<Gladiator>();
        
        public NewGladi()
        {
            InitializeComponent();
           
        }


        public static Gladiator gladiatorPlayer = new Gladiator();
        public void OnChecked(object sender, RoutedEventArgs e)
        {
            
          
            RadioButton rb = sender as RadioButton;
            if(rb.IsChecked == GladiBoyRadio.IsChecked)
            {
                gladiatorPlayer.Name = "GladiBoy";
                gladiatorPlayer.Stamina = 100;
                gladiatorPlayer.Attack = 8;
                gladiatorPlayer.Defense = 6;
                gladiatorPlayer.ImgUrl = "GladiFace002.png";
                gladiatorPlayer.Level = 1;
                gladiatorPlayer.Xp = 0;
               
               
            }
            if(rb.IsChecked == MerkurMagicRadio.IsChecked)
            {
                gladiatorPlayer.Name = "MerkurMagic";
                gladiatorPlayer.Stamina = 94;
                gladiatorPlayer.Attack = 7;
                gladiatorPlayer.Defense = 8;
                gladiatorPlayer.ImgUrl = "GladiFace001.png";
                gladiatorPlayer.Level = 1;
                gladiatorPlayer.Xp = 0;
              
              
            }
            if (rb.IsChecked == BasherRadio.IsChecked)
            {
                gladiatorPlayer.Name = "The Basher";
                gladiatorPlayer.Stamina = 89;
                gladiatorPlayer.Attack = 11;
                gladiatorPlayer.Defense = 3;
                gladiatorPlayer.ImgUrl = "GladiFace002.png";
                gladiatorPlayer.Level = 1;
                gladiatorPlayer.Xp = 0;
              
                

            }

            StaminaText.Text = gladiatorPlayer.Stamina.ToString();
            DefenseText.Text = gladiatorPlayer.Defense.ToString();
            AttackText.Text = gladiatorPlayer.Attack.ToString();

        }

        public static int Inde;
        public void OnClickGo(object sender, RoutedEventArgs e)
        {
            
            gladiList.Add(gladiatorPlayer);
            Inde = gladiList.IndexOf(gladiatorPlayer);
            this.NavigationService.Navigate(new Uri("Menu.xaml", UriKind.Relative));
            
            


        }
    }
}
