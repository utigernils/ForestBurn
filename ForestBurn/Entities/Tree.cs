using System;

namespace ForestFireSimulation.Entities
{
    public class Tree : Cell
    {
        public TreeState State { get; private set; }
        public bool DisplayMode { get; }

        private int BurningTurns { get; set; }
        private const int MaxBurningTurns = 3;

        public Tree(int x, int y, bool displayMode) : base(x, y)
        {
            State = TreeState.Alive;
            BurningTurns = 0;
            DisplayMode = displayMode;
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
            if (DisplayMode)
            {
                switch (State)
                {
                    case TreeState.Alive:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\u259a\u259a");
                        break;
                    case TreeState.Burning:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\u2593\u2593");
                        break;
                    case TreeState.Burned:
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("\u2591\u2591");
                        break;
                }
                Console.ResetColor();
            }
            else
            {
                switch (State)
                {
                    case TreeState.Alive:
                        Console.Write("\ud83c\udf32");
                        break;
                    case TreeState.Burning:
                        Console.Write("\ud83d\udd25");
                        break;
                    case TreeState.Burned:
                        Console.Write("  ");
                        break;
                }
            }

        }
    }
}