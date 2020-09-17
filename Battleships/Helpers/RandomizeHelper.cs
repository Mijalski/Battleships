using System;
using System.Threading;

namespace Battleships.Helpers
{
    public class RandomizeHelper
    {
        private static int _seed;
        private static readonly ThreadLocal<Random> ThreadLocal = new ThreadLocal<Random>
            (() => new Random(Interlocked.Increment(ref _seed)));

        static RandomizeHelper()
        {
            _seed = Environment.TickCount;
        }

        private static Random Instance => ThreadLocal.Value;

        public static int GetRandomInt(int maxValue, int minValue = 0)
        {
            return Instance.Next(minValue, maxValue);
        }

        public static bool GetRandomBool()
        {
            return GetRandomInt(1) == 0;
        }
    }
}