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
using System.IO;

namespace kursach_kuv
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            GraphPane pane = zed.GraphPane;
            pane.CurveList.Clear();
            pane.XAxis.Title = "x";
            pane.YAxis.Title = "y";
            pane.Title = "Кубический сплайн";
            double[] x = new double[] { 10, 20, 30, 40, 50, 60, 70, 80 };
            double[] y = new double[] { 2.5, 3.2, 3.7, 4.0, 4.2, 4.4, 4.6, 4.75 };
            PointPairList list = new PointPairList();
            double[] xx = new double[15];
            double x_one = 10;
            for (int i = 0; i < 15; i++)
            {
                xx[i] = x_one;
                x_one += 5;
            }
            double[] yy = new double[40];
            alglib.spline1dinterpolant s;
            alglib.spline1dbuildcubic(x, y, out s);
            for (int i = 0; i < 15; i++)
            {
                yy[i] = alglib.spline1dcalc(s, xx[i]);
            }
            for (int i = 0; i < 15; i++)
            {              
                list.Add(xx[i], yy[i]);
            }
            PointPairList list1 = new PointPairList();
            for (int i = 0; i <= 7; i++)
            {
                list1.Add(x[i], y[i]);
            }
            LineItem myCurve1 = pane.AddCurve("", list, Color.Blue, SymbolType.None);//линия     
            LineItem myCurve12 = pane.AddCurve("", list1, Color.Red, SymbolType.Circle);//точки
            myCurve12.Line.IsVisible = false;
            myCurve12.Symbol.Size = 3;//размер точек
            myCurve12.Symbol.Fill.Color = Color.Red;//заливка точек
            myCurve12.Symbol.Fill.Type = FillType.Solid;//сплошная заливка 
            zed.AxisChange();
            zed.Invalidate();//обновляем график
        }
    }
}
