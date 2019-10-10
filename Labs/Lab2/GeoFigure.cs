﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    abstract class GeoFigure //абстрактный класс геометрических фигур
    {
        public String Type { get; set; } //название фигуры

        public virtual Double Area() { return 0;} //виртульный метод для нахождения площади

        public override string ToString() 
        {
            return this.Type + " с площадью: " + this.Area();
        }
    }
}