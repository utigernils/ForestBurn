using System;
using ForestFireSimulation.Entities;

namespace ForestFireSimulation.Utils
{
    public class RegrowthManager
    {
        private readonly Random _random = new Random();
        private const int RegrowthChancePercent = 5;
        
        public void UpdateRegrowth(Tree tree)
        {
            if (tree.State == TreeState.Burned && _random.Next(100) < RegrowthChancePercent)
            {
                tree.Regrow();
            }
        }
    }
}