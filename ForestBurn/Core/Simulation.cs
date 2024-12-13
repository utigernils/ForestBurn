using System;
using System.Threading;
using ForestFireSimulation.Utils;

namespace ForestFireSimulation.Core
{
    public class Simulation
    {
        private readonly Forest _forest;
        private readonly SimulationConfig _config;
        private bool _isRunning;

        public Simulation(SimulationConfig config)
        {
            _config = config;
            _forest = new Forest(config.Width, config.Height);
        }

        public void Start()
        {
            Console.CursorVisible = false;
            _isRunning = true;
            _forest.IgniteRandomTree();

            while (_isRunning)
            {
                _forest.Display();
                _forest.Update();
                
                if (!_forest.HasActiveFire() && _config.AutoIgnite)
                {
                    Thread.Sleep(_config.WaitBeforeNewFire);
                    _forest.IgniteRandomTree();
                }

                Thread.Sleep(_config.UpdateDelay);

                if (Console.KeyAvailable)
                {
                    HandleUserInput();
                }
            }

            Console.CursorVisible = true;
        }

        private void HandleUserInput()
        {
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.Spacebar:
                    _forest.IgniteRandomTree();
                    break;
                case ConsoleKey.Escape:
                    _isRunning = false;
                    break;
            }
        }
    }
}