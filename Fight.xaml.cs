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
            OpponentStamina1.Text = "Ausdauer : " + opponent.Stamina.ToString();
            OpponentAttack.Text = "Angriff : " + opponent.Attack.ToString();
            OpponentDefense.Text = "Verteidigung : " + opponent.Defense.ToString();

            StaminaPlayerTxt.Text = "Ausdauer : " + gladiator.Stamina.ToString();
            AttackPlayerTxt.Text = "Angriff : " + gladiator.Attack.ToString();
            DefensePlayerTxt.Text = "Verteidigung : " + gladiator.Defense.ToString();
        }
      

        public void SetOpponent(Gladiator gladiPlayer, Gladiator gladiOpponent)
        {
            
            Random rnd = new Random();
            gladiOpponent.Stamina = rnd.Next(gladiPlayer.Stamina/2,gladiPlayer.Stamina*2);
            gladiOpponent.Attack = rnd.Next(gladiPlayer.Attack/2,gladiPlayer.Attack*2);
            gladiOpponent.Defense = rnd.Next(gladiPlayer.Defense / 2, gladiPlayer.Defense * 2);
            
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
                CountdownEvent countdown = new CountdownEvent(100);
                Random dice = new Random();
                schaden = (attacker.Attack  * dice.Next(1,6)) - (defender.Defense * dice.Next(1, 6));
                if(schaden <= 0)
                {
                    schaden = schaden / -5;
                }
                kampfLog.Text += "Treffer! " + schaden.ToString() + " Schaden.";
                defender.Stamina -= schaden;
                StaminaPlayerTxt.Text = defender.Stamina.ToString();
               

                schaden = (defender.Attack * dice.Next(1,6)) - (attacker.Defense * dice.Next(1, 6));
                if (schaden <= 0)
                {
                    schaden = schaden / -5;
                }
                attacker.Stamina -= schaden;
                kampfLog.Text += "Treffer! " + schaden.ToString() + " Schaden.";
                StaminaPlayerTxt.Text = attacker.Stamina.ToString();
                

            }
            
            GladiPlayer.Fights += 1;
            if(attacker.Stamina<=0 && attacker.Name == gladiPlayer.Name)
            { 
                GladiPlayer.Xp += 10;
                string bitmapPath = @"C:\Users\tanzm\source\repos\gladiaddi\images\";
                BitmapImage bitmapImage = new BitmapImage(new Uri(bitmapPath + "Lost.png", UriKind.Absolute));
                ResultImg.Source = bitmapImage;
             
            }
            else
            {
                GladiPlayer.Xp += 100;
                string bitmapPath = @"C:\Users\tanzm\source\repos\gladiaddi\images\";
                BitmapImage bitmapImage = new BitmapImage(new Uri(bitmapPath + "won.png", UriKind.Absolute));
                ResultImg.Source = bitmapImage;
                GladiPlayer.Wins += 1;
                GladiPlayer.Coins += 1;

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
