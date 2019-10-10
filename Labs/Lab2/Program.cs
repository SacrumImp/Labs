using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            GeoFigure fig;
            int i;
            string buf;
            Double a = 0, b = 0;

            Console.Title = "Алпеев Владислав ИУ5-34Б";
            Console.Write("Какую фигуру вы ходите создать? \n1 - Прямоугольник.\n2 - Квадрат.\n3 - Круг.\nВведите номер фигуры: ");

            while (!int.TryParse(buf = Console.ReadLine(), out i))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Номер введен неправильно. Введите номер повторно: ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            i = int.Parse(buf);


            switch (i)
            {
                case 1:
                    Console.Write("Введите высоту фигуры: ");
                    a = Double.Parse(Console.ReadLine());
                    Console.Write("Введите ширину фигуры: ");
                    b = Double.Parse(Console.ReadLine());
                    fig = new Rectangle(a, b);
                    break;
                case 2:
                    Console.Write("Введите высоту фигуры: ");
                    a = Double.Parse(Console.ReadLine());
                    fig = new Square(a); break;
                case 3:
                    Console.Write("Введите радиус фигуры: ");
                    a = Double.Parse(Console.ReadLine());
                    fig = new Circle(a); break;
                default: fig = new Rectangle(0, 0); break;
            }
            Console.WriteLine(fig.ToString() + "\n");

            Rectangle fig1 = new Rectangle(2, 3);
            fig1.Print();
            Square fig2 = new Square(2);
            fig2.Print();
            Circle fig3 = new Circle(2);
            fig3.Print();
            Console.ReadKey();
        }
    }
}
