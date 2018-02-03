using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace Eigenvalues
{
    public partial class Form1 : Form
    {
        Label[,] L;
        double[,] A;
        double[] B;
        double[,] UL;
        int n;
        int m1;
        int m2;
        int m3;
        int Ypos = 0;
        bool a;
        public Form1()
        {
            InitializeComponent();
        }

        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text != "" && Convert.ToInt32(metroTextBox1.Text) > 1)
            {
                a = true;
                n = Convert.ToInt32(metroTextBox1.Text);
                A = new double[n, n];
                B = new double[n];
                UL = new double[n, n];
                L = new Label[n, n + 1];
                m1 = 0;
                m2 = 0;
                m3 = 0;

                
                label3.Text = "Элемент [1,1] =";
                
            }
            else
            {
                MessageBox.Show("Введите корректное число элементов!");
                metroTextBox1.Focus();

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        static bool Ce(string s)
        {
            bool T = true;
            for (int i = 1; i <= s.Length - 1; i++)
            {
                if (s[i] == '-')
                {
                    T = false;
                }
            }
            return T;
        }
        static int Len(string s, char ch)
        {
            int k = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == ch)
                {
                    k += 1;
                }
            }

            return k;
        }
        private void metroButton2_Click(object sender, EventArgs e)
        {
            if (metroTextBox3.Text != "")
            {
                if (metroTextBox3.Text[0] != ',' && metroTextBox3.Text[metroTextBox3.Text.Length - 1] != ',')
                {
                    if (Len(metroTextBox3.Text, ',') <= 1 && Ce(metroTextBox3.Text))
                    {
                        if (metroTextBox3.Text != "" && metroTextBox3.Text != "-")
                        {
                            if (a)
                            {
                                L[m1, m2] = new Label();

                                L[m1, m2].Parent = panel1;
                                L[m1, m2].Left = (50 * m2) + 20;
                                L[m1, m2].Top = 100 + 25 * m1;
                                string str;
                                if (Convert.ToDouble(metroTextBox3.Text) >= 0)
                                {
                                    str = "+";
                                }
                                else
                                {
                                    str = "-";
                                }
                                double g = Convert.ToDouble(metroTextBox3.Text);
                                if (m2 > n - 1 || (m2 == 0 && g >= 0)) { L[m1, m2].Text = "   " + Convert.ToString(Math.Abs(Convert.ToDouble(metroTextBox3.Text))) + "x" + Convert.ToString(m2 + 1); }
                                else L[m1, m2].Text = str + "   " + Convert.ToString(Math.Abs(Convert.ToDouble(metroTextBox3.Text))) + "x" + Convert.ToString(m2 + 1);
                                L[m1, m2].Width = 50;
                                A[m1, m2] = Convert.ToDouble(metroTextBox3.Text);


                                if (m1 == n - 1 && m2 == n - 1)
                                {


                                    label3.Text = "Элемент b[" + Convert.ToString(m3 + 1) + "] =";

                                    for (int i = 0; i <= n - 1; i++)
                                    {
                                        Label LL = new Label();
                                        LL.Parent = panel1;
                                        LL.Left = 50 * n + 20;
                                        LL.Top = 100 + 25 * i;
                                        LL.Text = "=";
                                        LL.Width = 10;
                                    }
                                    a = false;
                                }
                                else

                                    if (m2 == n - 1 && m1 != n - 1)
                                {
                                    m2 = 0;
                                    m1 += 1;
                                    label3.Text = "Элемент [" + Convert.ToString(m1 + 1) + "," + Convert.ToString(m2 + 1) + "]=";
                                }
                                else
                                {
                                    m2 += 1;
                                    label3.Text = "Элемент [" + Convert.ToString(m1 + 1) + "," + Convert.ToString(m2 + 1) + "]=";

                                }



                                metroTextBox3.Focus();
                                metroTextBox3.Text = "";

                            }
                            else
                            {
                                L[m3, n] = new Label();
                                L[m3, n].Parent = panel1;
                                L[m3, n].Left = 50 * n + 50;
                                L[m3, n].Top = 100 + 25 * m3;
                                L[m3, n].Text = metroTextBox3.Text;
                                L[m3, n].Width = 40;
                                B[m3] = Convert.ToDouble(metroTextBox3.Text);


                                if (m3 == n - 1)
                                {
                                    label3.Text = "Элемент [1,1] =";
                                    
                                    groupBox2.Visible = false;
                                    metroTextBox3.Enabled = false;
                                    

                                }
                                else
                                {
                                    m3 += 1;
                                    label3.Text = "Элемент b[" + Convert.ToString(m3 + 1) + "] =";

                                    metroTextBox3.Focus();
                                    metroTextBox3.Text = "";

                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Введите элемент!");
                        }
                    }
                    else
                    {
                        metroTextBox3.Text = "";
                        MessageBox.Show("Не корректный формат данных, эжжи!!!");
                        metroTextBox3.Focus();
                    }
                }
                else
                {
                    metroTextBox3.Text = "";
                    MessageBox.Show("Не корректный формат данных, эжжи!!!");
                    metroTextBox3.Focus();
                }
            }
            else
            {
                metroTextBox3.Text = "";
                MessageBox.Show("Не корректный формат данных, эжжи!!!");
                metroTextBox3.Focus();
            }
        }
    }
}
