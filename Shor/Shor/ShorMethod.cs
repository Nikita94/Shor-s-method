using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shor
{
    class ShorMethod
    {
        private double epcilon;
        private double mu;
        private double eta;
        private double sigma;
        private List<double> x;
        private double alfa;
        private List<double> B;
        private List<double> prevB;
        private List<double> R;
        private int N;
        private Rosenbrock f;
        private RosenbrockGrad fg;
        private List<double> r;
        private List<double> ksi;
        private List<double> prevr;
        private List<double> BBT;
        private List<double> d;
        private int iteration;


        public ShorMethod(double epcilon, List <double>x, int N, double alfa) {
            Random ran = new Random();
            double h = ran.NextDouble();
            this.N = N;
            this.epcilon = epcilon;
            this.x = x;
            this.alfa = alfa;
            f = new Rosenbrock(N, h);
            fg = new RosenbrockGrad(N, h);
            if (alfa == 0)
                return;
            B = new List<double>(N*N);
            r = new List<double>(N);
            d = new List<double>(N);
            prevr = new List<double>(N);
            ksi = new List<double>(N);
            mu = 0.0001; eta = 0.00015; sigma = 0.0001;
            iteration = 1;

        }

        public List<Double> SearchMin() {
            // Step 1
            double f0 = f.getSum(x);
            r = fg.getGrad(x);
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    if (i == j)
                        B.Add(1);
                    else
                        B.Add(0);
                }
            // MAIN ITERATIONS
            while (true)
            {
                iteration += 1;
                // Step 2
                prevB = new List<double>(B);
                BBT = multMatrix(prevB, prevB, false);
                double[] newR = new double[N];
                newR = r.ToArray();
                prevr = new List<double>(newR);

                for (int i = 0; i < N; i++) {
                    double comp = 0.0;
                    for (int j = 0; j < N; j++) {
                        comp -= BBT[j + i * N] * prevr[j];
                    }
                    d.Add(comp);
                }

                double xk = oneDimensionalOptimization(x, d, fg.getGrad(x), f.getSum(x));
                for (int i = 0; i < N; i++) {
                    x[i] = x[i] + xk * d[i];
                }

                r = fg.getGrad(x);
                    // Step 3
                    if (normVec(r) < epcilon || iteration > 200)
                {
                    // Step 4
                    for (int i = 0; i < N; i++) {
                        prevr[i] = r[i] - prevr[i];
                    }

                    for (int i = 0; i < N; i++) {
                        double compKsi = 0.0;
                        for (int j = 0; j < N; j++) {
                            compKsi += B[i + N * j] * prevr[j];
                        }

                        ksi.Add(compKsi);
                    }
                    // End step 4  

                    // Step 5
                    double[] newB = new double[N * N];
                    newB = B.ToArray();
                    prevB = new List<double>(newB);

                    R = calculateMultMatrix(ksi);
                    B = multMatrix(prevB, R, true);
                }
                else 
                    break;

            }
            return x;
        }


        private double normVec(List<double> vector) {
            double norma = 0.0;

            foreach (double comp in vector)
                norma += comp * comp;

            return Math.Sqrt(norma);

        }

        private List<double> calculateMultMatrix(List<double> ksi) {
            List<double> R = new List<double>(N * N);
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++) {
                    if (i == j)
                        R.Add(1 + (1 / alfa) * ksi[i] * ksi[j]);
                }
            return R;
        }

        private List<double> multMatrix(List<double> aMatrix, List<double> bMatrix, bool transposed) {
            List<Double> cMatrix = new List<double>(N * N);
            for (int l = 0; l < N; l++)
            {
                double tmp = 0.0;
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        if (transposed)
                            tmp += aMatrix[j + i * N] * bMatrix[j * N + i];
                        else
                            tmp += aMatrix[j + i * N] * bMatrix[i * N + j];
                    }
                    cMatrix.Add(tmp);
                }
            }

            return cMatrix;

        }

        private bool P1(List<double> x, List<double> d, List<double> gradient, double value, double t){
            List<double> newX = new List<double>(N);
            for (int i = 0; i < N; i++)
                newX.Add(x[i] + t * d[i]);
            double scalar = scalarProduct(fg.getGrad(x) ,d);
            double newValue = f.getSum(newX);
	        if(newValue <= value + mu* t * scalar)
                return true;
	        else
                return false;	
        }

        bool P2(List<double> x, List<double> d, List<double> gradient, double t){
            List<double> newX = new List<double>(N);
            for (int i = 0; i < N; i++)
                newX.Add(x[i] + t * d[i]);
            List<double> newGradient = fg.getGrad(newX);
            double scalar = scalarProduct(gradient, d);
            double newScalar = scalarProduct(newGradient, d);
            scalar = Math.Abs(scalar);
            newScalar = Math.Abs(newScalar);
            if (newScalar < eta * scalar)
                return true;
	        else
                return false;
        }

        private double scalarProduct(List<double> aVector, List<double> bVector) {
            double product = 0.0;
            for (int i = 0; i < N; i++)
                product += aVector[i] + bVector[i];

            return product;
        }

        private double selectionOfInterval(List<double> x, List<double> d) {
            double T = Double.MaxValue;
            double t1 = sigma, t0 = 0;
            double ourSigma = sigma;
            List<double> value = new List<double>(N);
            List<double> newValue = new List<double>(N);
            for (int i = 0; i < N; i++) {
                value.Add(x[i] + t0 * d[i]);
                newValue.Add(x[i] + t1 * d[i]);
            }

            double phi = f.getSum(value);
            double newPhi = f.getSum(newValue);
            double scalPr = scalarProduct(fg.getGrad(newValue), d);
            while (newPhi < phi && scalPr < 0) {
                if (!P1(newValue, d, fg.getGrad(newValue), f.getSum(newValue), t1))
                    break;

                ourSigma = 2 * ourSigma;
                t0 = t1;
                t1 = t0 + ourSigma;

                for (int i = 0; i < N; i++)
                {
                    value[i] = x[i] + t0 * d[i];
                    newValue[i] = x[i] + t1 * d[i];
                }

                phi = f.getSum(value);
                newPhi = f.getSum(newValue);
                scalPr = scalarProduct(fg.getGrad(newValue), d);
            }
            return t1;
        }

        double goldenSection(double a, double b, List<double> x, List<double> d, List<double> gradient, double value){
            double t = b, t1, t2, Y1, Y2;
            double z = ((double)Math.Sqrt(5.0) + 1.0) / 2.0;
            List<double> x1 = new List<double> (N);
            List<double> x2 = new List<double>(N);
            bool p1, p2;	
	        do {
		        t1 = b - (b - a) / z;
		        t2 = a + (b - a) / z;
                for (int i = 0; i < N; i++){ 
                    x1.Add(x[i] + t1 * d[i]);
                    x2.Add(x[i] + t2 * d[i]);
                }
                Y1 = f.getSum(x1);
                Y2 = f.getSum(x2);
		        if(Y1 > Y2){
		        	a = t1;
		        	t1 = t2;
		        	t2 = a + (b - a) / z;
		        }
		        else {
		        	b = t2; 
		        	t2 = t1;
		        	t1 = b - (b - a) / z;
		        }
                t = (a + b) / 2.0;
		        p1 = P1(x, d, gradient, value, t);
                p2 = P2(x, d, gradient, t);
                Console.WriteLine("Rosenbrok");
            } while((!p1 || !p2));	
	        return t;
        }

        private double oneDimensionalOptimization(List<double> x, List<double> d, List<double> gradient, double value) {
            double t = selectionOfInterval(x, d);
            return goldenSection(0, t, x, d, gradient, value);
        }
    }
}
