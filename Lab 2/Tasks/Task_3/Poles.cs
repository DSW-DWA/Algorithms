using System;
using System.Collections.Generic;

namespace Lab2
{
    public class Poles
    {
        public Stack<Disc> Pole { get; set; }
        public int Position { get; }
        public Poles(int num_disc, int position)
        {
            Pole = new Stack<Disc>();
            
            for (int i = num_disc; i > 0 ; i--)
            {
              Pole.Push(new Disc($"Disc with weight {i}"));
            }

            Position = position;
        }
    }
}