using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfGame
{
    abstract class Unit : DependencyObject
    {
        internal enum Type
        {
            Red,
            Orange,
            Yellow
        }

        public Unit(string type)
        {
            texture = new Image
            {
                Margin = new Thickness(5),
                Source = new BitmapImage(new Uri($"/images/{type}.png", UriKind.Relative))
            };

            icon = new Image
            {
                Margin = new Thickness(12),
                Source = new BitmapImage(new Uri($"/images/{type}Icon.png", UriKind.Relative))
            }; // пока не найдём норм иконки будет копия текстуры

            Armor = 1;
            switch (type)
            {
                case "Red":
                    this.type = Type.Red;
                    MinDamage = 3;
                    MaxDamage = 3;
                    Health = MaxHealth = 7;
                    speed = 4;
                    break;

                case "Orange":
                    this.type = Type.Orange;
                    MinDamage = 4;
                    MaxDamage = 4;
                    Health = MaxHealth = 6;
                    speed = 3;
                    break;

                case "Yellow":
                    this.type = Type.Yellow;
                    MinDamage = 5;
                    MaxDamage = 5;
                    Health = MaxHealth = 5;
                    speed = 2;
                    break;

                default:
                    break;
            }
        }

        #region DP   
        public int Health
        {
            get { return (int)GetValue(HealthProperty); }
            set { SetValue(HealthProperty, value); }
        }
        public static readonly DependencyProperty HealthProperty =
            DependencyProperty.Register("Health", typeof(int), typeof(Unit), new PropertyMetadata(0));


        public int MinDamage
        {
            get { return (int)GetValue(MinDamageProperty); }
            set { SetValue(MinDamageProperty, value); }
        }
        public static readonly DependencyProperty MinDamageProperty =
            DependencyProperty.Register("MinDamage", typeof(int), typeof(Unit), new PropertyMetadata(0));

        public int MaxDamage
        {
            get { return (int)GetValue(MaxDamageProperty); }
            set { SetValue(MaxDamageProperty, value); }
        }
        public static readonly DependencyProperty MaxDamageProperty =
            DependencyProperty.Register("MaxDamage", typeof(int), typeof(Unit), new PropertyMetadata(0));

        public int Armor
        {
            get { return (int)GetValue(ArmorProperty); }
            set { SetValue(ArmorProperty, value); }
        }
        public static readonly DependencyProperty ArmorProperty =
            DependencyProperty.Register("Armor", typeof(int), typeof(Unit), new PropertyMetadata(0));
        #endregion

        public int MaxHealth { get; }

        public readonly int speed;

        public readonly bool friendly;

        readonly Type type;

        public Image texture { get; private set; }

        public Image icon { get; private set; }

        public int Row { get; set; }

        public int Column { get; set; }

        readonly ToolTip tip;

        void Meth()
        {
            
        }
    }

    class RangeUnit : Unit
    {
        public RangeUnit(string type) : base(type) { }
    }

    class MeleeUnit : Unit
    {
        public MeleeUnit(string type) : base(type) { }
    }
}
