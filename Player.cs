using System;
using System.Collections.Generic;

namespace WpfGame
{
    internal class Player : IPlayer
    {
        public Player(string name, IPlayer.race race)
        {
            Name = name;

            Army = new() { new MeleeUnit("Red"), new MeleeUnit("Orange"), new RangeUnit("Yellow") };
            Race = race;
        }

        public string Name { get; private set; }

        public List<Unit> Army { get; set; }

        public IPlayer.race Race { get; private set; }

        public string Info => ToString();

        public void Turn()
        {
            
        }

        public override string ToString()
        {
            return $"{Name}\n{Race}\n{Army.Count} units";
        }
    }
}
