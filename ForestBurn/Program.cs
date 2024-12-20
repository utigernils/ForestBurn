using ForestFireSimulation.Core;
using ForestFireSimulation.Utils;

namespace ForestFireSimulation
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new SimulationConfig(
                width: 40,
                height: 10,
                updateDelay: 500,
                burningChance: 3,
                regrowChance: 20,
                autoIgnite: true,
                waitBeforeNewFire: 3000
            );
            
            var simulation = new Simulation(config);
            simulation.Start();
        }
    }
}