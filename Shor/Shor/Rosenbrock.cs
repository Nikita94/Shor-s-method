using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Shor
{
    class Rosenbrock 
    {
        private int N;
        private List<double> x;

        

        public Rosenbrock(int N, List<double> x) {
            this.N = N;
            this.x = x;
        }

        public double getSum() {
            double f = 0.0;
            Random ran = new Random();
            for (int i = 0; i < x.Count - 1; i++)
            {
                f += Math.Pow(1 - x[i], 2) + 100 * ran.Next(0, 1) * Math.Pow(x[i + 1] - x[i] * x[i], 2);
            }
            return f;
        }


    }
}
