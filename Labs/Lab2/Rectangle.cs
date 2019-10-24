using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Rectangle : GeoFigure, IPrint //класс прямоугольника 
    {
        public Double Height { get; set; }
        public Double Width { get; set; }

        public Rectangle(Double a, Double b){ this.Type = "Прямоугольник"; this.Height = a; this.Width = b;}

        public override Double Area() { return this.Height * this.Width; }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return this.Type + " с высотой " + this.Height + ", шириной " + this.Width + " и площадью " + this.Area();
        }

    }
}
