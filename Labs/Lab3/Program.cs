using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Алпеев Владислав ИУ5-34Б";

            Circle cir = new Circle(5);
            cir.Print();
            Rectangle rect = new Rectangle(3, 6);   //экземпляры классов для коллекции
            rect.Print();
            Square sqr = new Square(2);
            sqr.Print();

            Console.WriteLine("\n\tArrayList");
            ArrayList Arr = new ArrayList();    //коллекция ArrayList
            Arr.Add(rect);
            Arr.Add(sqr);
            Arr.Add(cir);
            foreach (GeoFigure obj in Arr) Console.WriteLine(obj.Area());

            Console.WriteLine("\n\tList");
            List<GeoFigure> Lis = new List<GeoFigure>(); //коллекция класса List
            GeoFigure buf;
            Lis.Add(rect);
            Lis.Add(sqr);
            Lis.Add(cir);
            for (int i = 0; i < Lis.Count; i++) //сортировка
                for (int j = 0; j < (Lis.Count - (i + 1)); j++)
                {
                    if (Lis[j].CompareTo(Lis[j + 1]) == 1)
                    {
                        buf = Lis[j];
                        Lis[j] = Lis[j + 1];
                        Lis[j + 1] = buf;
                    }
                }
            foreach (GeoFigure obj in Lis) Console.WriteLine(obj.Area());

            Console.WriteLine("\n\tMatrix");
            Matrix<GeoFigure> matr = new Matrix<GeoFigure>(3, 3, 3); //пример использования матрицы
            matr[1, 1, 0] = rect;
            matr[1, 1, 2] = sqr;
            matr[2, 2, 1] = cir;
            Console.WriteLine(matr.ToString());

            Console.WriteLine("\n\tSimpleStack");
            SimpleStack<GeoFigure> stack = new SimpleStack<GeoFigure>();
            stack.Push(rect);
            stack.Push(sqr);
            stack.Push(cir);
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());
            Console.WriteLine(stack.Pop());

            Console.ReadKey();
        }
    }
}
