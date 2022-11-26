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

                    }
        }

        void NextUnit()
        {         

        }

        void FillOrder()
        {

        }
    }
}
