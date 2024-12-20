namespace ForestFireSimulation.Utils
{
    public class SimulationConfig
    {
        public int Width { get; }
        public int Height { get; }
        public int UpdateDelay { get; }
        public int BurningChance { get; }
        public int RegrowChance { get; }
        public bool AutoIgnite { get; }
        public int WaitBeforeNewFire { get; }
        
        public bool DisplayMode { get; }

        public SimulationConfig(
            int width = 20,
            int height = 20,
            int updateDelay = 200,
            int burningChance = 4,
            int regrowChance = 4,
            bool autoIgnite = true,
            int waitBeforeNewFire = 2000,
            bool legacyDisplayMode = false)
        {
            Width = width;
            Height = height;
            UpdateDelay = updateDelay;
            BurningChance = burningChance;
            RegrowChance = regrowChance;
            AutoIgnite = autoIgnite;
            WaitBeforeNewFire = waitBeforeNewFire;
            DisplayMode = legacyDisplayMode;
        }
    }
}