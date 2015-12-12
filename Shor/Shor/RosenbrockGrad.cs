using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shor
{
    class RosenbrockGrad
    {
        private int N;
        private double ksi;

        public RosenbrockGrad(int N, double ksi)
        {
            this.N = N;
            this.ksi = ksi;

        }

        public List<double> getGrad(List<double> x)
        {
            List<double> gf = new List<double>(N);
            Random ran = new Random();
            for (int i = 0; i < N - 1; i++)
            {
                gf.Add(-2 * (1 - x[i]) - 400 * x[i] * ksi * (x[i + 1] - x[i] * x[i]));
            }

            gf.Add(200 * (x[N - 1] - x[N - 2] * x[N - 2]));

            return gf;
        }


    }
}
