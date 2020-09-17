using System;

namespace Battleships.Helpers
{
    public static class StringHelper
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string GetColumnName(this int index)
        {
            if (index < 0)
                throw new ArgumentException("Column index must be grater than 0");

            var value = "";

            if (index >= Letters.Length)
                value += Letters[index / Letters.Length - 1];

            value += Letters[index % Letters.Length];

            return value;
        }

        public static string GetRowName(this int index)
        {
            if(index < 0)
                throw new ArgumentException("Row index must be grater than 0");

            return (index + 1).ToString();
        }
    }
}