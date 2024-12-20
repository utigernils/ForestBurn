using ForestFireSimulation.Core;
using ForestFireSimulation.Utils;

namespace ForestFireSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new SimulationConfig(
                width: 20,
                height: 10,
                updateDelay: 50,
                burningChance: 2,
                regrowChance: 20,
                autoIgnite: true,
                waitBeforeNewFire: 3000,
                legacyDisplayMode: false
            );
            
            var simulation = new Simulation(config);
            simulation.Start();
        }
    }
}