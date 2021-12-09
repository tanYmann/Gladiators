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



      
            InitializeComponent(); 
            setGladiator();
            listView.ItemsSource = gladiList;

          

        }

        public void setGladiator()
        {
            Gladi = gladiatorPlayer;
            
            
            

        }


    }
}
