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
    /// Логика взаимодействия для Battle.xaml
    /// </summary>
    public partial class Battle : Page
    {
        public Battle()
        {
            InitializeComponent();

            player1 = ((List<IPlayer>)App.Current.Resources["Players"])[0];
            player2 = ((List<IPlayer>)App.Current.Resources["Players"])[1];

            army1 = player1.Army;
            army2 = player2.Army;

            field = new Field(gridField, 7, 10);
            field.FillField(army1, army2);
            FillOrder();
        }

        Field field;

        IPlayer player1;
        List<Unit> army1;
        IPlayer player2;
        List<Unit> army2;

        Unit currentUnit;
        List<Unit> order;

        void KillUnit(Unit unit)
        {
            OrderOfUnits.Children.RemoveAt(order.IndexOf(unit));
            field.RemoveUnit(unit);
        }

        void NextTurn()
        {
            NextUnit();
            //gridField.Children[0];

            
        }

        void IlluminateCells(Unit unit, bool[,] cellsCanGoTo)
        {
            for (int row = 0; row < (unit.Row + unit.speed); row++)
                for (int col = 0; col < (unit.Column + unit.speed); col++)
                    if (cellsCanGoTo[row, col])
                    {
                        Border br = new() { Background = (SolidColorBrush)Resources["greenCell"] };

                        Grid.SetRow(br, row);
                        Grid.SetColumn(br, col);
                        gridField.Children.Add(br);
                    }
        }

        void NextUnit()
        {         
            OrderOfUnits.Children.RemoveAt(0);
            ((Image)OrderOfUnits.Children[0]).Margin = new Thickness(1);
            // Bad, need to powerful refactor
            currentUnit.icon.Margin = new Thickness(12);
            OrderOfUnits.Children.Add(currentUnit.icon);          
            
            order.RemoveAt(0);
            order.Add(currentUnit);
            currentUnit = order[0];
        }

        void FillOrder()
        {
            Random random = new Random();
            order = army1.Concat(army2).OrderBy(_ => random.Next()).ToList();
            currentUnit = order[0];

            foreach (Unit unit in order)
                OrderOfUnits.Children.Add(unit.icon);

            ((Image)OrderOfUnits.Children[0]).Margin = new Thickness(1);
        }

        public void AddRow_Click(object sender, RoutedEventArgs args)
        {
            field.Rows++;
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NextUnit();
        }
    }
}
