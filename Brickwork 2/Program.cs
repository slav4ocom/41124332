using System;
using System.Linq;

namespace Brickwork_2
{
    public class Program
    {

        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var M = dimensions[0];
            var N = dimensions[1];

            if (ConsoleProcessor.CheckDimensions(M, N) == false)
            {
                Console.WriteLine("Invalid dimensions");
                Environment.Exit(-1);
            }

            var layer1 = new Layer(M, N);
            var layer2 = new Layer(M, N);

            try
                // InitFromConsole is not inteded to be validation function
                // thereby we use Exceptions technique to validate input
            {
                ConsoleProcessor.InitFromConsole(layer1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Environment.Exit(-1);
            }

            new BrickWorker(layer1, layer2).Work();
            // BrickWorker (Builder) is an instantiable class
            // because in the real world builders may be 1 or more people


            if (ConsoleProcessor.CheckNumbers(layer1) == false)
            {
                Console.WriteLine("Unable to create the second layer, because of invalid bricks found it the first layer");
                Environment.Exit(-1);
            }

            if (ConsoleProcessor.CheckBricksPlacement(layer1) == false)
            {
                Console.WriteLine("Unable to create the second layer, because of invalid first layer");
                Environment.Exit(-1);
            }

            ConsoleProcessor.PrintLayer(layer2);
        }
    }
}
