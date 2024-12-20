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
                updateDelay: 20,
                burningChance: 4,
                autoIgnite: true,
                waitBeforeNewFire: 2000
            );
            
            var simulation = new Simulation(config);
            simulation.Start();
        }
    }
}