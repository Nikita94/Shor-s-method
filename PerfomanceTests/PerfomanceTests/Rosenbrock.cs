using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PerfomanceTests
{
    class Rosenbrock
    {
        private int N;
        private List<double> ksi;



        public Rosenbrock(int N, List<double> ksi)
        {
            this.N = N;
            this.ksi = ksi;
        }

        public double getSum(List<double> x)
        {
            double f = 0.0;
            for (int i = 0; i < x.Count - 1; i++)
            {
                f += Math.Pow((1 - x[i]), 2) + 100 * ksi[i] * Math.Pow((x[i + 1] - x[i] * x[i]), 2);
            }
            return f;
        }


    }
}
