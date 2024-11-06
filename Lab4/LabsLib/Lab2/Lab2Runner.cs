namespace LabsLib.Lab2;

public class Lab2Runner
{
    public static void Run(string inputFile, string outputFile)
    {
        try
            {
                InputData inputData = InputData.ReadFromFile(inputFile, new FileReader());

                Validator validator = new(inputData);

                int validWays = OlympiadScheduler.CountValidWays(inputData, validator);

                File.WriteAllText(outputFile, validWays.ToString());
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
            catch(IndexOutOfRangeException)
            {
                Console.WriteLine("Invalid input format");
            }
            catch(IOException)
            {
                Console.WriteLine("An error occurred while reading the file");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
    }
}