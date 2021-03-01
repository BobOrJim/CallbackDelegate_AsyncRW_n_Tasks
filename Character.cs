using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates_n_Tasks
{
    internal class Character
    {
        private Random rand = new Random();
        public string Name { get; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Luck { get; set; }

        public Character(string name)
        {
            Name = name;
            Health = rand.Next(1, 100);
            Strength = rand.Next(1, 100);
            Luck = rand.Next(1, 100);
        }
    }
}
