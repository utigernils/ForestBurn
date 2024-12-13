using System;

namespace ForestFireSimulation.Entities
{
    public class EmptyCell : Cell
    {
        public EmptyCell(int x, int y) : base(x, y) { }

        public override void Display()
        {
            Console.Write(" ");
        }
    }
}