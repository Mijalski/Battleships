using System;
using System.Threading;

namespace Battleships.Helpers
{
    public class RandomizeHelper
    {

        public static int GetRandomInt(int maxValue, int minValue = 0)
        {
            return new Random().Next(minValue, maxValue);
        }

        public static bool GetRandomBool()
        {
            return new Random().NextDouble() >= 0.5;
        }
    }
}