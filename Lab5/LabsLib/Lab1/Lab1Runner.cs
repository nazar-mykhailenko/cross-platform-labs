namespace LabsLib.Lab1;

public class Lab1Runner
{
    public static string Run(string input)
    {
        try
        {
            ulong n = ulong.Parse(input);
            ulong result = DominoHelper.CountDots(n);
            return result.ToString();
        }
        catch (IOException)
        {
            return "Error when reading file!";
        }
        catch (FormatException)
        {
            return "Error when parsing input!";
        }
        catch (Exception e)
        {
            return e.Message;
        }
    }
}
