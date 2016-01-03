using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace PerfomanceTests
{
    public partial class Form1 : Form
    {
        private GraphPane myPane; // объявление области отображения
        public int Klimitation = 10000;
        public double epsilon = 0.01;

        public Form1()
        {
            InitializeComponent();
        }

        private void CreateLineGraph1(int Ksup)        // создание графика
        {
            myPane = zedGraphControl1.GraphPane;

            //если что-то есть - удаляем          
            myPane.CurveList.Clear();

            //Запрет на самосогласования и выход за установленные границы
            myPane.XAxis.Scale.MaxGrace = 0;
            myPane.YAxis.Scale.MaxGrace = 0;
            myPane.XAxis.Scale.MinGrace = 0;
            myPane.YAxis.Scale.MinGrace = 0;

            // Устанавливаем интересующий нас интервал по оси X
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 100;
            //Ручная установка шага оси Х  
            myPane.XAxis.Scale.MinorStep = 2;
            myPane.XAxis.Scale.MajorStep = 10;

            // Устанавливаем интересующий нас интервал по оси Y 
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = Ksup+100;
            myPane.YAxis.Scale.MinorStep = Ksup / 10; 
            myPane.YAxis.Scale.MajorStep = Ksup / 5;

            //Рисуем сетку по X
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.DashOn = 5;
            myPane.XAxis.MajorGrid.DashOff = 5;
            myPane.XAxis.MajorGrid.Color = Color.Gray;
            myPane.XAxis.Color = Color.Gray;

            //Рисуем сетку по Y
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.DashOn = 5;
            myPane.YAxis.MajorGrid.DashOff = 5;
            myPane.YAxis.MajorGrid.Color = Color.Gray;
            myPane.YAxis.Color = Color.Gray;
        }

        private void Graw_Draw1(int[] x, int[] y)
        {
            //Получаем линии от графиков
            PointPairList list1 = new PointPairList(); //Метод Левенберга-Марквардта

            for (int i = 0; i < 7; i++)
            { 
                list1.Add(x[i], y[i]);
            }

            LineItem curve1 = myPane.AddCurve("Shor's method", list1, Color.Blue, SymbolType.None);
            curve1.Line.Width = 2;
            //Аналогично для других методов

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            zedGraphControl1.AxisChange();
            // Обновляем график
            zedGraphControl1.Invalidate();
        }

        private void CreateLineGraph2()        // создание графика
        {
            myPane = zedGraphControl2.GraphPane;

            //если что-то есть - удаляем          
            myPane.CurveList.Clear();

            //Запрет на самосогласования и выход за установленные границы
            myPane.XAxis.Scale.MaxGrace = 0;
            myPane.YAxis.Scale.MaxGrace = 0;
            myPane.XAxis.Scale.MinGrace = 0;
            myPane.YAxis.Scale.MinGrace = 0;

            // Устанавливаем интересующий нас интервал по оси X
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 10;
            //Ручная установка шага оси Х  
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 1;

            // Устанавливаем интересующий нас интервал по оси Y 
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = 20;
            myPane.YAxis.Scale.MinorStep = 2;
            myPane.YAxis.Scale.MajorStep = 5;

            //Рисуем сетку по X
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.DashOn = 5;
            myPane.XAxis.MajorGrid.DashOff = 5;
            myPane.XAxis.MajorGrid.Color = Color.Gray;
            myPane.XAxis.Color = Color.Gray;

            //Рисуем сетку по Y
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.DashOn = 5;
            myPane.YAxis.MajorGrid.DashOff = 5;
            myPane.YAxis.MajorGrid.Color = Color.Gray;
            myPane.YAxis.Color = Color.Gray;
        }

        private void Graw_Draw2(double[] x, double[][] y)
        {
            //Получаем линии от графиков
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();
            PointPairList list5 = new PointPairList();
            PointPairList list6 = new PointPairList();
            PointPairList list7 = new PointPairList();

            for (int i = 0; i < 7; i++)            
            {

                list1.Add(Math.Abs(Math.Log10(x[i])), Math.Abs(Math.Log10(y[i][0])));
                list2.Add(Math.Abs(Math.Log10(x[i])), Math.Abs(Math.Log10(y[i][1])));
                list3.Add(Math.Abs(Math.Log10(x[i])), Math.Abs(Math.Log10(y[i][2])));
                list4.Add(Math.Abs(Math.Log10(x[i])), Math.Abs(Math.Log10(y[i][3])));
                list5.Add(Math.Abs(Math.Log10(x[i])), Math.Abs(Math.Log10(y[i][4])));
                list6.Add(Math.Abs(Math.Log10(x[i])), Math.Abs(Math.Log10(y[i][5])));
                list7.Add(Math.Abs(Math.Log10(x[i])), Math.Abs(Math.Log10(y[i][6])));
            }

            LineItem curve1 = myPane.AddCurve("N=2", list1, Color.Blue, SymbolType.None);
            curve1.Line.Width = 2;
            LineItem curve2 = myPane.AddCurve("N=3", list2, Color.Red, SymbolType.None);
            curve2.Line.Width = 2;
            LineItem curve3 = myPane.AddCurve("N=5", list3, Color.Green, SymbolType.None);
            curve3.Line.Width = 2;
            LineItem curve4 = myPane.AddCurve("N=10", list4, Color.Brown, SymbolType.None);
            curve4.Line.Width = 2;
            LineItem curve5 = myPane.AddCurve("N=30", list5, Color.Chocolate, SymbolType.None);
            curve5.Line.Width = 2;
            LineItem curve6 = myPane.AddCurve("N=50", list6, Color.Magenta, SymbolType.None);
            curve6.Line.Width = 2;
            LineItem curve7 = myPane.AddCurve("N=100", list7, Color.Cyan, SymbolType.None);
            curve7.Line.Width = 2;


            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            zedGraphControl2.AxisChange();
            // Обновляем график
            zedGraphControl2.Invalidate();
        }

        private void CreateLineGraph3(int Kstop)        // создание графика
        {
            myPane = zedGraphControl3.GraphPane;

            //если что-то есть - удаляем          
            myPane.CurveList.Clear();

            //Запрет на самосогласования и выход за установленные границы
            myPane.XAxis.Scale.MaxGrace = 0;
            myPane.YAxis.Scale.MaxGrace = 0;
            myPane.XAxis.Scale.MinGrace = 0;
            myPane.YAxis.Scale.MinGrace = 0;

            // Устанавливаем интересующий нас интервал по оси X
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 10;
            //Ручная установка шага оси Х  
            myPane.XAxis.Scale.MinorStep = 1;
            myPane.XAxis.Scale.MajorStep = 1;

            // Устанавливаем интересующий нас интервал по оси Y 
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max =  Kstop+100;
            myPane.YAxis.Scale.MinorStep =  Kstop/10;
            myPane.YAxis.Scale.MajorStep =  Kstop/5;

            //Рисуем сетку по X
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.DashOn = 5;
            myPane.XAxis.MajorGrid.DashOff = 5;
            myPane.XAxis.MajorGrid.Color = Color.Gray;
            myPane.XAxis.Color = Color.Gray;

            //Рисуем сетку по Y
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.DashOn = 5;
            myPane.YAxis.MajorGrid.DashOff = 5;
            myPane.YAxis.MajorGrid.Color = Color.Gray;
            myPane.YAxis.Color = Color.Gray;
        }

        private void Graw_Draw3(double[] x, int[][] y)
        {
            //Получаем линии от графиков
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();
            PointPairList list5 = new PointPairList();
            PointPairList list6 = new PointPairList();
            PointPairList list7 = new PointPairList();

            for (int i = 0; i < 7; i++)
            {

                list1.Add(Math.Abs(Math.Log10(x[i])), y[i][0]);
                list2.Add(Math.Abs(Math.Log10(x[i])), y[i][1]);
                list3.Add(Math.Abs(Math.Log10(x[i])), y[i][2]);
                list4.Add(Math.Abs(Math.Log10(x[i])), y[i][3]);
                list5.Add(Math.Abs(Math.Log10(x[i])), y[i][4]);
                list6.Add(Math.Abs(Math.Log10(x[i])), y[i][5]);
                list7.Add(Math.Abs(Math.Log10(x[i])), y[i][6]);
            }

            LineItem curve1 = myPane.AddCurve("N=2", list1, Color.Blue, SymbolType.None);
            curve1.Line.Width = 2;
            LineItem curve2 = myPane.AddCurve("N=3", list2, Color.Red, SymbolType.None);
            curve2.Line.Width = 2;
            LineItem curve3 = myPane.AddCurve("N=5", list3, Color.Green, SymbolType.None);
            curve3.Line.Width = 2;
            LineItem curve4 = myPane.AddCurve("N=10", list4, Color.Brown, SymbolType.None);
            curve4.Line.Width = 2;
            LineItem curve5 = myPane.AddCurve("N=30", list5, Color.Chocolate, SymbolType.None);
            curve5.Line.Width = 2;
            LineItem curve6 = myPane.AddCurve("N=50", list6, Color.Magenta, SymbolType.None);
            curve6.Line.Width = 2;
            LineItem curve7 = myPane.AddCurve("N=100", list7, Color.Cyan, SymbolType.None);
            curve7.Line.Width = 2;


            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            zedGraphControl3.AxisChange();
            // Обновляем график
            zedGraphControl3.Invalidate();
        }

        private void CreateLineGraph4(double max)        // создание графика
        {
            myPane = zedGraphControl4.GraphPane;

            //если что-то есть - удаляем          
            myPane.CurveList.Clear();

            //Запрет на самосогласования и выход за установленные границы
            myPane.XAxis.Scale.MaxGrace = 0;
            myPane.YAxis.Scale.MaxGrace = 0;
            myPane.XAxis.Scale.MinGrace = 0;
            myPane.YAxis.Scale.MinGrace = 0;

            // Устанавливаем интересующий нас интервал по оси X
            myPane.XAxis.Scale.Min = 0;
            myPane.XAxis.Scale.Max = 100;
            //Ручная установка шага оси Х  
            myPane.XAxis.Scale.MinorStep = 2;
            myPane.XAxis.Scale.MajorStep = 10;

            // Устанавливаем интересующий нас интервал по оси Y 
            myPane.YAxis.Scale.Min = 0;
            myPane.YAxis.Scale.Max = max + 100;
            myPane.YAxis.Scale.MinorStep = max/1000;
            myPane.YAxis.Scale.MajorStep = max/100;

            //Рисуем сетку по X
            myPane.XAxis.MajorGrid.IsVisible = true;
            myPane.XAxis.MajorGrid.DashOn = 5;
            myPane.XAxis.MajorGrid.DashOff = 5;
            myPane.XAxis.MajorGrid.Color = Color.Gray;
            myPane.XAxis.Color = Color.Gray;

            //Рисуем сетку по Y
            myPane.YAxis.MajorGrid.IsVisible = true;
            myPane.YAxis.MajorGrid.DashOn = 5;
            myPane.YAxis.MajorGrid.DashOff = 5;
            myPane.YAxis.MajorGrid.Color = Color.Gray;
            myPane.YAxis.Color = Color.Gray;
        }

        private void Graw_Draw4(int[] x, int[] y)
        {
            //Получаем линии от графиков
            PointPairList list1 = new PointPairList();

            for (int i = 0; i < 7; i++)
            {
                list1.Add(x[i], y[i]);
            }

            LineItem curve1 = myPane.AddCurve("Shor's method", list1, Color.Blue, SymbolType.None);
            curve1.Line.Width = 2;

            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            zedGraphControl4.AxisChange();
            // Обновляем график
            zedGraphControl4.Invalidate();
        }



        private void test1()
        {
            int N = 0;      
            Random rand = new Random();

            int[] Ntest = { 2, 3, 5, 10, 30, 50, 100 };
            int[] Kstop = new int[7];
            int K = 50; //Количество повторений
            int[] sredK = new int[K];
            int[] sredF = new int[K];
            int[] F = new int[7];
            double a = 0.0;

            for (int i = 0; i < 7; i++)
            {
                Kstop[i] = 0;
                N = Ntest[i];
                ReturnData result1 = new ReturnData(N);
                double[] x0 = new double[N];
                double[] _x0 = new double[N];
                double[] csi = new double[N];
                
                

                for (int j = 0; j < K; j++)
                {
                    for (int k = 0; k < N; k++)
                    {
                        csi[k] = rand.NextDouble() + 000.1;
                        x0[k] = rand.Next(-10, -5);
                    }
                    ShorMethod method1 = new ShorMethod(epsilon, new List<double>(x0), N, 2, new List<double>(csi), Klimitation);
                    result1 = method1.SearchMin();
                    sredK[j] = result1.K;
                    sredF[j] = result1.F;
                    Console.WriteLine(N);
                }
                for (int j = 0; j < K; j++)
                {
                    Kstop[i] += sredK[j];
                    F[i] += sredF[j];
                }
                Kstop[i] /= K;
                F[i] /= K;
            }

            CreateLineGraph1(Klimitation);
            Graw_Draw1(Ntest, Kstop);

            for (int i = 0; i < 6; i++)
                a = Math.Max(F[i], F[i + 1]);

            CreateLineGraph4(a);
            Graw_Draw4(Ntest, F);

        }

        private void test2()
        {
            int N = 10;         
            Random rand = new Random();

            int[] Ntest = { 2, 3, 5, 10, 30, 50, 100 };
            double[] eps = { 0.1, 0.01, 0.001, 0.0001, 0.00001, 0.000001, 0.0000001 };
            double[][] Delta = new double[7][];
            int[][] Kstop = new int[7][];
            for (int i = 0; i < 7; i++)
            {
                Delta[i] = new double[7];
                Kstop[i] = new int[7];
            }
            int K = 50;
            double[] sred = new double[K];
            int[] sredK = new int[K];

            for (int n = 0; n < 7; n++) //для каждого N
            {
                N = Ntest[n];
                ReturnData result1 = new ReturnData(N);
                double[] x0 = new double[N];
                double[] _x0 = new double[N];
                double[] del = new double[N];
                double[] csi = new double[N];
                
                

                for (int i = 0; i < 7; i++) //изменяем eps
                {
                    for (int j = 0; j < N; j++)
                    {
                        csi[j] = rand.NextDouble() + 000.1;
                        x0[j] = rand.Next(-10, -5);
                    }
                    for (int k = 0; k < K; k++) //несколько итераций для усреднения
                    {
                        ShorMethod method1 = new ShorMethod(eps[i], new List<double>(x0), N, 2, new List<double>(csi), Klimitation);
                        result1 = method1.SearchMin();
                        sredK[k] = result1.K;
                        Console.WriteLine(N);
                        for (int j = 0; j < N; j++)
                        {
                            del[j] = 1 - result1.min[j];
                        }
                        sred[k] = method1.normVec(new List<double>(del));
                    }
                    for (int j = 0; j < K; j++)
                    {
                        Delta[i][n] += sred[j];
                        Kstop[i][n] += sredK[j];
                    }
                    Delta[i][n] /= K;
                    Kstop[i][n] /= K;
                }
            }
            CreateLineGraph2();
            Graw_Draw2(eps, Delta);
            CreateLineGraph3(Klimitation);
            Graw_Draw3(eps, Kstop);
        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            // название осей
            zedGraphControl1.GraphPane.Title.Text = "Зависимость K_сред от N ";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Число переменных, N";
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Среднее число шагов, K_сред";

            zedGraphControl2.GraphPane.Title.Text = "Зависимость погрешности от требуемой точности ";
            zedGraphControl2.GraphPane.XAxis.Title.Text = "Логарифм точности, log(1/eps)";
            zedGraphControl2.GraphPane.YAxis.Title.Text = "Логарифм погрешности, log(1/delta)";

            zedGraphControl3.GraphPane.Title.Text = "Зависимость K_сред от требуемой точности ";
            zedGraphControl3.GraphPane.XAxis.Title.Text = "Логарифм точности, log(1/eps)";
            zedGraphControl3.GraphPane.YAxis.Title.Text = "Среднее число шагов, K_сред";

            zedGraphControl4.GraphPane.Title.Text = "Зависимость сложности вычислений от размерности ";
            zedGraphControl4.GraphPane.XAxis.Title.Text = "Размерность, N";
            zedGraphControl4.GraphPane.YAxis.Title.Text = "Сложность вычислений, F";

            textBox1.Text = "1000";
            textBox2.Text = "0,005";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Klimitation = Convert.ToInt32(textBox1.Text);
            epsilon = Convert.ToDouble(textBox2.Text);
            test1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Klimitation = Convert.ToInt32(textBox1.Text);
            test2();
        }
        
        
    }
}
