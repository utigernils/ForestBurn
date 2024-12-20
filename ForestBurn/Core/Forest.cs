using System;
using System.Collections.Generic;
using System.Linq;
using ForestFireSimulation.Entities;
using ForestFireSimulation.Utils;

namespace ForestFireSimulation.Core
{
    public class Forest
    {
        private readonly List<Tree> _trees; 
        private readonly int _width;
        private readonly int _height;
        private readonly Random _random;
        private readonly int _burningChance;
        private readonly RegrowthManager _regrowthManager; 
        private readonly bool _displayMode;

        public Forest(int width, int height, int burningChance, int regrowthChance, bool displayMode)
        {
            _width = width;
            _height = height;
            _random = new Random();
            _burningChance = burningChance;
            _trees = new List<Tree>();
            _regrowthManager = new RegrowthManager(regrowthChance);
            _displayMode = displayMode;

            InitializeForest();
        }

        private void InitializeForest()
        {
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    _trees.Add(new Tree(x, y, _displayMode));
                }
            }
        }

        public void Update()
        {
            var newBurningTrees = new List<Tree>();
            
            var random = new Random();

            foreach (var tree in _trees)
            {
                if (tree.State == TreeState.Burning)
                {
                    foreach (var neighbor in GetNeighbors(tree))
                    {
                        if (neighbor.State == TreeState.Alive)
                        {
                            if (random.Next(_burningChance) == 0)
                            {
                                newBurningTrees.Add(neighbor);
                            }
                        }
                    }
                    tree.Update();
                }
            }

            
            foreach (var tree in newBurningTrees)
            {
                tree.Ignite();
            }
            
            foreach (var tree in _trees.Where(t => t.State == TreeState.Burned))
            {
                _regrowthManager.UpdateRegrowth(tree);
            }
        }

        public void Display()
        {
            ConsoleHelper.SetCursorPosition(0, 0);
            
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    var tree = _trees.First(t => t.X == x && t.Y == y);
                    tree.Display();
                }
                Console.WriteLine();
            }

            DisplayStatistics();
        }

        private void DisplayStatistics()
        {
            var stats = new Dictionary<TreeState, int>
            {
                { TreeState.Alive, _trees.Count(t => t.State == TreeState.Alive) },
                { TreeState.Burning, _trees.Count(t => t.State == TreeState.Burning) },
                { TreeState.Burned, _trees.Count(t => t.State == TreeState.Burned) }
            };

            Console.WriteLine("\nForest Statistics:");
            Console.WriteLine($"Alive Trees: {stats[TreeState.Alive]}");
            Console.WriteLine($"Burning Trees: {stats[TreeState.Burning]}");
            Console.WriteLine($"Burned Trees: {stats[TreeState.Burned]}");
        }

        public void IgniteRandomTree()
        {
            var aliveTrees = _trees.Where(t => t.State == TreeState.Alive).ToList();
            if (aliveTrees.Any())
            {
                var randomTree = aliveTrees[_random.Next(aliveTrees.Count)];
                randomTree.Ignite();
            }
        }

        public bool HasActiveFire()
        {
            return _trees.Any(t => t.State == TreeState.Burning);
        }

        private IEnumerable<Tree> GetNeighbors(Tree tree)
        {
            return GridHelper.GetNeighborCoordinates(tree.X, tree.Y, _width, _height)
                .Select(coord => _trees.First(t => t.X == coord.x && t.Y == coord.y));
        }
    }
}