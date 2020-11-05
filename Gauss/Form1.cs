using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gauss
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_solve_Click(object sender, EventArgs e)
        {
            double[,] A = new double[3, 3];
            double[] B = new double[3];
            double[] R = new double[3];

            A[0, 0] = double.Parse(textBox_A11.Text);
            A[0, 1] = double.Parse(textBox_A12.Text);
            A[0, 2] = double.Parse(textBox_A13.Text);
            A[1, 0] = double.Parse(textBox_A21.Text);
            A[1, 1] = double.Parse(textBox_A22.Text);
            A[1, 2] = double.Parse(textBox_A23.Text);
            A[2, 0] = double.Parse(textBox_A31.Text);
            A[2, 1] = double.Parse(textBox_A32.Text);
            A[2, 2] = double.Parse(textBox_A33.Text);

            B[0] = double.Parse(textBox_B1.Text);
            B[1] = double.Parse(textBox_B2.Text);
            B[2] = double.Parse(textBox_B3.Text);

            for (int i=1; i<3; i++)
            {
                double C = A[i, 0] / A[0, 0];
                for (int j=0; j<3; j++)
                {
                    A[i, j] -= (C * A[0, j]);
                }
                B[i] -= (C * B[0]);
            }

            double D = A[2, 1] / A[1, 1];
            for (int j=1; j<3; j++)
            {
                A[2, j] -= (D * A[1, j]);
            }
            B[2] -= (D * B[1]);

            R[2] = B[2] / A[2, 2];
            R[1] = (B[1] - A[1, 2] * R[2]) / A[1, 1];
            R[0] = (B[0] - A[0, 2] * R[2] - A[0, 1] * R[1]) / A[0, 0];

            textBox_R1.Text = R[0].ToString();
            textBox_R2.Text = R[1].ToString();
            textBox_R3.Text = R[2].ToString();
        }
    }
}
