using System;
using System.Collections.Generic;
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
namespace gladiaddi
{
    /// <summary>
    /// Interaktionslogik für Page3.xaml
    /// </summary>
    partial class Menu : Page
    {
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
            CoinTxt.Text = gladiator.Coins.ToString();
            string bitmapPath = @"C:\Users\tanzm\source\repos\gladiaddi\Images\";
            BitmapImage bitmapImage = new BitmapImage(new Uri(bitmapPath + gladiator.ImgUrl, UriKind.Absolute));
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
    }
}
