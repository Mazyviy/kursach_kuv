using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ZedGraph;

namespace kursach_kuv
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            double[] x = new double[] { 10, 20, 30, 40, 50, 60, 70, 80 };
            double[] y = new double[] { 2.5, 3.2, 3.7, 4.0, 4.2, 4.4, 4.6, 4.75 };
            double[] yy1 = new double[15];
            double[] yy2 = new double[15];
            double[] yy3 = new double[15];
            double[] yy4 = new double[15];
            int i;
            double a1, b1, c1;
            double a2, b2, c2;
            double a3, b3, c3;
            double a4, b4, c4;         
            a1 = ((y[2] - y[0]) * (x[1] - x[0]) - (y[1] - y[0]) * (x[2] - x[0])) / ((Math.Pow(x[2], 2) - Math.Pow(x[0], 2)) * (x[1] - x[0]) - (Math.Pow(x[1], 2) - Math.Pow(x[0], 2)) * (x[2] - x[0]));
            b1 = (y[1] - y[0] - a1 * (Math.Pow(x[1], 2) - Math.Pow(x[0], 2))) / (x[1] - x[0]);
            c1 = y[0] - (a1 * Math.Pow(x[0], 2) + b1 * x[0]);
            a2 = ((y[4] - y[2]) * (x[3] - x[2]) - (y[3] - y[2]) * (x[4] - x[2])) / ((Math.Pow(x[4], 2) - Math.Pow(x[2], 2)) * (x[3] - x[2]) - (Math.Pow(x[3], 2) - Math.Pow(x[2], 2)) * (x[4] - x[2]));
            b2 = (y[3] - y[2] - a2 * (Math.Pow(x[3], 2) - Math.Pow(x[2], 2))) / (x[3] - x[2]);
            c2 = y[2] - (a2 * Math.Pow(x[2], 2) + b2 * x[2]);
            a3 = ((y[6] - y[4]) * (x[5] - x[4]) - (y[5] - y[4]) * (x[6] - x[4])) / ((Math.Pow(x[6], 2) - Math.Pow(x[4], 2)) * (x[5] - x[4]) - (Math.Pow(x[5], 2) - Math.Pow(x[4], 2)) * (x[6] - x[4]));
            b3 = (y[5] - y[4] - a3 * (Math.Pow(x[5], 2) - Math.Pow(x[4], 2))) / (x[5] - x[4]);
            c3 = y[4] - (a3 * Math.Pow(x[4], 2) + b3 * x[4]);
            a4 = ((y[7] - y[5]) * (x[6] - x[5]) - (y[6] - y[5]) * (x[7] - x[5])) / ((Math.Pow(x[7], 2) - Math.Pow(x[5], 2)) * (x[6] - x[5]) - (Math.Pow(x[6], 2) - Math.Pow(x[5], 2)) * (x[7] - x[5]));
            b4 = (y[6] - y[5] - a4 * (Math.Pow(x[6], 2) - Math.Pow(x[5], 2))) / (x[6] - x[5]);
            c4 = y[5] - (a4 * Math.Pow(x[5], 2) + b4 * x[5]);
            double[] xx1 = new double[] { 10,15, 20,25, 30 };
            double[] xx2 = new double[] { 30, 35, 40, 45, 50 };
            double[] xx3 = new double[] { 50, 55, 60, 65, 70 };
            double[] xx4 = new double[] { 70,75, 80 };
            for (i = 0; i <= 4; i++)
            {
                yy1[i] = a1 * Math.Pow(xx1[i], 2) + b1 * xx1[i] + c1;
            }
            for (i = 0; i <= 4; i++)
            {
                yy2[i] = a2 * Math.Pow(xx2[i], 2) + b2 * xx2[i] + c2;
            }
            for (i = 0; i <= 4; i++)
            {
                yy3[i] = a3 * Math.Pow(xx3[i], 2) + b3 * xx3[i] + c3;
            }
            for (i = 0; i <= 2; i++)
            {
                yy4[i] = a4 * Math.Pow(xx4[i], 2) + b4 * xx4[i] + c4;
            }
            GraphPane pane = zed.GraphPane;
            pane.CurveList.Clear();
            pane.XAxis.Title = "x";
            pane.YAxis.Title = "y";
            pane.Title = "Квадратичный сплайн";
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();
            for (i = 0; i <= 4; i++)
            {              
                list1.Add(xx1[i], yy1[i]);
            }
            for (i = 0; i <= 4; i++)
            {
                list2.Add(xx2[i], yy2[i]);
            }
            for (i = 0; i <= 4; i++)
            {
                list3.Add(xx3[i], yy3[i]);
            }
            for (i = 0; i <= 2; i++)
            {
                list4.Add(xx4[i], yy4[i]);
            }
            LineItem myCurve1 = pane.AddCurve("", list1, Color.Blue, SymbolType.None);//линия
            LineItem myCurve2 = pane.AddCurve("", list2, Color.Blue, SymbolType.None);//линия
            LineItem myCurve3 = pane.AddCurve("", list3, Color.Blue, SymbolType.None);//линия
            LineItem myCurve4 = pane.AddCurve("", list4, Color.Blue, SymbolType.None);//линия
            PointPairList list5 = new PointPairList();
            for ( i = 0; i <= 7; i++)
            {
                list5.Add(x[i], y[i]);
            }       
            LineItem myCurve5 = pane.AddCurve("", list5, Color.Red, SymbolType.Circle);//точки
            myCurve5.Line.IsVisible = false;
            myCurve5.Symbol.Size = 3;//размер точек
            myCurve5.Symbol.Fill.Color = Color.Red;//заливка точек
            myCurve5.Symbol.Fill.Type = FillType.Solid;//сплошная заливка   
            zed.AxisChange();
            zed.Invalidate();//обновляем график
        }
    }
}
