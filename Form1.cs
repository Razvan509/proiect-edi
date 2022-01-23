using HC5;
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

        private void formsPlot1_Load(object sender, EventArgs e)
        {
            double[] xs = new double[] { 1, 2, 3, 4, 5 };
            double[] ys = new double[] { 1, 4, 9, 16, 25 };
            formsPlot1.Plot.AddScatter(xs, ys);
            formsPlot1.Plot.AddVerticalLine(1);
            formsPlot1.Plot.AddVerticalLine(2);
            formsPlot1.Plot.AddVerticalLine(5, Color.Black);
            formsPlot1.Refresh();
        }

        private void straturiSelectate_DoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine(straturiSelectate.SelectedItem);
            
            straturiSelectate.Items.RemoveAt(straturiSelectate.SelectedIndex);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            StraturiModel stratSelectat = listaStructuri.SelectedItem as StraturiModel;
            if (!stratSelectat.id.Equals("-1"))
            {
                straturiSelectate.Items.Add(stratSelectat);
            }

        }

        List<StraturiModel> data = new List<StraturiModel>();
            

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
            data.Add(new StraturiModel("-1", "Selectati un strat", 0, 0));
            data.Add(new StraturiModel("1", "Beton armat", 0.15, 1.74));
            data.Add(new StraturiModel("2", "BCA", 0.3, 0.27));
            data.Add(new StraturiModel("3", "Mortar de ciment", 0.02, 0.93));
            data.Add(new StraturiModel("4", "Mortar de ciment si var", 0.03, 0.87));

            listaStructuri.DataSource = data;
            listaStructuri.DropDownStyle = ComboBoxStyle.DropDownList;

        }
       
        public void button1_Click(object sender, EventArgs e)
        {

            

        }

        public List<double> CalculRezistente(StraturiModel[]straturi)
        {
            List<double> rezistente = new List<double>();
            foreach(StraturiModel m in straturi)
            {
                double r = m.grosime / m.lambda;
                rezistente.Add(r);
            }
            return rezistente;
        }


        public double CalculculRT(List<double> rezistente)
        {
            return rsi + rse + rezistente.Aggregate((x, y) => x + y);
        }

        public double CalculTSI(double ti, double te, double rt)
        {
            return ti - (rsi * (ti - te)) / rt;
        }

        public List<double> CalculTheta(double ti, double te, double rt, List<double> rezistente)
        {
            List<double> thetas = new List<double>();
            double sumaRezistente = 0;

            foreach(double r in rezistente)
            {
                sumaRezistente += r;
                double t = ti - ((rsi + sumaRezistente) * (ti - te)) / rt;
                thetas.Add(t);
            }
            return thetas;
        }
      
        

    }
}
