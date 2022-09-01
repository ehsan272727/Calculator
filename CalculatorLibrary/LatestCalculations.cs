public class LatestCalculations
{
    private Dictionary<string, double> Calculations = new Dictionary<string, double>();
    int number = 0;

    public void addCal(string operation, double result)
    {
        number++;
        Calculations.Add(operation, result);
    }

    public void viewList()
    {
        foreach (var op in Calculations)
        {
            Console.WriteLine($" {number} ::: {op.Key} = {op.Value}");
        }
        Console.WriteLine("\n");
    }

    public void deleteList() => Calculations.Clear(); 

    public double getResult(int number) =>
        Calculations.ElementAt(number - 1).Value;
}
