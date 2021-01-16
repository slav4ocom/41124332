using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brickwork_2
{
    public class Layer
    {
        private int M;
        private int N;
        public Layer(int m, int n) // m is thickness/width Y, n is length X
        {
            this.M = m;
            this.N = n;
            matrix = new int[M, N];
        }

        public int[,] matrix; // two dimensional array describing layer

    }
}
