using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Poles
    {
        private Stack<Disc> _pole;
        public int Position { get; set; }

        public Poles(int num_disc, int position)
        {
            _pole = new Stack<Disc>();
            
            for (int i = num_disc; i > 0 ; i--)
            {
              _pole.Push(new Disc($"Disc with weight {i}"));
            }

            Position = position;
        }
    }
}