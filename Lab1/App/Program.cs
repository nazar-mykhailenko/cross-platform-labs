using App;

const string FileName = "./INPUT.TXT";
const string OutputFileName = "./OUTPUT.TXT";

try
{
    string input = File.ReadAllText(FileName);
    ulong n = ulong.Parse(input);
    ulong result = DominoHelper.CountDots(n);
    File.WriteAllText(OutputFileName, result.ToString());
}
catch (IOException)
{
    Console.WriteLine("Error when reading file!");
}
catch (FormatException)
{
    Console.WriteLine("Error when parsing input!");
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}