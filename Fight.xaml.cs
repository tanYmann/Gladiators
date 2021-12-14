using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaktionslogik für Page1.xaml
    /// </summary>
    public partial class Fight : Page
    {
        public Gladiator GladiPlayer = new Gladiator();
        public Gladiator opponent = new Gladiator();
        public Fight(Gladiator gladiator)
        {
            SetOpponent(gladiator, opponent);
            GladiPlayer = gladiator;
            InitializeComponent();
            OpponentTxt.Text = "Ausdauer : " + opponent.Stamina.ToString() + "Angriff : " + opponent.Attack.ToString() + "Verteidigung :" + opponent.Defense.ToString() + "";
            GladiPlayerTxt.Text = "Ausdauer : " + gladiator.Stamina.ToString() + "Angriff : " + gladiator.Attack.ToString() + "Verteidigung :" + gladiator.Defense.ToString() + "";
        }
      

        public void SetOpponent(Gladiator gladiPlayer, Gladiator gladiOpponent)
        {
            
            Random rnd = new Random();
            int factor = gladiPlayer.Level;
            gladiOpponent.Stamina =  rnd.Next(6,10) * 10* factor;
            gladiOpponent.Defense = 1 * rnd.Next(1,10) * factor;
            gladiOpponent.Attack = 1  * rnd.Next(1,10) *  factor ;
        }
        public int schaden = 0;
        public void Fighting(Gladiator gladiPlayer, Gladiator gladiOpponent)
        {
            Gladiator attacker = new Gladiator();
            Gladiator defender = new Gladiator();
            Gladiator space = new Gladiator();
            Random rnd = new Random();
            int stamina_save = GladiPlayer.Stamina;
            if (rnd.Next(1,2)==1)
            {
                attacker = gladiPlayer;
                defender = gladiOpponent;

            }
            else
            {
                attacker = gladiOpponent;
                defender = gladiPlayer;
            }

            
            while(attacker.Stamina>0 && defender.Stamina>0)
            {
                Random dice = new Random();
                schaden = (attacker.Attack  * dice.Next(1,6)) - (defender.Defense * dice.Next(1, 6));
                if(schaden <= 0)
                {
                    schaden = schaden / -5;
                }
                defender.Stamina -= schaden;
   
                schaden = (defender.Attack * dice.Next(1,6)) - (attacker.Defense * dice.Next(1, 6));
                if (schaden <= 0)
                {
                    schaden = schaden / -5;
                }
                attacker.Stamina -= schaden;
            }
            
            GladiPlayer.Fights += 1;
            if(attacker.Stamina<=0 && attacker.Name == gladiPlayer.Name)
            { 
                GladiPlayer.Xp += 10; 
                ResultTxt.Background = Brushes.Red;
                ResultTxt.Foreground = Brushes.White;
                ResultTxt.Text = "Lost";
            }
            else
            {
                GladiPlayer.Xp += 100;
                ResultTxt.Background = Brushes.Green;
                ResultTxt.Foreground = Brushes.White;
                ResultTxt.Text = "Won";
                GladiPlayer.Wins += 1;
            }

            GladiPlayer.Stamina = stamina_save;
        }

        private void OnClickStart(object sender, RoutedEventArgs e)
        {
            Fighting(GladiPlayer, opponent);
        }

        private void EndBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Menu(GladiPlayer));
        }
    }
}
