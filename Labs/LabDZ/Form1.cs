using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text;
using Lab5;
<<<<<<< HEAD
using System.Threading;
using System.Threading.Tasks;
=======
>>>>>>> 4c4024f7dbf2d4384ecdcffdef9a3f3796d2cf69

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

<<<<<<< HEAD
        public static List<ParallelSearchResult> ArrayThreadTask(object paramObj)
        {
            ParallelSearchThreadParam param = (ParallelSearchThreadParam)paramObj;

            //Слово для поиска в верхнем регистре
            string wordUpper = param.wordPattern.Trim().ToUpper();

            //Результаты поиска в одном потоке
            List<ParallelSearchResult> Result = new List<ParallelSearchResult>();

            //Перебор всех слов во временном списке данного потока 
            foreach (string str in param.tempList)
            {
                //Вычисление расстояния Дамерау-Левенштейна
                int dist = Levenstayn.findDistance(str.ToUpper(), wordUpper);

                //Если расстояние меньше порогового, то слово добавляется в результат
                if (dist <= param.maxDist)
                {
                    ParallelSearchResult temp = new ParallelSearchResult()
                    {
                        word = str
                    };

                    Result.Add(temp);
                }
            }
            return Result;
        }

=======
>>>>>>> 4c4024f7dbf2d4384ecdcffdef9a3f3796d2cf69
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
<<<<<<< HEAD

=======
>>>>>>> 4c4024f7dbf2d4384ecdcffdef9a3f3796d2cf69
        private void button2_Click(object sender, EventArgs e)
        {
            string find;
            find = textBox2.Text.ToUpper();
            label3.ForeColor = Color.Black;
            Stopwatch t = new Stopwatch();

<<<<<<< HEAD
=======
            Levenstayn Lev = new Levenstayn();
>>>>>>> 4c4024f7dbf2d4384ecdcffdef9a3f3796d2cf69
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
<<<<<<< HEAD
            else if(channels.Checked)
            {
                int nCh = 1;
                if (int.TryParse(textBox4.Text, out nCh)) nCh = int.Parse(textBox4.Text);
                if (nCh > words.Count) nCh = words.Count; //итоговое количество потоков

                int n = words.Count / nCh;
                if ((words.Count % nCh) != 0) n++;

                List<ParallelSearchResult> Result = new List<ParallelSearchResult>(); //итоговый список
                List<MinMax> arrayDivList = SubArrays.DivideSubArrays(0, words.Count, nCh); //деление списка
                int count = arrayDivList.Count;
                Task<List<ParallelSearchResult>>[] tasks = new Task<List<ParallelSearchResult>>[count]; //инициализация потоков

                if (find != "")
                {
                    label3.ForeColor = Color.Red;
                    label3.Text = "Слово не найдено!";

                    listBox1.BeginUpdate();
                    listBox1.Items.Clear();

                    for (int i = 0; i < nCh; i++)
                    {
                        List<string> tempTaskList = words.GetRange(arrayDivList[i].Min, arrayDivList[i].Max - arrayDivList[i].Min); //временный список

                        tasks[i] = new Task<List<ParallelSearchResult>>(
                        ArrayThreadTask,
                        new ParallelSearchThreadParam()
                        {
                            tempList = tempTaskList,
                            maxDist = maxDis,
                            ThreadNum = i,
                            wordPattern = find
                        });

                        tasks[i].Start();

                    }

                    Task.WaitAll(tasks);

                    for (int i = 0; i < count; i++)
                    {
                        Result.AddRange(tasks[i].Result);
                    } //объединение результатов

                    foreach (var x in Result)
                    {
                        this.listBox1.Items.Add(x.word);
                    } //вывод результатов

                    if(listBox1.Items != null)
                    {
                        label3.ForeColor = Color.Green;
                        label3.Text = "Слово найдено!";
                    }

                    listBox1.EndUpdate();

                    //сохранение в файл
                    string TempReportFileName = "Найденные_слова";
                    SaveFileDialog fd = new SaveFileDialog();
                    fd.FileName = TempReportFileName;
                    fd.DefaultExt = ".html";
                    fd.Filter = "HTML Reports|*.html";

                    if (fd.ShowDialog() == DialogResult.OK)
                    {
                        string ReportFileName = fd.FileName;

                        StringBuilder b = new StringBuilder();

                        foreach (var x in this.listBox1.Items)
                        {
                            b.AppendLine("<li>" + x.ToString() + "</li>");
                        }

                        File.AppendAllText(ReportFileName, b.ToString());
                    }
                }
                else
                {
                    label3.ForeColor = Color.Red;
                    label3.Text = "Слово не введено!";
                }
            }
=======
            else if(!channels.Checked)
>>>>>>> 4c4024f7dbf2d4384ecdcffdef9a3f3796d2cf69
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
<<<<<<< HEAD
                        dis = Levenstayn.findDistance(str.ToUpper(), find);
=======
                        dis = Lev.findDistance(str.ToUpper(), find);
>>>>>>> 4c4024f7dbf2d4384ecdcffdef9a3f3796d2cf69
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
