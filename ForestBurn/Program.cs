using ForestFireSimulation.Core;
using ForestFireSimulation.Utils;

namespace ForestFireSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new SimulationConfig(
                width: 30,
                height: 20,
                updateDelay: 50,
                burningChance: 2,
                regrowChance: 30,
                autoIgnite: true,
                waitBeforeNewFire: 3000,
                legacyDisplayMode: false
            );
            
            var simulation = new Simulation(config);
            simulation.Start();
        }
    }
}