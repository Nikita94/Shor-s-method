using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfomanceTests
{
    public class Lev_Markv
    {
        public double R_fun(double[] x, double[] csi, int N)
        {
            double f = 0;
            for (int i = 0; i <= N - 2; i++)
            {
                f += Math.Pow(1 - x[i], 2) + 100 * csi[i] * Math.Pow(x[i + 1] - x[i] * x[i], 2);
            }

            return f;
        }

        public void grad_funR(double[] x, double[] g, double[] csi, int N)
        {
            g[0] = -2 * (1 - x[0]) - 400 * csi[0] * (x[1] - x[0] * x[0]) * x[0];
            for (int i = 1; i <= N - 2; i++)
                g[i] = 200 * csi[i-1] * (x[i] - x[i - 1] * x[i - 1]) - 2 * (1 - x[i]) - 400 * csi[i] * (x[i + 1] - x[i] * x[i]) * x[i];
            g[N - 1] = 200 * csi[N-2] * (x[N - 1] - x[N - 2] * x[N - 2]);
        }

        public void gessian_funR(double[] x, double[][] G, double[] csi, int N)
        {

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    G[i][j] = 0;

            G[0][0] = 2 - 400 * csi[0] * (x[1] - 3 * x[0] * x[0]);
            for (int i = 1; i <= N - 1; i++)
            {
                if (i != N - 1)
                    G[i][i] = 200 * csi[i-1] + 2 - 400 * csi[i] * (x[i + 1] - 3* x[i] * x[i]);

                G[i][i - 1] = -400 * csi[i-1] * x[i - 1];
                G[i - 1][i] = G[i][i - 1];
            }
            G[N - 1][N - 1] = 200 * csi[N-2];

        }

        public double norma(double[] v, int N)
        {
            double n = 0;
            for (int i = 0; i < N; i++)
            {
                n += Math.Pow(Math.Abs(v[i]), 2);
            }

            n = Math.Sqrt(n);

            return n;
        }


        public void inverse(double[][] A, double[][] inv, int N)
        {
            double alpha;
            double[][] I = new double[N][];
            for (int i = 0; i < N; i++)
            {
                I[i] = new double[N];

                for (int j = 0; j < N; j++)
                {
                    inv[i][j] = A[i][j];
                    I[i][j] = 0;
                }
                I[i][i] = 1;
            }

            for (int j = 0; j < N; j++)
            {
                for (int i = j + 1; i < N; i++)
                {
                    alpha = inv[i][j] / inv[j][j];
                    for (int k = 0; k < N; k++)
                    {
                        inv[i][k] = inv[i][k] - alpha * inv[j][k];
                        I[i][k] = I[i][k] - alpha * I[j][k];
                    }
                }
            }

            for (int j = N - 1; j >= 0; j--)
            {
                for (int i = j - 1; i >= 0; i--)
                {
                    alpha = inv[i][j] / inv[j][j];
                    for (int k = N - 1; k >= 0; k--)
                    {
                        inv[i][k] = inv[i][k] - alpha * inv[j][k];
                        I[i][k] = I[i][k] - alpha * I[j][k];
                    }
                }
            }
            for (int i = 0; i < N; i++)
            {
                alpha = inv[i][i];
                for (int j = 0; j < N; j++)
                {
                    inv[i][j] = inv[i][j] / alpha;
                    I[i][j] = I[i][j] / alpha;
                }
            }

            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                    inv[i][j] = I[i][j];
        }

        public double Vect_x_Vect(double[] v1, double[] v2, int N)
        {
            double t = 0;
            for (int i = 0; i < N; i++)
                t += v1[i] * v2[i];

            return t;
        }

        public double[] Matr_x_Vect(double[][] A, double[] v, int N)
        {
            double[] d = new double[N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    d[i] = Vect_x_Vect(A[i], v, N);
                }
            }

            return d;
        }

        public void Vect_x_a(double[] v, double a, int N)
        {
            for (int i = 0; i < N; i++)
                v[i] = v[i] * a;
        }

        public void matrixMult(double[][] A, double[][] B, double[][] C, int N)
        {
            double tmp;
            int i, j, k;
            for (i = 0; i < N; i++)
                for (j = 0; j < N; j++)
                    C[i][j] = 0;
            for (i = 0; i < N; i++)
            {
                for (j = 0; j < N; j++)
                {
                    tmp = 0;
                    for (k = 0; k < N; k++)
                        tmp += A[i][k] * B[k][j];
                    C[i][j] += tmp;
                }
            }
        }

        public ReturnData alg_LM_adapt(int N, double[] x0, double []csi, double eps, double Kiter, double gamma0 = 10000, double v = 10)
        {
            double gamma = gamma0;
            double[] x_min = new double[N];
            double[] x_k = new double[N];
            double[] x_knew = new double[N];
            double[] gradfR = new double[N];
            double[] d_k = new double[N];
            double[][] Gessian = new double[N][];
            double[][] GessianInv = new double[N][];

            ReturnData result = new ReturnData(N);

            for (int i = 0; i < N; i++)
            {
                Gessian[i] = new double[N];
                GessianInv[i] = new double[N];

                x_k[i] = x0[i];
                x_knew[i] = x0[i];
            }

            int k = 0;
            while (k <= Kiter)
            {
                //Вычисление градиента
                grad_funR(x_k, gradfR, csi, N);
                result.F += 2*N + 1;

                //Проверка критерия останова
                if (norma(gradfR, N) < eps)
                {
                    //cout<<"    STOP"<<endl;
                    for (int i = 0; i < N; i++)
                    {
                        x_min[i] = x_k[i];
                    }
                    break;
                }

                gessian_funR(x_k, Gessian, csi, N);
                result.F += N * N + 1;

                while (R_fun(x_knew, csi, N) >= R_fun(x_k, csi, N))
                {
                    result.F += 4;
                    //Прибавление к главной диагонали гессиана шрафной добавки (параметра регуляяризации)
                    for (int i = 0; i < N; i++)
                        Gessian[i][i] += gamma;//*Gessian[i][i];

                    //Нахождение обратной матрицы
                    inverse(Gessian, GessianInv, N); ;

                    //Вычисление направления поиска
                    d_k = Matr_x_Vect(GessianInv, gradfR, N);
                    Vect_x_a(d_k, -1, N);

                    result.D.Add(d_k);

                    //Вычисление новой точки x_k+1
                    for (int i = 0; i < N; i++)
                    {
                        x_knew[i] = x_k[i] + d_k[i];
                    }

                    //cout<<"f_k+1 >= f_k"<<endl;
                    if (R_fun(x_knew, csi, N) >= R_fun(x_k, csi, N))
                        gamma = v * gamma;

                }

                for (int i = 0; i < N; i++)
                    x_k[i] = x_knew[i];
                gamma = gamma / v;
                k++;

            }

            result.K = k;
            result.min = x_min;

            return result;
        }

    }
}
