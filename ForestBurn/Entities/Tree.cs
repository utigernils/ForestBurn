using System;

namespace ForestFireSimulation.Entities
{
    public class Tree
    {
        public int X { get; }
        public int Y { get; }
        public TreeState State { get; private set; }
        
        private int BurningTurns { get; set; }
        private const int MaxBurningTurns = 3;

        public Tree(int x, int y)
        {
            X = x;
            Y = y;
            State = TreeState.Alive;
            BurningTurns = 0;
        }

        public void Ignite()
        {
            if (State == TreeState.Alive)
            {
                State = TreeState.Burning;
                BurningTurns = 0;
            }
        }

        public void Regrow()
        {
            if (State == TreeState.Burned)
            {
                State = TreeState.Alive;
                BurningTurns = 0;
            }
        }

        public void Update()
        {
            if (State == TreeState.Burning)
            {
                BurningTurns++;
                if (BurningTurns >= MaxBurningTurns)
                {
                    State = TreeState.Burned;
                }
            }
        }

        public void Display()
        {
            switch (State)
            {
                case TreeState.Alive:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("♣");
                    break;
                case TreeState.Burning:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("♨");
                    break;
                case TreeState.Burned:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("░");
                    break;
            }
            Console.ResetColor();
        }
    }
}