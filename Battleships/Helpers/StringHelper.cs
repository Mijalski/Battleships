namespace Battleships.Helpers
{
    public static class StringHelper
    {
        private const string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string GetColumnName(this int number)
        {
            var value = "";

            if (number >= Letters.Length)
                value += Letters[number / Letters.Length - 1];

            value += Letters[number % Letters.Length];

            return value;
        }
        public static string GetRowName(this int number)
        {
            return (number + 1).ToString();
        }
    }
}