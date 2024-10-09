namespace App
{
    public static class DominoHelper
    {
        public static ulong CountDots(ulong n)
        {
            if (n > 10000)
            {
                throw new ArgumentException("n must be less than or equal to 10000");
            }

            if (n == 0)
            {
                return 1;
            }

            if (n == 1)
            {
                return 3;
            }

            return Combinatorics.CombinationsWithRepetition(n + 1);
        }
    }
}