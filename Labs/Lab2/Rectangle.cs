using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Rectangle : GeoFigure, IPrint //класс прямоугольника 
    {
        public Double Height { get; set; }
        public Double Width { get; set; }

        public Rectangle(Double a, Double b){ this.Type = "Прямоугольник"; this.Height = a; this.Width = b;}

        public override Double Area() { return this.Height * this.Width; }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

    }
}
