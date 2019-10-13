using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Алпеев Владислав ИУ5-34Б";
            Double[] Arg = new Double[3]; //массив аргументов
            String re; //буфер для работы с данными, введенными с клавиатуры
            Double bf; //буфер для работы с корнями

            if (args.Length != 0)
            {
                for (int i = 0; i < 3; i++)
                {
                    if ((args.Length > i) && Double.TryParse(args[i], out Arg[i]))
                    {
                        Arg[i] = Double.Parse(args[i]);
                    }
                    else
                    {
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Коэффициент {0} введен неверно! \nВведите корректное значение: ", (char)(i+65));
                            Console.ForegroundColor = ConsoleColor.White;
                            re = Console.ReadLine();
                        } while (!Double.TryParse(re, out Arg[i]));
                        Arg[i] = Double.Parse(re);
                    }
                }
            } //ввод коэффициентов из параметров командной строки
            else
            {
                for(int i = 0; i < 3; i++)
                {
                    Console.Write("Введите коэффициент {0}: ", (char)(i + 65));
                    re = Console.ReadLine();
                    if (Double.TryParse(re, out Arg[i]))
                    {
                        Arg[i] = Double.Parse(re);
                    }
                    else
                    {
                        do
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Коэффициент {0} введен неверно! \nВведите корректное значение: ", (char)(i + 65));
                            Console.ForegroundColor = ConsoleColor.White;
                            re = Console.ReadLine();
                        } while (!Double.TryParse(re, out Arg[i]));
                        Arg[i] = Double.Parse(re);
                    }
                }
            } //ввод коэффициентов после запуска программы

            double dec;
            dec = Arg[1] * Arg[1] - 4 * Arg[0] * Arg[2]; //вычисление дискриминанта
            ArrayList roots = new ArrayList(); //корни уравнения

            if (Arg[0] == 0 && Arg[1] == 0)
            {
                Console.Write("Корни уравнения: ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Корней нет!");
                Console.ForegroundColor = ConsoleColor.White;
            } // случай, когда коэффициенты A и B равны 0
            else if(Arg[0] == 0){
                bf = -Arg[2] / Arg[1];
                if (bf > 0)
                {
                    roots.Add(Math.Sqrt(bf));
                    if (bf != 0) roots.Add(-Math.Sqrt(bf));
                }
                Console.Write("Корни уравнения: ");
                if (roots.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int i = 0; i < roots.Count; i++)
                    {
                        Console.Write("{0} ", roots[i]);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Корней нет!");
                }
                Console.ForegroundColor = ConsoleColor.White;
            } //случай, когда коэффициент A равен 0
            else
            {
                if (dec >= 0)
                {
                    dec = Math.Sqrt(dec);
                    bf = (-Arg[1] - dec) / (2 * Arg[0]);
                    if (bf >= 0)
                    {
                        roots.Add(Math.Sqrt(bf));
                        if(bf != 0) roots.Add(-Math.Sqrt(bf));
                    }

                    if (dec != 0)
                    {
                        bf = (-Arg[1] + dec) / (2 * Arg[0]);
                        if (bf > 0)
                        {
                            roots.Add(Math.Sqrt(bf));
                            if (bf != 0) roots.Add(-Math.Sqrt(bf));
                        }
                    }
                } //дискриминант больше равен нулю

                Console.Write("Корни уравнения: ");
                if (roots.Count > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    for (int i = 0; i < roots.Count; i++)
                    {
                        Console.Write("{0} ", roots[i]);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Корней нет!");
                }
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.ReadKey();
        }
    }
}
