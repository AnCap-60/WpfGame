using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //pivo

            Application.Current.Resources.Add("Players", new List<IPlayer>(2));
        }

        private void Battle_Click(object sender, RoutedEventArgs e)
        {
            Navigate(new Uri("Battle.xaml", UriKind.Relative));
        }

        private void AddPlayer_Click(object sender, RoutedEventArgs e)
        {
            Navigate(new Uri("CreatePlayer.xaml", UriKind.Relative));
            
            battleButton.IsEnabled = true;
        }
    }
}
