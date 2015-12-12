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

        public List<double> getGrad(List<double> points)
        {
            List<double> grad = new List<double>(N);
            Random ran = new Random();
            /*for (int i = 0; i < N - 1; i++)
            {
                gf.Add(-2.0 * (1.0 - x[i]) - 400 * x[i] * ksi * (x[i + 1] - x[i] * x[i]));
            }

            gf.Add(200 * ksi * (x[N - 1] - x[N - 2] * x[N - 2])); */

            //gf.Add(-400.0 * ksi * (x[1] - x[0] * x[0]) * x[0] - 2.0* (1.0 - x[0]));
            //gf.Add(200.0 * ksi * (x[1] - x[0] * x[0]));

            grad.Add(2 * points[0] - ksi * 400 * points[0] * (points[1] - Math.Pow(points[0], 2.0)) - 2);
            for (int i = 1; i < N - 1; i++)
            {
                grad.Add(2 * points[i] + 100 * ksi * (2 * points[i] - 2 * Math.Pow(points[i - 1], 2.0)) - 400 * ksi * points[i] * (points[i + 1] - Math.Pow(points[i], 2.0)) - 2);
            }

            grad.Add(100 * ksi * (2 * points[N - 1] - 2 * Math.Pow(points[N - 2], 2.0)));

            return grad;
        }


    }
}
