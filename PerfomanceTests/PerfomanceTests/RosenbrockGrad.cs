using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfomanceTests
{
    class RosenbrockGrad
    {
        private int N;
        private List<double> ksi;

        public RosenbrockGrad(int N, List<double> ksi)
        {
            this.N = N;
            this.ksi = ksi;

        }

        public List<double> getGrad(List<double> points)
        {
            List<double> grad = new List<double>(N);
            Random ran = new Random();
            grad.Add(2 * points[0] - 2 - ksi[0] * 400 * points[0] * (points[1] - Math.Pow(points[0], 2)));
            for (int i = 1; i < N - 1; i++)
            {
                grad.Add(2 * points[i] + 100 * ksi[i - 1] * (2 * points[i] - 2 * Math.Pow(points[i - 1], 2.0)) - 400 * ksi[i] * points[i] * (points[i + 1] - Math.Pow(points[i], 2.0)) - 2);
            }

            grad.Add(200 * ksi[N - 2] * (points[N - 1] - Math.Pow(points[N - 2], 2)));

            return grad;
        }


    }
}
