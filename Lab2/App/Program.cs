using System;
using System.IO;

namespace App
{
    class Program
    {
        static void Main()
        {
            try
            {
                InputData inputData = InputData.ReadFromFile("INPUT.TXT", new FileReader());

                Validator validator = new(inputData);

                int validWays = OlympiadScheduler.CountValidWays(inputData, validator);

                File.WriteAllText("OUTPUT.TXT", validWays.ToString());
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
}