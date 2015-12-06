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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            List<double> x = new List<double>();
            int N = 3;
            Random ran = new Random();
            for (int i = 0; i < N; i++)
                x[i] = ran.Next(-3, 3);

            Rosenbrock ros = new Rosenbrock(N, x);
            Console.WriteLine( ros.getSum());


        }
    }
}
