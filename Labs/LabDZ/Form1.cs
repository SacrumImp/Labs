using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text;
using Lab5;

namespace Lab4
{
    public partial class Form1 : Form
    {
        List<string> words = new List<string>();
        static char[] seps = new char[] { ' ', '|', '\n', ',', '.', ':', '\t', ';' , '\r' , '-', '\"', '\'', '?', '!', '—' };

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fi = new OpenFileDialog();
            fi.Filter = "|*.txt";
            Stopwatch t = new Stopwatch();

            if (fi.ShowDialog() == DialogResult.OK)
            {
                t.Start();
                string data = File.ReadAllText(fi.FileName, Encoding.GetEncoding(1251));
                string[] elems;
                elems = data.Split(seps, StringSplitOptions.RemoveEmptyEntries);
                foreach(string element in elems)
                {
                    if (!words.Contains(element))
                    {
                        words.Add(element);
                    }
                }

                t.Stop();
                textBox1.Text = t.Elapsed.ToString();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            string find;
            find = textBox2.Text.ToUpper();
            label3.ForeColor = Color.Black;
            Stopwatch t = new Stopwatch();

            Levenstayn Lev = new Levenstayn();
            int dis;
            int maxDis;
            if (int.TryParse(textBox5.Text, out maxDis)) maxDis = int.Parse(textBox5.Text);

            if (!checkBox1.Checked)
            {
                t.Start();
                if (find != "")
                {
                    label3.ForeColor = Color.Red;
                    label3.Text = "Слово не найдено!";

                    listBox1.BeginUpdate();
                    listBox1.Items.Clear();

                    foreach (string str in words)
                    {
                        if (str.ToUpper().Contains(find))
                        {
                            label3.ForeColor = Color.Green;
                            label3.Text = "Слово найдено!";
                            listBox1.Items.Add(str);
                        }
                    }
                    listBox1.EndUpdate();
                }
                else
                {
                    label3.ForeColor = Color.Red;
                    label3.Text = "Слово не введено!";
                }
                t.Stop();
                textBox3.Text = t.Elapsed.ToString();
            }
            else if(!channels.Checked)
            else
            {
                if (find != "")
                {
                    label3.ForeColor = Color.Red;
                    label3.Text = "Слово не найдено!";

                    listBox1.BeginUpdate();
                    listBox1.Items.Clear();

                    foreach (string str in words)
                    {
                        dis = Lev.findDistance(str.ToUpper(), find);
                        if (!(int.TryParse(textBox5.Text, out maxDis)) || (dis <= maxDis))
                        {
                            label3.ForeColor = Color.Green;
                            label3.Text = "Слово найдено!";

                            listBox1.Items.Add(str);
                        }
                    }
                    listBox1.EndUpdate();
                }
                else
                {
                    label3.ForeColor = Color.Red;
                    label3.Text = "Слово не введено!";
                }
            }
        }
    }
}
