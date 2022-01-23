using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HC5
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 popup = new Form2();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.OK)
            {
                Console.WriteLine("selected");
            }
            
            popup.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

           // string selectedItem = comboBox1.Items[comboBox1.SelectedIndex].ToString();
           // for(int i=0;i<Convert.ToInt32(selectedItem);i++) 



        }
    }
}
