using System;
using System.Collections.Generic;
using System.Text;

namespace Brickwork_2
{
    public class BrickWorker
    {
        private Layer lowerLayer;
        private Layer upperLayer;
        public BrickWorker(Layer layer1, Layer layer2)
        {
            lowerLayer = layer1;
            upperLayer = layer2;
        }

        bool working = true;
        int currentHighBrick = 1;
        int currentLowBrick;
        int Y = 0;
        int X = 0;
        

        private bool TryPlace()
        {
            var M = lowerLayer.matrix.GetLength(0);
            var N = lowerLayer.matrix.GetLength(1);

            currentLowBrick = lowerLayer.matrix[Y, X];
            if (X < (N - 1) && upperLayer.matrix[Y, X + 1] == 0 && lowerLayer.matrix[Y, X + 1] != currentLowBrick) // ako ne sme izlezli i wdqsno e 0-la
            {
                upperLayer.matrix[Y, X] = currentHighBrick;
                upperLayer.matrix[Y, X + 1] = currentHighBrick;
                return true;
            }

            if (Y < (M - 1) && upperLayer.matrix[Y + 1, X] == 0 && lowerLayer.matrix[Y + 1, X] != currentLowBrick) // ako ne sme izlezli i wdqsno e 0-la
            {
                upperLayer.matrix[Y, X] = currentHighBrick;
                upperLayer.matrix[Y + 1, X] = currentHighBrick;
                return true;
            }

            return false;
        }

        private void MoveNextPlacer()
        {
            var M = lowerLayer.matrix.GetLength(0);
            var N = lowerLayer.matrix.GetLength(1);

            X++;
            if (X == N)
            {
                X = 0;
                Y++;
                if (Y == M)
                {
                    Y = 0;
                    X = 0;
                    working = false; //krai na programata
                }
            }

        }

        public void Work()
        {

            while (working)
            {

                if (upperLayer.matrix[Y, X] == 0)
                {
                    if (TryPlace())
                    {
                        //Console.Beep();
                        currentHighBrick++;
                    }
                }

                do
                {
                    MoveNextPlacer();
                } while (false);
            }
        }
    }
}
