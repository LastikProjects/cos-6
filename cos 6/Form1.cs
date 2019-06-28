using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cos_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int proizv = Convert.ToInt32(textBox1.Text);
            double shag = 0.25;
            int N = 501;//Convert.ToInt32(proizv / shag) + Convert.ToInt32(1 / shag)+1;//4000+4+1
            double[] b = new double[N];
            double[] x = new double[N];
            double[] helpb = new double[N];
            x[0] = -(N-1)/2*shag;
            
            for (int i=0;i<N;i++)
            {
                b[i] = 0;
            }
            for (int i = 1; i < N; i++)
            {
                x[i] = x[i - 1] + shag;
            }

            for (int i = (N - 1) / 2 - 2; i < (N - 1) / 2 - 2 + 6; i++)
            {
                b[i] = 1;
            }
            helpb[0] = 0;
            helpb[1] = 0;
            helpb[N - 1] = 0;
            helpb[N - 2] = 0;
            for (int j=2;j<proizv;j++)
            {
                for(int i=2;i<N-2;i++)
                {
                    helpb[i] = (j + 2 * x[i]) / (2 * (j - 1)) * b[i + 1] + (j - 2 * x[i]) / (2 * (j - 1)) * b[i - 1];
                   
                }
                for (int k = 0; k < N; k++)
                {
                    b[k] = helpb[k];
                }
            }
            chart1.Series[0].Points.Clear();
            for (int i = 3; i < N-3; i++)//по ответу 
                chart1.Series[0].Points.AddXY(x[i], b[i]);
        }
    }
}
