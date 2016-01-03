using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfomanceTests
{
    class ShorMethod
    {
        private double epcilon;
        private double mu;
        private double eta;
        private double sigma;
        private List<double> x;
        private List<double> x1;
        private double alfa;
        private List<double> B;
        private List<double> prevB;
        private List<double> R;
        private int N;
        private Rosenbrock f;
        private RosenbrockGrad fg;
        private List<double> g;
        private List<double> g1;
        private double dq = 5.1;
        private List<double> g0;
        private List<double> z;
        private List<double> gt;
        private List<double> ksi;
        private List<double> prevr;
        private List<double> BBT;
        private List<double> d;
        private double mxtc = 3;
        private double h = 0.0001;
        private int iteration;
        private double w;
        private double epsnorm = Math.Pow(10, -10);
        private double f0;
        private double dd;
        private List<List<double>> midlineX;
        private List<double> tmpX;
        public int countIter;


        public ShorMethod(double epcilon, List<double> x, int N, double alfa, List<double> ksi, int iterations)
        {
            this.iteration = iterations;
            this.N = N;
            this.epcilon = epcilon;
            this.x = x;
            this.alfa = alfa;
            f = new Rosenbrock(N, ksi);
            fg = new RosenbrockGrad(N, ksi);
            if (alfa == 0)
                return;
            B = new List<double>(N * N);
            g = new List<double>(N);
            prevr = new List<double>(N);
            mu = 0.0001; eta = 0.0005; sigma = 0.0001;
            w = (1 / alfa - 1);
            midlineX = new List<List<double>>();
        }


        public ReturnData SearchMin()
        {
            ReturnData results = new ReturnData(N);
            // Шаг 1
            f0 = f.getSum(x);
            results.F += 1;
            g = fg.getGrad(x);
            results.F += N+1;
            g1 = new List<double>(g);
            results.F +=  N + 1;
            for (int i = 0; i < N; i++)  // B0 = E
                for (int j = 0; j < N; j++)
                {
                    if (i == j)
                        B.Add(1);
                    else
                        B.Add(0);
                }
            double tmp = 0.0;
            for (int i = 0; i < N; i++)
            {
                if (tmp < Math.Abs(x[i]))
                    tmp = Math.Abs(x[i]);
            }

            double h = Math.Sqrt(0.0001) * tmp;   // Первый минимальный шаг
            countIter = 0;

            tmpX = new List<double>(x);
            midlineX.Add(tmpX);

            while (normVec(g) > epcilon && countIter <= iteration)
            {
                double d = 0.0;
                dd = 0.0;
                double ngt = 0.0;
                double ng1 = 0.0;
                gt = new List<double>(N);
                ksi = new List<double>(N);
                g0 = new List<double>(N);
                x1 = new List<double>(N);
                prevB = new List<double>(B);

                // Градиент в преобразованном пространствен gt
                for (int i = 0; i < N; i++)
                {
                    gt.Add(0.0);
                    d = 0.0;
                    for (int j = 0; j < N; j++)
                        d += B[j + i * N] * g[j];
                    gt[i] = d;
                    // dd += d * g1[i];
                    ngt += d * d;
                    ng1 += g1[i] * g1[i];
                }

                ngt = Math.Sqrt(ngt);
                ng1 = Math.Sqrt(ng1);
                // dd /= ngt * ng1;
                // 
                for (int i = 0; i < N; i++)
                {
                    ksi.Add(gt[i] - g1[i]);
                }
                double nrmksi = normVec(ksi);
                if (countIter > 0)
                {
                    for (int i = 0; i < N; i++)
                        ksi[i] /= nrmksi;
                    d = 0.0;
                    for (int i = 0; i < N; i++)
                        d += ksi[i] * gt[i];
                    ng1 = 0.0; d *= w;
                    for (int i = 0; i < N; i++)
                    /* g1=gt+(1 / alfa - 1)*(ksi*gt')*ksi: */
                    {
                        dd = 0.0;
                        g1[i] = gt[i] + d * ksi[i];
                        ng1 += g1[i] * g1[i];
                        for (int j = 0; j < N; j++)
                            dd += B[j * N + i] * ksi[j];
                        dd *= w;
                        /* Новая матрица преобразования: B = B ( E + (1/alpha -1)ksi*ksit' ) */
                        for (int j = 0; j < N; j++)
                            B[j * N + i] += dd * ksi[j];
                    }
                    ng1 = Math.Sqrt(ng1);
                }

                for (int i = 0; i < N; i++)
                    gt[i] = g1[i] / ng1;
                /* Градиент в нетрансформированом пространстве: g0 = B' * gt   */
                for (int i = 0; i < N; i++)
                {
                    d = 0.0;
                    g0.Add(0.0);
                    for (int j = 0; j < N; j++)
                        d += prevB[j * N + i] * gt[j];
                    g0[i] = d;
                }


                adaptiveAdjustmentOfStep(results);
                g = fg.getGrad(x);

                results.F +=  N + 1;
                countIter += 1;

            }
            results.K = countIter;
            results.min = x.ToArray();
            return results;
        }

        public double normVec(List<double> vector)
        {
            double norma = 0.0;

            foreach (double comp in vector)
                norma += comp * comp;

            return Math.Sqrt(norma);

        }

        
        

        private double scalarProduct(List<double> aVector, List<double> bVector)
        {
            double product = 0.0;
            for (int i = 0; i < N; i++)
                product += aVector[i] + bVector[i];

            return product;
        }

        private void adaptiveAdjustmentOfStep(ReturnData results)
        {
            for (int i = 0; i < N; i++)
                x1.Add(x[i]);
            double hp = h;
            bool ksm = false;
            double k1 = 0.0, k2 = 0.0;
            double kc = 0.0;
            double ii, stepvanish = 0.0;
            double du20 = 2.0, du10 = 1.5, du03 = 1.05;

            while (true)
            {
                for (int i = 0; i < N; i++)
                    x1[i] = x[i];
                double f1 = f0;

                if (f1 < 0.0) dd = -1.0;
                else
                    dd = 1.0;

                /* Следующе испытание:   */
                for (int i = 0; i < N; i++)
                    x[i] -= hp * g0[i];
                ii = 0.0;
                for (int i = 0; i < N; i++)
                {
                    if (Math.Abs(x[i] - x1[i]) < Math.Abs(x[i]) * epsnorm)
                        ii += 1;
                }

                /* Функция в текущее точке:  */

                f0 = f.getSum(x);
                results.F +=  1;
                if (ii == N)
                {
                    stepvanish += 1;
                    if (stepvanish >= 5)
                        return;
                    else
                    {
                        for (int i = 0; i < N; i++)
                            x[i] = x1[i];
                        f0 = f1;
                        hp *= 10.0;
                        ksm = true;
                    }
                }
                /* используем маленький шаг:   */
                else if (f0 > f1)
                {
                    if (ksm)
                        return;
                    k2 += 1;
                    k1 = 0;
                    hp /= dq;
                    for (int i = 0; i < N; i++)
                        x[i] = x1[i];
                    f0 = f1;
                    if (kc >= mxtc)
                        return;
                }
                else
                {
                    if (-1.0 * f0 <= -1.0 * f1)
                        return;
                    /* Используеем больший шаг */
                    k1 += 1;
                    if (k2 > 0) kc += 1;
                    k2 = 0;
                    if (k1 >= 20) hp *= du20;
                    else
                    if (k1 >= 10) hp *= du10;
                    else if (k1 >= 3) hp *= du03;
                }
            }
        }
    }
}
