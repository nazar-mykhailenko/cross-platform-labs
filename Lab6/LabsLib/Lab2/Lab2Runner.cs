namespace LabsLib.Lab2;

public class Lab2Runner
{
    public static string Run(string input)
    {
        try
            {
                InputData inputData = InputData.Parse(input);

                Validator validator = new(inputData);

                int validWays = OlympiadScheduler.CountValidWays(inputData, validator);

                return validWays.ToString();
            }
            catch (FileNotFoundException)
            {
                return "File not found";
            }
            catch(IndexOutOfRangeException)
            {
                return "Invalid input format";
            }
            catch(IOException)
            {
                return "An error occurred while reading the file";
            }
            catch (Exception e)
            {
                return e.Message;
            }
    }
}