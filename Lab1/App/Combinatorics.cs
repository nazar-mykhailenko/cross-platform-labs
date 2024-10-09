namespace App
{
    public static class Combinatorics
    {
        public static ulong CombinationsWithRepetition(ulong n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            return (n * n * n - n) / 2;
        }
    }
}