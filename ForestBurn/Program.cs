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
                updateDelay: 200,
                autoIgnite: true,
                waitBeforeNewFire: 2000
            );
            
            var simulation = new Simulation(config);
            simulation.Start();
        }
    }
}