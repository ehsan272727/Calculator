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
        int num = 1;
        foreach (var op in Calculations)
        {
            Console.WriteLine($" {num} ::: {op.Key} = {op.Value}");
            num++;
        }
        Console.WriteLine("\n");

    }

    public void deleteList() => Calculations.Clear(); 

    public double getResult(int number) =>
        Calculations.ElementAt(number - 1).Value;

    public int getLength() => Calculations.Count;
}
