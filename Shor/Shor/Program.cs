using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Shor
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {


            int N = 2;
            List<double> x = new List<double>(N) { 1.5, .5};
            Random ran = new Random();
            /*for (int i = 0; i < N; i++)
                x.Add(ran.Next(1, 3)); */

            //Rosenbrock ros = new Rosenbrock(N);
            //Console.WriteLine("Rosenbrok = " + ros.getSum(x));
            ShorMethod m = new ShorMethod(0.00001, x, N, 2);
            Console.WriteLine( m.SearchMin());

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Form1());


        }
    }
}
