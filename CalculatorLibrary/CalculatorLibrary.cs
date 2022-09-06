using System.IO;
using Newtonsoft.Json;

namespace CalculatorProgram
{
    public class Calculator
    {
        JsonWriter writer;
        public  LatestCalculations latestCal;
        public Calculator()
        {
            latestCal = new();
            StreamWriter logFile = File.CreateText("calculatorlog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }
        public double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" if an operation, such as division, could result in an error.
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(num1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(num2);
            writer.WritePropertyName("Operation");

            // Use a switch statement to do the math.
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    writer.WriteValue("Add");
                    latestCal.addCal($"{num1} + {num2}", result);
                    break;
                case "s":
                    result = num1 - num2;
                    writer.WriteValue("Subtract");
                    latestCal.addCal($"{num1} - {num2}", result);
                    break;
                case "m":
                    result = num1 * num2;
                    writer.WriteValue("Multiply");
                    latestCal.addCal($"{num1} X {num2}", result);
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                        writer.WriteValue("Divide");
                        latestCal.addCal($"{num1} / {num2}", result);
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }

        public double DoOperation(double num, string op)
        {
            double result = double.NaN;

            writer.WriteStartObject();
            writer.WritePropertyName("Operand");
            writer.WriteValue(num);
            writer.WritePropertyName("Operation");

            switch (op)
            {
                case "sq":
                    result = Math.Sqrt(num);
                    writer.WriteValue("Square Root");
                    latestCal.addCal($"\u221A {num}", result);
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
            }

            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }
        public void Finish(int count)
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();

            usageCount.writeCounts(count);
        }
    }
}