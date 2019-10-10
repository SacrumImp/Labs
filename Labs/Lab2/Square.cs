﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Square : Rectangle, IPrint //класс квадрата
    {
        public Square(Double a) : base(a, a) { this.Type = "Квадрат"; }

        public override Double Area() { return this.Height * this.Width; }

        public void Print()
        {
            Console.WriteLine(this.ToString());
        }
    }
}