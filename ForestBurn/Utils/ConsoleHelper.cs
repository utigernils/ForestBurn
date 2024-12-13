using System;

namespace ForestFireSimulation.Utils
{
    public static class ConsoleHelper
    {
        public static void SetCursorPosition(int left, int top)
        {
            try
            {
                Console.SetCursorPosition(left, top);
            }
            catch (ArgumentOutOfRangeException)
            {
                // Ignore if console window is too small
            }
        }
    }
}