﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eigenvalues
{

    public partial class Form1 : Form
    {
        Label[,] L;
        double[,] A;
        double[] B;
        double[] V;
        double[,] UL;
        double N;
        int n;
        int pog;
        int m1;
        int m2;
        int m3;
        int Ypos = 0;
        bool a;
        public Form1()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
        public static void WriteLine(string shapka, ref int Y0, ref Panel panel)
        {
            Label lab = new Label();

            lab.Parent = panel;
            lab.Left = 20;
            lab.Top = Y0+75;

            lab.Text = shapka;
            lab.Width = 500;
            lab.Height = 13;

            Y0 += 50;
        }
        public static void FindX(double[] b, double[] c, double n)
        {
            for (int i = 1; i < b.Length; i++)
            {
                c[i] = b[i] / n;
            }
        }
        public static string FindY(double[,] b, double[] c)
        {
            string v = Convert.ToString(1);
            for (int i = 1; i < b.Length; i++)
            {
                for (int j = 1; j < c.Length - 1; j++)
                {
                    v = Convert.ToString(b[i, j] * c[j]);

                }
            }
            return v;
        }

        public static double LenghtV(double[] b )
        {
            double n = 0;
            for (int i = 1; i <= b.Length - 1; i++)
            {
                n = b[i] * b[i] + n;
            }
            n = Math.Sqrt(n);
            return n;

        }
        
        static bool Long (string s)
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
       

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text != "" && Convert.ToInt32(textBox1.Text) > 1 && textBox2.Text != "")
            {
                WriteLine("Матрица А и Нулевое приближение собственного вектора Y: ", ref Ypos, ref panel1);
                a = true;
                n = Convert.ToInt32(textBox1.Text);
                A = new double[n, n];
                B = new double[n];
                UL = new double[n, n];
                L = new Label[n, n + 1];
                pog = Convert.ToInt32(textBox2.Text);
                m1 = 0;
                m2 = 0;
                m3 = 0;

                groupBox2.Visible = true;
                button2.Visible = true;
                button2.Enabled = true;
                textBox3.Enabled = true;
                textBox3.Text = "";
                label3.Text = "Элемент [1,1] =";
                textBox3.Focus();
                button1.Enabled = false;


            }
            else
            {
                MessageBox.Show("Введите корректное число элементов!");
                textBox1.Focus();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox3.Text != "")
            {
                if (textBox3.Text[0] != ',' && textBox3.Text[textBox3.Text.Length - 1] != ',')
                {
                    if (Len(textBox3.Text, ',') <= 1 && Ce(textBox3.Text))
                    {
                        if (textBox3.Text != "" && textBox3.Text != "-")
                        {
                            if (a)
                            {
                                L[m1, m2] = new Label();

                                L[m1, m2].Parent = panel1;
                                L[m1, m2].Left = (50 * m2) + 20;
                                L[m1, m2].Top = 100 + 25 * m1;
                                string str;
                                if (Convert.ToDouble(textBox3.Text) >= 0)
                                {
                                    str = " ";
                                }
                                else
                                {
                                    str = "-";
                                }
                                double g = Convert.ToDouble(textBox3.Text);
                                if (m2 > n - 1 || (m2 == 0 && g >= 0)) { L[m1, m2].Text = "   " + Convert.ToString(Math.Abs(Convert.ToDouble(textBox3.Text))); }
                                else L[m1, m2].Text = str + "   " + Convert.ToString(Math.Abs(Convert.ToDouble(textBox3.Text)));
                                L[m1, m2].Width = 50;
                                A[m1, m2] = Convert.ToDouble(textBox3.Text);


                                if (m1 == n - 1 && m2 == n - 1)
                                {

                                    textBox3.Left = 297;
                                    button2.Left = 394;
                                    label3.Text = "Нулевое приближение собственного вектора Y[" + Convert.ToString(m3 + 1) + "] =";

                                    for (int i = 0; i <= n - 1; i++)
                                    {
                                        Label LL = new Label();
                                        LL.Parent = panel1;
                                        LL.Left = 50 * n + 20;
                                        LL.Top = 100 + 25 * i;
                                        LL.Text = "I";
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



                                textBox3.Focus();
                                textBox3.Text = "";

                            }
                            else
                            {
                                L[m3, n] = new Label();
                                L[m3, n].Parent = panel1;
                                L[m3, n].Left = 50 * n + 50;
                                L[m3, n].Top = 100 + 25 * m3;
                                L[m3, n].Text = textBox3.Text;
                                L[m3, n].Width = 40;
                                B[m3] = Convert.ToDouble(textBox3.Text);
                                


                                if (m3 == n - 1)
                                {
                                    label3.Text = "Элемент [1,1] =";

                                    groupBox2.Visible = false;
                                    textBox3.Enabled = false;


                                }
                                else
                                {

                                    m3 += 1;
                                    label3.Text = "Нулевое приближение собственного вектора Y[" + Convert.ToString(m3 + 1) + "] =";

                                    textBox3.Focus();
                                    textBox3.Text = "";

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
                        textBox3.Text = "";
                        MessageBox.Show("Не корректный формат данных, эжжи!!!");
                        textBox3.Focus();
                    }
                }
                else
                {
                    textBox3.Text = "";
                    MessageBox.Show("Не корректный формат данных, эжжи!!!");
                    textBox3.Focus();
                }
            }
            else
            {
                textBox3.Text = "";
                MessageBox.Show("Не корректный формат данных, эжжи!!!");
                textBox3.Focus();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }

            if (number == 13)
                {
                    button1_Click(this, EventArgs.Empty);
                }
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8 && number != 44 && number != 45)
            {
                e.Handled = true;
            }

            if (e.KeyChar == 13)
            {
                button2_Click(this, EventArgs.Empty);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }

            if (number == 13)
            {
                button1_Click(this, EventArgs.Empty);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            V = new double[n];
            N =LenghtV(B);
            FindX(B, V, N);
            for(int i=0;i<V.Length;i++)
            {
                label4.Text += Convert.ToString(Math.Round(V[i]));
            }
        }
    }
}
