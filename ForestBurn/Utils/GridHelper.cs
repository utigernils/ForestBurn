using System.Collections.Generic;

namespace ForestFireSimulation.Utils
{
    public static class GridHelper
    {
        public static IEnumerable<(int x, int y)> GetNeighborCoordinates(int x, int y, int width, int height)
        {
            var directions = new[] { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };

            foreach (var (dx, dy) in directions)
            {
                int newX = x + dx;
                int newY = y + dy;

                if (IsValidPosition(newX, newY, width, height))
                {
                    yield return (newX, newY);
                }
            }
        }

        private static bool IsValidPosition(int x, int y, int width, int height)
        {
            return x >= 0 && x < width && y >= 0 && y < height;
        }
    }
}