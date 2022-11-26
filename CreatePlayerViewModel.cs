using System;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Data;
using System.Globalization;

namespace WpfGame
{
    class CreatePlayerViewModel : DependencyObject
    {
        public CreatePlayerViewModel()
        {
            Races = new IPlayer.race[] { IPlayer.race.People, IPlayer.race.Elves, IPlayer.race.Demons };
        }

        public IPlayer.race[] Races { get; private set; }

        public IPlayer.race SelectedRace1
        {
            get { return (IPlayer.race)GetValue(SelectedRace1Property); }
            set { SetValue(SelectedRace1Property, value); }
        }
        public static readonly DependencyProperty SelectedRace1Property =
            DependencyProperty.Register("SelectedRace1", typeof(IPlayer.race), typeof(CreatePlayerViewModel), new PropertyMetadata(IPlayer.race.People));

        public IPlayer.race SelectedRace2
        {
            get { return (IPlayer.race)GetValue(SelectedRace2Property); }
            set { SetValue(SelectedRace2Property, value); }
        }
        public static readonly DependencyProperty SelectedRace2Property =
            DependencyProperty.Register("SelectedRace2", typeof(IPlayer.race), typeof(CreatePlayerViewModel), new PropertyMetadata(IPlayer.race.Demons));



        public string SelectedType1
        {
            get { return (string)GetValue(SelectedType1Property); }
            set { SetValue(SelectedType1Property, value); }
        }
        public static readonly DependencyProperty SelectedType1Property =
            DependencyProperty.Register("SelectedType1", typeof(string), typeof(CreatePlayerViewModel), new PropertyMetadata("Игрок"));

        public string SelectedType2
        {
            get { return (string)GetValue(SelectedType2Property); }
            set { SetValue(SelectedType2Property, value); }
        }
        public static readonly DependencyProperty SelectedType2Property =
            DependencyProperty.Register("SelectedType2", typeof(string), typeof(CreatePlayerViewModel), new PropertyMetadata("ИИ"));



        public string Nick1
        {
            get { return (string)GetValue(Nick1Property); }
            set { SetValue(Nick1Property, value); }
        }
        public static readonly DependencyProperty Nick1Property =
            DependencyProperty.Register("Nick1", typeof(string), typeof(CreatePlayerViewModel), new PropertyMetadata("Player 1"));

        public string Nick2
        {
            get { return (string)GetValue(Nick2Property); }
            set { SetValue(Nick2Property, value); }
        }
        public static readonly DependencyProperty Nick2Property =
            DependencyProperty.Register("Nick2", typeof(string), typeof(CreatePlayerViewModel), new PropertyMetadata("Player 2"));


        private RelayCommand returnCommand;
        public RelayCommand ReturnCommand => returnCommand ??= new RelayCommand(obj =>
            {
                var players = (List<IPlayer>)App.Current.Resources["Players"];
                //TODO Choice between Player and Bot (IPlayer)
                players.Add(new Player(Nick1, SelectedRace1));
                players.Add(new Player(Nick2, SelectedRace2));

                (App.Current.MainWindow as MainWindow).NavigationService.GoBack();
            });


        private RelayCommand checkCommand1;
        public RelayCommand CheckCommand1 => checkCommand1 ??= new RelayCommand(obj =>
            {
                SelectedType1 = (string)obj;
            });
        private RelayCommand checkCommand2;
        public RelayCommand CheckCommand2 => checkCommand2 ??= new RelayCommand(obj =>
        {
            SelectedType2 = (string)obj;
        });
    }

    class RaceToTextConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            IPlayer.race race = (IPlayer.race)value;
            switch (race)
            {
                case IPlayer.race.People:
                    return "Люди";
                case IPlayer.race.Elves:
                    return "Эльфы";
                case IPlayer.race.Demons:
                    return "Демоны";
                default:
                    return "Error";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "";
        }
    }
}
