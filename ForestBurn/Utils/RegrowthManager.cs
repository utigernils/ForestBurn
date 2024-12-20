using System;
using ForestFireSimulation.Entities;

namespace ForestFireSimulation.Utils
{
    public class RegrowthManager
    {
        private readonly Random _random = new Random();
        private readonly int regrowChance;
      

        public RegrowthManager(int regrowChance)
        {
            this.regrowChance = regrowChance;
        }
        
        public void UpdateRegrowth(Tree tree)
        {
            if (tree.State == TreeState.Burned && _random.Next(this.regrowChance) == 0)
            {
                tree.Regrow();
            }
        }
    }
}