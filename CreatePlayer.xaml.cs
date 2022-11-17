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

namespace WpfGame
{
    /// <summary>
    /// Логика взаимодействия для CreatePlayer.xaml
    /// </summary>
    public partial class CreatePlayer : Page
    {
        public CreatePlayer()
        {
            InitializeComponent();

            Resources.Add("Люди", IPlayer.race.People);
            Resources.Add("Эльфы", IPlayer.race.Elves);
            Resources.Add("Демоны", IPlayer.race.Demons);
        }

        public void Return_Click(object sender, RoutedEventArgs e)
        {
            var players = (List<IPlayer>)App.Current.Resources["Players"];

            players.Add(new Player(nick1.Text,
                (IPlayer.race)Resources[((TextBlock)((ComboBoxItem)race1.SelectedItem).Content).Text]));
            players.Add(new Player(nick2.Text,
                (IPlayer.race)Resources[((TextBlock)((ComboBoxItem)race2.SelectedItem).Content).Text]));

            NavigationService.GoBack();
        }
    }
}
