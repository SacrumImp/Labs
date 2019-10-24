using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Circle : GeoFigure, IPrint //класс круга
    {
        public Double Radius {get; set;}

        public Circle(Double a) { this.Type = "Круг"; this.Radius = a; }

        public override Double Area() { return 3.14 * this.Radius * this.Radius; }

       public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return this.Type + " c радиусом " + this.Radius + " и площадью " + this.Area();
        }
    }
}
