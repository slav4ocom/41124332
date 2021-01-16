using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brickwork_2
{
    public static class ConsoleProcessor
    {
        public static void PrintLayer(Layer inLayer)
        {
            var inMatrix = inLayer.matrix;

            for (int y = 0; y < inMatrix.GetLength(0); y++)
            {
                Console.WriteLine(string.Join(' ', Enumerable.Range(0, inMatrix.GetLength(1))
                    .Select(x => inMatrix[y,x])));
            }
        }


        public static void InitFromConsole(Layer outLayer)
        {
            var outMatrix = outLayer.matrix;

            for (int y = 0; y < outMatrix.GetLength(0); y++)
            {
                var inputLine = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                if (outMatrix.GetLength(1) != inputLine.Count())
                {
                    throw new ArgumentException("Invalid input format");
                    //return false;
                }

                for (int x = 0; x < outMatrix.GetLength(1); x++)
                {
                    outMatrix[y, x] = inputLine[x];
                }
            }

        }

        public static bool CheckNumbers(Layer inLayer)
        {
            var matrix = inLayer.matrix;
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            var numsCnt = ((m * n) / 2);
            int[] nums = new int[numsCnt + 1];

            for (int y = 0; y < m; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    var currentNum = matrix[y, x];

                    if (currentNum < 1 || currentNum >= nums.Length)
                    {
                        return false;
                    }
                    else
                    {
                        nums[matrix[y, x]]++; // wsqka poziciq se zarejda s chisloto ot matricata
                    }

                }
            }

            for (int i = 1; i <= numsCnt; i++)
            {
                if (nums[i] != 2)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool CheckBricksPlacement(Layer inLayer)
        // funkciqta prowerqwa dali tuhlata e slojena prawilno - horizontalno ili vertikalno
        // t.e. da ne e po diagonal ili da e na dwe otdelni mesta (razdelena)
        {
            var matrix = inLayer.matrix;
            var m = matrix.GetLength(0);
            var n = matrix.GetLength(1);

            for (int y = 0; y < m; y++)
            {
                for (int x = 0; x < n; x++)
                {
                    if (x < (n - 1) && matrix[y, x] == matrix[y, x + 1]) // otdqsno
                    {

                    }
                    else if (y < (m - 1) && matrix[y, x] == matrix[y + 1, x]) // otdolu
                    {

                    }
                    else if (x > 0 && matrix[y, x] == matrix[y, x - 1]) // otlqwo
                    {

                    }
                    else if (y > 0 && matrix[y, x] == matrix[y - 1, x]) // otgore
                    {

                    }
                    else
                    {
                        return false;
                        //Console.WriteLine("Invalid brick placement");
                    }

                }


            }

            return true;
        }

        public static bool CheckDimensions(int m, int n)
        {
            if (m < 1 || m >= 100 || n < 1 || n >= 100) // proverka za razmera
            {
                return false;
            }

            if (m % 2 != 0 || n % 2 != 0) // kolonite i redowete trbqwa da sa cheten broi
            {
                return false;
            }

            return true;
        }

    }

}
