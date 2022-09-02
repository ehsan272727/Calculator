namespace CalculatorProgram
{
    class Program
    {
        // Setting up variables
        static double resultFromList = double.NaN;
        static int useCount;
        static bool endApp = false;
        static double cleanNum1 = 0;

        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();
            LatestCalculations lsCalculations = calculator.latestCal;
            useCount = usageCount.readUseCounts();
            // Display title as the C# console calculator app.
            Console.WriteLine($"Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");
            
            while (!endApp)
            {
                // Declare variables and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;
                if (double.IsNaN(resultFromList))
                {
                    Console.WriteLine($"\nnumber of times the calculator's been used : {useCount}\n");


                    // Ask the user to type the first number.
                    Console.Write("Type a number, and then press Enter: ");
                    numInput1 = Console.ReadLine();

                    cleanNum1 = 0;
                    while (!double.TryParse(numInput1, out cleanNum1))
                    {
                        Console.Write("This is not valid input. Please enter an integer value: ");
                        numInput1 = Console.ReadLine();
                    }
                }
                else
                {
                    cleanNum1 = resultFromList;
                }
                

                // Ask the user to type the second number.
                Console.Write("Type another number, and then press Enter: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("This is not valid input. Please enter an integer value: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask the user to choose an operator.
                Console.WriteLine("Choose an operator from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.Write("Your option? ");

                string op = Console.ReadLine();


                try
                {
                    result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                useCount++;
                // Wait for the user to respond before closing.
                Console.Write("Press 'n' and Enter to close the app\n press s and enter to see the latest calculations\n press any other key and Enter to continue: ");
                string readInput = Console.ReadLine();
                if (readInput == "n")
                {
                    endApp = true;
                }
                else if(readInput == "s")
                {
                    Console.WriteLine($"\nnumber of times the calculator's been used : {useCount}\n");
                    lsCalculations.viewList();
                    Console.WriteLine("Enter a number to use the corresponding result\n Press 'd' and enter to delete the list\n Enter any other key to continute:");
                    readInput = Console.ReadLine();
                    int index = 0;
                    if (int.TryParse(readInput, out index) && index <= lsCalculations.getLength() - 1 
                        && index >= 0)
                    {
                        resultFromList = lsCalculations.getResult(index);
                        Console.WriteLine($" \n{resultFromList}");
                    }
                    else if(readInput == "d")
                    {
                        lsCalculations.deleteList();
                    }
                    else
                    {
                        resultFromList = double.NaN;
                    }
                }
                
                Console.WriteLine("\n"); // Friendly linespacing.
            }
            calculator.Finish(useCount);
            return;
        }
    }
}
