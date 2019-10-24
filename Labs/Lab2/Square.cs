using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    public class Square : Rectangle, IPrint //класс квадрата
    {
        public Square(Double a) : base(a, a) { this.Type = "Квадрат"; }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }

        public override string ToString()
        {
            return this.Type + " с длиной стороны " + this.Height + " и площадью " + this.Area();
        }
    }
}
