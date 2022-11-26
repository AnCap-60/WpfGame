using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfGame
{
    class BattleViewModel : DependencyObject
    {
        public BattleViewModel()
        {
            var players = (List<IPlayer>)App.Current.Resources["Players"];
            Player1 = players[0];
            Player2 = players[1];

            AllUnits = Player1.Army.Concat(Player2.Army).ToList();

            field = new Field(7, 7);
            field.FillField(Player1.Army, Player2.Army);

            FillOrder();
        }

        public IPlayer Player1 { get; private set; }

        public IPlayer Player2 { get; private set; }

        Field field;

        public List<Unit> AllUnits { get; private set; }

        public ObservableQueue<Unit> Order
        {
            get { return (ObservableQueue<Unit>)GetValue(OrderProperty); }
            set { SetValue(OrderProperty, value); }
        }
        public static readonly DependencyProperty OrderProperty =
            DependencyProperty.Register("Order", typeof(ObservableQueue<Unit>), typeof(BattleViewModel), new PropertyMetadata(null));

        void FillOrder()
        {
            Order = new();
            Random random = new();
            foreach (Unit u in AllUnits.OrderBy(_ => random.Next()))
                Order.Enqueue(u);

            CurrentUnit = Order.Dequeue();
        }
       
        public Unit CurrentUnit
        {
            get { return (Unit)GetValue(CurrentUnitProperty); }
            set { SetValue(CurrentUnitProperty, value); }
        }
        public static readonly DependencyProperty CurrentUnitProperty =
            DependencyProperty.Register("CurrentUnit", typeof(Unit), typeof(BattleViewModel), new PropertyMetadata(null));

        void NextUnit()
        {
            Order.Enqueue(CurrentUnit);
            CurrentUnit = Order.Dequeue();
        }

        private RelayCommand ovcaCommand;
        public RelayCommand OvcaCommand => ovcaCommand ??= new RelayCommand(obj =>
        {
            NextUnit();
        });
    }
}
