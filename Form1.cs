using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HC2
{
    public partial class Form1 : Form
    {

        double d1, d2, d3, d4, l1, l2, l3, l4, r1, r2, r3, r4, rt, tsi, t1, t2, t3, tse,k;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        int ti = 20, te = -15;
        double rsi = 0.125;
        double rse = 0.042;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
       
        public void button1_Click(object sender, EventArgs e)
        {

            k = 200 / (Math.Abs(ti) - Math.Abs(te));
            textBox27.Text = Convert.ToString(k); 
            d1 = Convert.ToDouble(textBox1.Text);
            d2 = Convert.ToDouble(textBox2.Text);
            d3 = Convert.ToDouble(textBox3.Text);
            d4 = Convert.ToDouble(textBox4.Text);
            l1 = Convert.ToDouble(textBox5.Text);
            l2 = Convert.ToDouble(textBox6.Text);
            l3 = Convert.ToDouble(textBox7.Text);
            l4 = Convert.ToDouble(textBox8.Text);
            r1 = d1 / l1;
            r2 = d2 / l2;
            r3 = d3 / l3;
            r4 = d4 / l4;
            rt = rsi + r1 + r2 + r3 + r4 + rse;
            textBox14.Text = Convert.ToString(rt);
            textBox15.Text = Convert.ToString(r1);
            textBox16.Text = Convert.ToString(r2);
            textBox17.Text = Convert.ToString(r3);
            textBox18.Text = Convert.ToString(r4);
            tsi = ti - (rsi * (ti - te)) / rt;
            t1 = ti - ((rsi + r1) * (ti - te)) / rt;
            t2 = ti - ((rsi + r1 + r2) * (ti - te)) / rt;
            t3 = ti - ((rsi + r1 + r2 + r3) * (ti - te)) / rt;
            tse = ti - ((rsi + r1 + r2 + r3 + r4) * (ti - te)) / rt;
            textBox9.Text = Convert.ToString(tsi);
            textBox10.Text = Convert.ToString(t1);
            textBox11.Text = Convert.ToString(t2);
            textBox12.Text = Convert.ToString(t3);
            textBox13.Text = Convert.ToString(tse);

            d1 *= 15;
            d2 *= 15;
            d3 *= 15;
            d4 *= 15;

            textBox19.Text = Convert.ToString(d1);
            textBox20.Text = Convert.ToString(d2);
            textBox21.Text = Convert.ToString(d3);
            textBox22.Text = Convert.ToString(d4);

            double dg1 = d1 +40*d1;
            double dg2 = d1+50 * d1 + d2+50 * d2;
            double dg3 = d1 + 50 * d1 + d2 + 50 * d2+d3 + 50 * d3;
            double dg4 = d1 + 50 * d1 + d2 + 50 * d2 + d3 + 50 * d3 + d4+50* d4;
            textBox23.Text = Convert.ToString(dg1);
            textBox24.Text = Convert.ToString(dg2);
            textBox25.Text = Convert.ToString(dg3);
            textBox26.Text = Convert.ToString(dg4);
            Graphics dc = drawingArea.CreateGraphics();
            Pen BlackPen = new Pen(Color.Black, 3);
            Pen RedPen = new Pen(Color.Red, 2);
           
            dc.DrawLine(BlackPen, 50, 0, 50, 200);
            dc.DrawLine(BlackPen, Convert.ToInt32(dg1)+50, 0, Convert.ToInt32(dg1)+50, 200);
            dc.DrawLine(BlackPen, Convert.ToInt32(dg2)+50, 0, Convert.ToInt32(dg2)+50, 200);
            dc.DrawLine(BlackPen, Convert.ToInt32(dg3)+50, 0, Convert.ToInt32(dg3)+50, 200);
            dc.DrawLine(BlackPen, Convert.ToInt32(dg4)+50, 0, Convert.ToInt32(dg4)+50, 200);

            dc.DrawLine(RedPen, 0, 0, 50, 0);
            dc.DrawLine(RedPen, 50, 10, Convert.ToInt32(dg1)+50, 16);
            dc.DrawLine(RedPen, Convert.ToInt32(dg1)+50, 16, Convert.ToInt32(dg2)+50, 20);
            dc.DrawLine(RedPen, Convert.ToInt32(dg2)+50, 20, Convert.ToInt32(dg3)+50, 165);
            dc.DrawLine(RedPen, Convert.ToInt32(dg3)+50, 165, Convert.ToInt32(dg4)+50, 180);
            dc.DrawLine(RedPen, Convert.ToInt32(dg4)+50, 185, 400, 185);

            BlackPen.Dispose();
            dc.Dispose();

        }

      
        

    }
}
