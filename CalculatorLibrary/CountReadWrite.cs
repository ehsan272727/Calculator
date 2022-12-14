using Newtonsoft.Json;
public static class usageCount
{
    public static int readUseCounts()
    {
        int count = 0; 
        if (File.Exists("usagecount.json"))
        {
            using (StreamReader str = new StreamReader("usagecount.json"))
            {
                JsonTextReader reader = new JsonTextReader(str);

                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.Integer)
                    {
                        count = int.Parse(reader.Value.ToString());
                    }
                }
            }
        }
        return count;
    }

    public static void writeCounts(int count)
    {
        StreamWriter logFile = File.CreateText("usagecount.json");
        logFile.AutoFlush = true;
        JsonWriter writer = new JsonTextWriter(logFile);
        writer.Formatting = Formatting.Indented;
        writer.WriteStartObject();
        writer.WritePropertyName("Count");
        writer.WriteValue(count);
        writer.WriteEndObject();
        writer.Close();
    }
}
