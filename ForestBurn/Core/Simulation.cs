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
            _forest = new Forest(config.Width, config.Height, config.BurningChance, config.RegrowChance);
        }

        public void Start()
        {
            Console.CursorVisible = false;
            _isRunning = true;
            _forest.IgniteRandomTree();

            while (_isRunning)
            {
                Console.Clear();
                _forest.Display();
                _forest.Update();
                
                if (!_forest.HasActiveFire() && _config.AutoIgnite)
                {
                    for (int i = 0; i < _config.WaitBeforeNewFire/_config.UpdateDelay; i++)
                    {
                        _forest.Update();
                        _forest.Display();
                        Thread.Sleep(_config.UpdateDelay);
                    }
                    
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