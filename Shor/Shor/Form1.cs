using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Shor
{


    public partial class Form1 : Form
    {
            static public double []pt;
	        static double XMin, XMax,YMin,YMax;

        static Rosenbrock F;
        static ShorMethod shor;

        static List<double> x;
        static List<double> ksi;

        struct Node
    {
        public  double x;
        public	double y;
        public 	double Q;
    }

        public Form1()
        {
            InitializeComponent();
        }

         class eque_lines
    {
    Node [] pDat;
	double []  pQ;
	int N; // число разбиений сетки
	int M; // общее число уровней
	int M1; // число основных узлов
	int M2; // число подуузлов
	int M3; // число "подподузлов"

    double m1;
    double m2;
    double c1;
    double c2;
    double[] w1 = new double[2];
    double[] w2 = new double[2];
    Random ran;


    public eque_lines()
    {
      ran = new Random();
      ksi = new List<double>();
      for (int i = 0; i < 2; i++)
            ksi.Add(0.01 + ran.NextDouble());
       pDat = null; 
       pQ = null;
       F = new Rosenbrock(2, ksi);
    }

	public void CreateDat(int _N,  int _M1, int _M2, int _M3)
	{
		N = _N;
		M1 = _M1;
		M2 = _M2;
		M3 = _M3;
		M = M1 + M2 + M3 - 1;

	//	DelDat();
		if ( ( pDat = new Node[(N+1)*(N+1)] ) == null )
			return;
		else
			if ( ( pQ = new double[M+1] ) == null)
				return;
	}
    public void CreateDat1(double _m1, double _m2, double _c1, double _c2, double[] _w1, double[] _w2)
    {
        m1 = _m1;
        m2 = _m2;
        c1 = _c1;
        c2 = _c2;
        w1 = _w1;
        w2 = _w2;
    }
    public void SetDat(double _a0, double _b0, double _a1, double _b1, bool UseGKLS)
    {
        if (pDat == null || pQ == null)
            return;
        else
        {
            double Qmin, Qmax, QQ;
            int i, j; // номер узла
            double hx = (_b0 - _a0) / N; // вычисление шага по x
            double hy = (_b1 - _a1) / N; // вычисление шага по y
            double[] x_p = new double[2];
            // обход сетки
            pt = new double[2];
            Qmin = 1.7976931348623158e+308;
            Qmax = 2.2250738585072014e-308;
            for (i = 0; i <= N; i++)
                for (j = 0; j <= N; j++)
                {
                    // заполнение структуры сетки
                    // координаты узла сетки
                    x_p[0] = pDat[(N + 1) * i + j].x = _a0 + hx * i;
                    x_p[1] = pDat[(N + 1) * i + j].y = _a1 + hy * j;
                    // значение функции в узле
                    pt[0] = x_p[0];
                    pt[1] = x_p[1];
                    List <double> _pt = new List<double>(pt);
                    QQ = pDat[(N + 1) * i + j].Q = F.getSum(_pt);

                    //		printf("QQ = %f\n",QQ);
                    // поиск минимального и максимального значения на сетке
                    if ((i == 0) && (j == 0) || (Qmin > QQ))
                        Qmin = QQ;
                    if ((i == 0) && (j == 0) || (Qmax < QQ))
                        Qmax = QQ;
                }
            double hQ1 = (Qmax - Qmin) / M1; // шаг функции по уровням
            int ku = 0; // позиция в сетке уровней   
            for (i = 0; i < M1; i++) // вычисление значений функции на основных уровнях 
                pQ[ku++] = Qmax - hQ1 * i;

            double hQ2 = hQ1 / (M2 + 1); // шаг функции по подуровням
            for (i = 1; i <= M2; i++) // вычисление значений функции на подуровнях
                pQ[ku++] = pQ[M1 - 1] - hQ2 * i;

            for (i = 1; i <= M3; i++) // вычисление значений функции на "под-подуровнях"
                pQ[ku++] = pQ[M1 + M2 - 1] - (hQ2 / (M3 + 1)) * i;

        }

    }

public void SendLines(Graphics g, PictureBox pic)
	{
	int i,j,u,s;
    for( i = 0; i < N; i++)
		for( j = 0; j < N; j++)
		{	 
			for( u = 0; u <= M; u++)
			{
				double Qu = pQ[u];// Уровень
				double [] x = new double[5];
                double [] y= new double[5];//Соединяемые точки
				int kt=0;// Количество соединяемых точек
				double x0,x1,y0,y1,Q0,Q1;
				
				//Нижняя сторона
				x0=pDat[(N+1)*i+j].x; 
				x1=pDat[(N+1)*(i+1)+j].x;
				y0=pDat[(N+1)*i+j].y;
				Q0=pDat[(N+1)*i+j].Q; 
				Q1=pDat[(N+1)*(i+1)+j].Q;
				if ( (Q0-Qu)*(Qu-Q1) >= 0 && (Q1 != Q0) )
				{
					y[kt]= y0;
					x[kt++]= x0+(x1-x0)*(Qu-Q0)/(Q1-Q0);
				}
				
				//Левая сторона
				x0=pDat[(N+1)*i+j].x;
				y0=pDat[(N+1)*i+j].y;
				y1=pDat[(N+1)*i+j+1].y;
				Q0=pDat[(N+1)*i+j].Q;
				Q1=pDat[(N+1)*i+j+1].Q;
				if ( (Q0-Qu)*(Qu-Q1) >= 0 && (Q1 != Q0) )
				{ 
					x[kt]= x0;
					y[kt++]= y0+(y1-y0)*(Qu-Q0)/(Q1-Q0);
				}
				
				//Верхняя сторона
				x0=pDat[(N+1)*i+j+1].x;
				x1=pDat[(N+1)*(i+1)+j+1].x;
				y0=pDat[(N+1)*i+j+1].y;
				Q0=pDat[(N+1)*i+j+1].Q;
				Q1=pDat[(N+1)*(i+1)+j+1].Q;
				if ( (Q0-Qu)*(Qu-Q1) >= 0 && (Q1 != Q0) )
				{ 
					y[kt]= y0;
					x[kt++]= x0+(x1-x0)*(Qu-Q0)/(Q1-Q0);
				}
				
				//Правая сторона
				x0=pDat[(N+1)*(i+1)+j].x;
				y0=pDat[(N+1)*(i+1)+j].y;
				y1=pDat[(N+1)*(i+1)+j+1].y;
				Q0=pDat[(N+1)*(i+1)+j].Q;
				Q1=pDat[(N+1)*(i+1)+j+1].Q;
				if ( (Q0-Qu)*(Qu-Q1) >= 0 && (Q1 != Q0) )
				{ 
					x[kt]= x0;
					y[kt++]= y0+(y1-y0)*(Qu-Q0)/(Q1-Q0);
				}

				if ( kt > 0 ) //Прорисовка линии
				{
					if ( u < M1 )
					{
						for( s=0; s<kt-1; s++)
						{
							Pen p = new Pen(Color.DimGray,2);
							g.DrawLine(p, (float)((x[s] - XMin)/(XMax - XMin) * (pic.Width-1)),(float)((YMax - y[s])/(YMax - YMin)* (pic.Height-1)),(float)((x[s+1] - XMin)/(XMax - XMin) * (pic.Width-1)),(float)((YMax - y[s+1])/(YMax - YMin)* (pic.Height-1)));
						//	printf("Drawed Line\n");

						}
					}
					else if ( u < M1 + M2 )
					{
						for( s=0; s<kt-1; s++)
						{
							Pen p = new Pen(Color.DimGray,2);
							g.DrawLine(p,(float)((x[s] - XMin)/(XMax - XMin) * (pic.Width-1)),(float)((YMax - y[s])/(YMax - YMin)* (pic.Height-1)),(float)((x[s+1] - XMin)/(XMax - XMin) * (pic.Width-1)),(float)((YMax - y[s+1])/(YMax - YMin)* (pic.Height-1)));
						//	printf("Drawed Line\n");
						}
					}
					else
					{
						for( s=0; s<kt-1; s++)
						{
							Pen p = new Pen(Color.DimGray,2);
							g.DrawLine(p,(float)((x[s] - XMin)/(XMax - XMin) * (pic.Width-1)),(float)((YMax - y[s])/(YMax - YMin)* (pic.Height-1)),(float)((x[s+1] - XMin)/(XMax - XMin) * (pic.Width-1)),(float)((YMax - y[s+1])/(YMax - YMin)* (pic.Height-1)));
						//	printf("Drawed Line\n");
						}
					}
				}
				//Конец прорисовки линии уровня Qu
			}//Конец перебора всех Qu
		}
	}

            public List<double> sendMin(Graphics g, PictureBox pic)
            {
                if (XMax != 0 || XMin != 0)
                {
                    List<List<double>> xs = shor.SearchMin();
                    Pen p = new Pen(Color.Green, 2);
                    for (int i = 0; i < xs.Count - 1; i++)
                    {
                        g.DrawLine(p, (float)((xs[i][0] - XMin) / (XMax - XMin) * (pic.Width - 1)), (float)((YMax - xs[i][1]) / (YMax - YMin) * (pic.Height - 1)), (float)((xs[i+1][0] - XMin) / (XMax - XMin) * (pic.Width - 1)), (float)((YMax - xs[i+1][1]) / (YMax - YMin) * (pic.Height - 1)));
                        

                    }
                    List<double> xopt = new List<double>();
                    xopt.Add(xs[xs.Count - 1][0]);
                    xopt.Add(xs[xs.Count - 1][1]);
                    return xopt;
                }
                return null;
            }
        }
        

        eque_lines Draw_Line = new eque_lines();
        private void button1_Click(object sender, EventArgs e)
        {
             int _N = System.Convert.ToInt32(DL_N.Text);
			 int _M1 =  System.Convert.ToInt32(DL_M1.Text);
			 int _M2 = System.Convert.ToInt32(DL_M2.Text);
			 int _M3 =  System.Convert.ToInt32(DL_M3.Text);
			 Draw_Line.CreateDat(_N,_M1,_M2,_M3);
			 XMin =  System.Convert.ToDouble(xmin_t.Text);
			 XMax =  System.Convert.ToDouble(xmax_t.Text);
			 YMin =   System.Convert.ToDouble(ymin_t.Text);
			 YMax =  System.Convert.ToDouble(ymax_t.Text);
             double X0 = System.Convert.ToDouble(x0.Text);
             double Y0 = System.Convert.ToDouble(y0.Text);
             double epcilon = System.Convert.ToDouble(epc.Text);

            x = new List<double>(2) { X0, Y0 };
            shor = new ShorMethod(epcilon, x, 2, System.Convert.ToInt32(alfa.Text), ksi, 200);

            Draw_Line.SetDat(XMin,XMax,YMin,YMax,false);
			 pic.Invalidate();

        }

        private void pic_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.Default;
            Draw_Line.SendLines(e.Graphics, pic);
            List<double> xopt = Draw_Line.sendMin(e.Graphics, pic);
            if (xopt != null) {
                minx.Text = System.Convert.ToString(xopt[0]);
                miny.Text = System.Convert.ToString(xopt[1]);
            }
                        
        }

        

   }
}
