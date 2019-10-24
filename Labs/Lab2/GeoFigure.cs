using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    abstract public class GeoFigure: IComparable //абстрактный класс геометрических фигур
    {
        public String Type { get; set; } //название фигуры

        public virtual Double Area() { return 0;} //виртульный метод для нахождения площади

        public int CompareTo(object a)
        {
            GeoFigure Fig = (GeoFigure)a;

            if (this.Area() < Fig.Area()) return -1;
            else if (this.Area() == Fig.Area()) return 0;
            else return 1;
        }
    }
}
