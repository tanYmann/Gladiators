﻿using System;
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
    /// Interaktionslogik für Page2.xaml
    /// </summary>
    public partial class Start : Page
    {
       
        public Start()
        {
            InitializeComponent();
            
        }

        private void OnClickStart(object sender, RoutedEventArgs e)
        {
            
            this.NavigationService.Navigate(new Uri("NewGladi.xaml", UriKind.Relative));
        }
    }
}
