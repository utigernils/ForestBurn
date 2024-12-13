namespace ForestFireSimulation.Entities
{
    public abstract class Cell
    {
        public int X { get; }
        public int Y { get; }

        protected Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public abstract void Display();
    }
}