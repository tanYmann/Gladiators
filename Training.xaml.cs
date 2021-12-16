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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace gladiaddi
{
    /// <summary>
    /// Interaktionslogik für Training.xaml
    /// </summary>
    public partial class Training : Page
    {
        public int newStamina = 0;
        public int newAttack = 0;
        public int newDefense = 0;
        public Gladiator Gladi = new Gladiator();
        public Training(Gladiator gladiator)
        {
            InitializeComponent();
            Gladi = gladiator;
            GladiName.Text = Gladi.Name;
            GladiStamina.Text = Gladi.Stamina.ToString() ;
            GladiAttack.Text = Gladi.Attack.ToString();
            GladiDefense.Text = Gladi.Defense.ToString();
            CoinTxt.Text = Gladi.Coins.ToString();
            /* string bitmapPath = @"C:\Users\tanzm\source\repos\gladiaddi\";
             BitmapImage bitmapImage = new BitmapImage(new Uri(bitmapPath + gladiator.ImgUrl, UriKind.Absolute));
           playerImage.Source = bitmapImage;
             */
        }


        private void TrainStamina(object sender, RoutedEventArgs e)
        {
            if (Gladi.Coins > 0)
            {
                Gladi.Coins -= 1;
                Random rnd = new Random();
                newStamina = (Gladi.Stamina / 10) * rnd.Next(1, 10);
                ResultStamina.Text = (Gladi.Stamina + newStamina).ToString();
                Gladi.Stamina += newStamina;
            }
            else
            {
                ResultStamina.Background = Brushes.Red;
                ResultStamina.Text = "Nicht genügend Münzen";
            }

        }

        private void TrainAttack(object sender, RoutedEventArgs e)
        {
            if (Gladi.Coins >= 3)
            {
                Gladi.Coins -= 3;
                Random rnd = new Random();
                newAttack = 1;
                ResultAttack.Text = (Gladi.Attack + newAttack).ToString();
                Gladi.Attack += newAttack;
            }
            else
            {
                ResultAttack.Background = Brushes.Red;
                ResultAttack.Text = "Nicht genügend Münzen";
            }

        }

        private void TrainDefense(object sender, RoutedEventArgs e)
        {
            if (Gladi.Coins >= 2)
            {
                Gladi.Coins -= 2;
                Random rnd = new Random();
                newDefense = 1;
                ResultDefense.Text = (Gladi.Defense + newDefense).ToString();
                Gladi.Defense += newDefense;
            }
            else
            {
                ResultDefense.Background = Brushes.Red;
                ResultDefense.Text = "Nicht genügend Münzen";
            }

        }
        private void OnClickSave(object sender, RoutedEventArgs e)
        {
           
            
            
            NavigationService.Navigate(new Menu(Gladi));
        }

    }
}
