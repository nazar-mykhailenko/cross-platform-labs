namespace LabsLib.Lab2
{
    public class OlympiadScheduler
    {
        public static int CountValidWays(InputData inputData, Validator validator)
        {
            int validWays = 0;
            int currentValidCount = 0;

            for (int i = 1; i <= inputData.N; i++)
            {
                if (validator.IsValidDay(i))
                {
                    currentValidCount++;
                }
                else
                {
                    currentValidCount = 0;
                }

                if (currentValidCount == inputData.K)
                {
                    validWays++;
                    currentValidCount--;
                }
            }

            return validWays;
        }
    }
}