using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfomanceTests
{
    public class ReturnData
    {
        public int N;
        public int F;
        public int K; 
        public double[] min;

        public ReturnData(int n)
        {
            this.N = n;
            this.K = 0;
            this.F = 0;
            min = new double[n];
            for (int i = 0; i < n; i++)
                min[i] = 0;
        }
    }
}
