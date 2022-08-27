using Newtonsoft.Json;
public static class usageCount
{
    public static void readUseCounts()
    {
        StreamReader str = new StreamReader("calculatorlog.json");
        JsonTextReader reader = new JsonTextReader(str);
    }

    private void writeCounts()
    {

    }
}
