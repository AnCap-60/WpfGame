using System.Collections.Generic;

namespace WpfGame
{
    internal interface IPlayer
    {
        string Name { get; }

        void Turn();

        List<Unit> Army { get; set; }

        internal enum race
        {
            People,
            Elves,
            Demons
        }

        race Race { get; }

        string Info { get; }
    }
}
