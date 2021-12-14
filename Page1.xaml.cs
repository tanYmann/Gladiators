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
    /// Interaktionslogik für Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1(Gladiator gladiator)
        {
            InitializeComponent();
            KmpfTxt.Text = gladiator.Fights.ToString();
            SiegTxt.Text = gladiator.Wins.ToString();
            PkteTxt.Text = (gladiator.Xp / gladiator.Fights).ToString();
            playerName.Text = gladiator.Name;
            string bitmapPath = @"C:\Users\tanzm\source\repos\gladiaddi\";
            BitmapImage bitmapImage = new BitmapImage(new Uri(bitmapPath+gladiator.ImgUrl, UriKind.Absolute));
            playerImage.Source = bitmapImage;
            
        }

      
    }
}
