namespace ForestFireSimulation.Utils
{
    public class SimulationConfig
    {
        public int Width { get; }
        public int Height { get; }
        public int UpdateDelay { get; }
        public bool AutoIgnite { get; }
        public int WaitBeforeNewFire { get; }

        public SimulationConfig(
            int width = 20,
            int height = 20,
            int updateDelay = 200,
            bool autoIgnite = true,
            int waitBeforeNewFire = 2000)
        {
            Width = width;
            Height = height;
            UpdateDelay = updateDelay;
            AutoIgnite = autoIgnite;
            WaitBeforeNewFire = waitBeforeNewFire;
        }
    }
}