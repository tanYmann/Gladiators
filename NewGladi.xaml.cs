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
        
        
        public NewGladi()
        {
            InitializeComponent();
           
        }


        public Gladiator gladiatorPlayer = new Gladiator();
        public void OnChecked(object sender, RoutedEventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;

           switch(radioButton.Name)
           {
                case "MerkurMagicRadio":

                    this.gladiatorPlayer.Name = "GladiBoy";
                    gladiatorPlayer.Stamina = 100;
                    gladiatorPlayer.Attack = 11;
                    gladiatorPlayer.Defense = 3;
                    this.gladiatorPlayer.ImgUrl = "GladiFace002.png";
                    gladiatorPlayer.Level = 1;
                    gladiatorPlayer.Xp = 0;
                    gladiatorPlayer.Coins = 0;

                    break;

                case "GladiBoyRadio":

                    this.gladiatorPlayer.Name = "MerkurMagic";
                    gladiatorPlayer.Stamina = 120;
                    gladiatorPlayer.Attack = 8;
                    gladiatorPlayer.Defense = 8;
                    this.gladiatorPlayer.ImgUrl = "GladiFace001.png";
                    gladiatorPlayer.Level = 1;
                    gladiatorPlayer.Xp = 0;
                    gladiatorPlayer.Coins = 0;
                    break;

                case "BasherRadio":

                    this.gladiatorPlayer.Name = "Basher";
                    gladiatorPlayer.Stamina = 85;
                    gladiatorPlayer.Attack = 12;
                    gladiatorPlayer.Defense = 10;
                    this.gladiatorPlayer.ImgUrl = "GladiFace003.png";
                    gladiatorPlayer.Level = 1;
                    gladiatorPlayer.Xp = 0;
                    gladiatorPlayer.Coins = 0;
                    break;
            }

            StaminaText.Text = gladiatorPlayer.Stamina.ToString();
            AttackText.Text = gladiatorPlayer.Attack.ToString();
            DefenseText.Text = gladiatorPlayer.Defense.ToString();
            TBName.Text = gladiatorPlayer.Name;
            
           
           
        }

        public static int Inde;
        
        public void OnClickGo(object sender, RoutedEventArgs e)
        {


            NavigationService.Navigate(new Menu(gladiatorPlayer));
            
            


        }
    }
}
