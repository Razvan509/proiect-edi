using HC5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HC2
{
    public partial class Form1 : Form
    {

        int ti = 20, te = -15;
        double rsi = 0.125;
        double rse = 0.042;

        private void button2_Click(object sender, EventArgs e)
        {
            if(straturiSelectate.Items.Count > 0)
            {
                List<StraturiModel> straturi = new List<StraturiModel>();
                foreach(object item in straturiSelectate.Items)
                {
                    StraturiModel strat = item as StraturiModel;
                    straturi.Add(strat);
                }
                List<double> rezistente = CalculRezistente(straturi);
                double rt = CalculculRT(rezistente);
                double tsi = CalculTSI(ti, te, rt);
                List<double> theta = CalculTheta(ti, te, rt, rezistente);

                double[] xs = new double[straturi.Count + 5];
                double[] ys = new double[straturi.Count + 5];

                xs[0] = 0;
                ys[0] = ti;
                xs[1] = 0.5;
                ys[1] = ti;
                xs[2] = 0.5;
                ys[2] = tsi;

                Console.Write(0.5);
                Console.Write(", ");
                Console.WriteLine(tsi);

                for (int i = 0; i < theta.Count; i++)
                {
                    xs[i + 3] = straturi[i].grosime + xs[i + 2];
                    ys[i + 3] = theta[i];

                    Console.Write(xs[i+3]);
                    Console.Write(", ");
                    Console.WriteLine(ys[i+3]);
                }


                xs[straturi.Count + 3] = xs[straturi.Count + 2];
                ys[straturi.Count + 3] = te;

                xs[straturi.Count + 4] = xs[straturi.Count + 2] + 0.5;
                ys[straturi.Count + 4] = te;

                formsPlot1.Plot.AddScatter(xs, ys, Color.Red, Width=2);

                for (int i = 1; i < xs.Length - 1; i++)
                {
                    if (xs[i] != xs[i - 1])
                    {
                        formsPlot1.Plot.AddVerticalLine(xs[i], Color.Black, Width = 2);
                    }

                }
                formsPlot1.Refresh();
            }
            

        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {
            /*double[] xs = new double[] { 1.4, 2, 3, 4, 5 };
            double[] ys = new double[] { 1, 4, 9, 16, 25 };
            formsPlot1.Plot.AddScatter(xs, ys);
            formsPlot1.Plot.AddVerticalLine(1);
            formsPlot1.Plot.AddVerticalLine(2);
            formsPlot1.Plot.AddVerticalLine(5, Color.Black);
            formsPlot1.Refresh();*/
        }

        private void straturiSelectate_DoubleClick(object sender, EventArgs e)
        {
            Console.WriteLine(straturiSelectate.SelectedItem);
            
            straturiSelectate.Items.RemoveAt(straturiSelectate.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e)
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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectToDatabase = ("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = D:\\projects\\HC5\\Database1.mdf; Integrated Security = True");
            SqlConnection connectDatabase = new SqlConnection(connectToDatabase);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Strat", connectDatabase);
            cmd.Connection = connectDatabase;

            connectDatabase.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    data.Add(new StraturiModel(reader.GetInt32(0),
                        reader.GetString(1), reader.GetDouble(2), reader.GetDouble(3)));
                }
            }
            else
            {
                Console.WriteLine("No rows found.");
            }
            reader.Close();
            connectDatabase.Close();


            /*data.Add(new StraturiModel("-1", "Selectati un strat", 0, 0));
            data.Add(new StraturiModel("1", "Beton armat", 0.15, 1.74));
            data.Add(new StraturiModel("2", "BCA", 0.02, 0.3));
            data.Add(new StraturiModel("3", "Mortar de ciment", 0.08, 0.04));
            data.Add(new StraturiModel("4", "Mortar de ciment si var", 0.10, 1.74));
            data.Add(new StraturiModel("5", "Tencuiala", 0.0002, 0.3)); */

            listaStructuri.DataSource = data;
            listaStructuri.DropDownStyle = ComboBoxStyle.DropDownList;
        }
       

        public List<double> CalculRezistente(List<StraturiModel> straturi)
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
