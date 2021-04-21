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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            groupBox4.Visible = false;         
        }
        double[] x = new double[] { 10, 20, 30, 40, 50, 60, 70, 80 };
        double[] y = new double[] { 2.5, 3.2, 3.7, 4.0, 4.2, 4.4, 4.6, 4.75 };

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                linear_interpilation();
            }
            if (radioButton2.Checked)
            {
                kvadra_interpolation();
            }
            if (radioButton3.Checked)
            {
                cubic_interpilation();               
            }        
        }
   
        public void linear_interpilation()
        {         
            this.dataGridView1.Rows.Clear();
            PointPairList list = new PointPairList();
            double[] xx = new double[15];        
            double xx_one = 10;
            for (int i = 0; i < 15; i++)
            {
                xx[i] = xx_one;
                xx_one += 5;
            }
            double[] yy = new double[40];
            alglib.spline1dinterpolant s;
            alglib.spline1dbuildlinear(x, y, out s);          
            for (int i = 0; i < 15; i++)
            {
                yy[i] = alglib.spline1dcalc(s, xx[i]);
            }
            for (int i = 0; i < 15; i++)
            {
                this.dataGridView1.Rows.Add(xx[i], yy[i]);
                list.Add(xx, yy);
            }
        }

        public void kvadra_interpolation()
        {
            this.dataGridView1.Rows.Clear();
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
            double[] xx1 = new double[] { 10, 15, 20, 25, 30 };
            double[] xx2 = new double[] { 30, 35, 40, 45, 50 };
            double[] xx3 = new double[] { 50, 55, 60, 65, 70 };
            double[] xx4 = new double[] { 70, 75, 80 };
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
            PointPairList list1 = new PointPairList();
            PointPairList list2 = new PointPairList();
            PointPairList list3 = new PointPairList();
            PointPairList list4 = new PointPairList();
            for (i = 0; i <= 4; i++)
            {
                this.dataGridView1.Rows.Add(xx1[i], yy1[i]);
                list1.Add(xx1[i], yy1[i]);
            }
            for (i = 1; i <= 4; i++)
            {
                this.dataGridView1.Rows.Add(xx2[i], yy2[i]);
                list2.Add(xx2[i], yy2[i]);
            }
            for (i = 1; i <= 4; i++)
            {
                this.dataGridView1.Rows.Add(xx3[i], yy3[i]);
                list3.Add(xx3[i], yy3[i]);
            }
            for (i = 1; i <= 2; i++)
            {
                this.dataGridView1.Rows.Add(xx4[i], yy4[i]);
                list4.Add(xx4[i], yy4[i]);
            }

            int[] mas_itr = { 1, 2, 3, 4, 5, 6, 7 };
            double[] mas_A = { a1, a1, a2, a2, a3, a3, a4 };
            double[] mas_B = { b1,b1, b2, b2, b3, b3, b4 };
            double[] mas_C = { c1, c1, c2, c2, c3, c3, c4 };
            label5.Text = Convert.ToString("S = A + B*(X-Xi) + C*(X-Xi)^2");
            for (i = 0; i <= 6; i++)
            {
                this.dataGridView2.Rows.Add(mas_itr[i],mas_C[i],mas_B[i],mas_A[i] );           
            }
        }

        public void cubic_interpilation()
        {           
            this.dataGridView1.Rows.Clear();
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
                this.dataGridView1.Rows.Add(xx[i], yy[i]);
                list.Add(xx[i], yy[i]);
            }
            
            alglib.spline1dunpack(s, out int n, out double[,] tbl);
            label5.Text = Convert.ToString("S = A + B*(X-Xi) + C*(X-Xi)^2 + D*(X-Xi)^3");

            int[] mas_itr = { 1, 2, 3, 4, 5, 6, 7 };          
            for (int i = 0; i <= 6; i++)
            {             
                this.dataGridView2.Rows.Add(mas_itr[i], tbl[i, 2], tbl[i,3], tbl[i, 4], tbl[i, 5]);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Form2 form = new Form2();
                form.Show(); 
            }
            if (radioButton2.Checked)
            {
                Form4 form = new Form4();
                form.Show();
            }
            if (radioButton3.Checked)
            {
                Form3 form = new Form3();
                form.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                double x0;
                x0 = Convert.ToDouble(textBox1.Text);
                if (x0 < 10 || x0 > 80)
                {
                    MessageBox.Show("Выход за диапазон значений!\nЗначение должно быть в интервале [10;80]");
                }
                if (x0 > 10 && x0 < 80)
                {
                    double x0_out;
                    alglib.spline1dinterpolant s;
                    alglib.spline1dbuildlinear(x, y, out s);
                    x0_out = alglib.spline1dcalc(s, x0);
                    label3.Text = "y0 = " + Convert.ToString(x0_out);
                }
            }
            if (radioButton2.Checked)
            {
                double[] yy1 = new double[15];
                double[] yy2 = new double[15];
                double[] yy3 = new double[15];
                double[] yy4 = new double[15];
                double a1, b1, c1;
                double a2, b2, c2;
                double a3, b3, c3;
                double a4, b4, c4;
                double x0, x0_out;
                x0 = Convert.ToDouble(textBox1.Text);
                if (x0 < 10 || x0 > 80)
                {
                    MessageBox.Show("Выход за диапазон значений!\nЗначение должно быть в интервале [10;80]");
                }
                if (x0 > 10 && x0 < 80)
                {
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
                    if (x0 <= 30 && x0 >= 10)
                    {
                        x0_out = a1 * Math.Pow(x0, 2) + b1 * x0 + c1;
                        label3.Text = "y0 = " + Convert.ToString(x0_out);
                    }
                    if (x0 <= 50 && x0 >= 30)
                    {
                        x0_out = a2 * Math.Pow(x0, 2) + b2 * x0 + c2;
                        label3.Text = "y0 = " + Convert.ToString(x0_out);
                    }
                    if (x0 <= 70 && x0 >= 50)
                    {
                        x0_out = a3 * Math.Pow(x0, 2) + b3 * x0 + c3;
                        label3.Text = "y0 = " + Convert.ToString(x0_out);
                    }
                    if (x0 <= 80 && x0 >= 70)
                    {
                        x0_out = a4 * Math.Pow(x0, 2) + b4 * x0 + c4;
                        label3.Text = "y0 = " + Convert.ToString(x0_out);
                    }
                }
            }
            if (radioButton3.Checked)
            {
                double x0;
                x0 = Convert.ToDouble(textBox1.Text);
                if (x0 < 10 || x0 > 80)
                {
                    MessageBox.Show("Выход за диапазон значений!\nЗначение должно быть в интервале [10;80]");
                }
                if (x0 > 10 && x0 < 80)
                {
                    double x0_out;
                    alglib.spline1dinterpolant s;
                    alglib.spline1dbuildcubic(x, y, out s);
                    x0_out = alglib.spline1dcalc(s, x0);
                    label3.Text = "y0 = " + Convert.ToString(x0_out);
                }
            }        
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox4.Visible = false;
            label3.Text = null;
            textBox1.Clear();
            dataGridView2.Rows.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label3.Text = null;
            textBox1.Clear();
            dataGridView1.Rows.Clear();
            label4.Text = null;
            label5.Text = null;
            groupBox4.Visible = true;
            dataGridView2.Rows.Clear();
            dataGridView2.Columns[4].Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label5.Text = null;
            groupBox4.Visible = true;
            label3.Text = null;
            textBox1.Clear();
            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns[4].Visible = true;
            label4.Text = null;
        }      
    }
}