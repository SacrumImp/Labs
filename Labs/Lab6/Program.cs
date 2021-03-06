﻿using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Program
    {

        delegate int Compare(int p1, string p2); //делегат

        static int CompareEq(int p1, string p2) //метод, соответствующий делегату
        {
            int p2i;
            if(int.TryParse(p2, out p2i))
            {
                p2i = int.Parse(p2);
                if (p1 == p2i) return 1;
                else return 0;
            }
            else
            {
                return -1;
            }
        }

        static void Write(int n, Compare comparator) //метод, получающий параметр-делегат
        {
            string str;
            int res;

            Console.Write("Введите строку для сравнения: ");
            str = Console.ReadLine();
            res = comparator(n, str);

            if(res == 1)
            {
                Console.Write("Выражение верно.");
            }
            else if (res == 0) 
            {
                Console.Write("Выражение неверно.");
            }
            else
            {
                Console.Write("Выражение некорректно.");
            }
        }

        static void WriteF(int n, Func<int, string, int> comparator) //метод, получающий параметр-Func<>
        {
            string str;
            int res;

            Console.Write("Введите строку для сравнения: ");
            str = Console.ReadLine();
            res = comparator(n, str);

            if (res == 1)
            {
                Console.Write("Выражение верно.");
            }
            else if (res == 0)
            {
                Console.Write("Выражение неверно.");
            }
            else
            {
                Console.Write("Выражение некорректно.");
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "Алпеев Владислав ИУ5-34Б";
            int i = 6;
            Console.Write("Пример:\nЧисло для сравнения: {0}\nПередача метода в качестве параметра-делегата: \n\t", i);
            Write(i, CompareEq); //вызов метода с параметром-делегатом
            Console.Write("\nПередача лямбда-выражения в качестве параметра-делегата: \n\t");
            Write(i, 
                (int p1, string p2) =>
                {
                    int p2i;
                    if (int.TryParse(p2, out p2i))
                    {
                        p2i = int.Parse(p2);
                        if (p1 == p2i) return 1;
                        else return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
                );
            Console.Write("\nИспользование в качестве параметра обобщенного делегата:\nПередача метода в качестве параметра-делегата: \n\t");
            WriteF(i, CompareEq); //вызов метода с параметром-делегатом
            Console.Write("\nПередача лямбда-выражения в качестве параметра-делегата: \n\t");
            WriteF(i,
                (int p1, string p2) =>
                {
                    int p2i;
                    if (int.TryParse(p2, out p2i))
                    {
                        p2i = int.Parse(p2);
                        if (p1 == p2i) return 1;
                        else return 0;
                    }
                    else
                    {
                        return -1;
                    }
                }
                );

            //вторая часть 

            Type c = typeof(Card);
            Console.WriteLine("\n\n\tИнформация о классе Card:");
            Console.WriteLine("Находится в сборке " + c.AssemblyQualifiedName);
            Console.WriteLine("Пространство имен " + c.Namespace);
            Console.WriteLine("Тип " + c.FullName);

            Console.WriteLine("\n\tПоля данных (public):");
            foreach (var x in c.GetFields()) { Console.WriteLine(x); }

            Console.WriteLine("\n\tСвойства:");
            foreach (var x in c.GetProperties()) //вывод свойств, имеющих атрибуты
            {
                var findAttribute = x.GetCustomAttributes(false);
                if (findAttribute.Length > 0) 
                {
                    MyAttribute attr = findAttribute[0] as MyAttribute;
                    Console.WriteLine("{0} - {1}", x, attr.Description);
                } 
            }

            Console.WriteLine("\n\tКонструкторы:"); 
            foreach (var x in c.GetConstructors()) { Console.WriteLine(x); }

            Console.WriteLine("\n\tМетоды:"); 
            foreach (var x in c.GetMethods()) { Console.WriteLine(x); }

            Console.WriteLine("\n\tВызов метода с использованием рефлексии: ");
            Card card1 = new Card("MyName", 12345);
            card1.setValue(100, "RUB"); //новый экземпляр класса
            c.InvokeMember("ChangetoUSD", BindingFlags.InvokeMethod, null, card1, null); //вызов функции при помощи рефлексии
            Console.WriteLine("ChangetoUSD():");
            card1.Print();

            Console.ReadKey();
        }
    }
}
