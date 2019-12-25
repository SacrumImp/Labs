using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4
{
    public static class SubArrays //деление списка
    {
        public static List<MinMax> DivideSubArrays(int beginIndex, int endIndex, int subArraysCount)
        {
            List<MinMax> result = new List<MinMax>(); //список индексов

            if ((endIndex - beginIndex) <= subArraysCount)
            {
                result.Add(new MinMax(0, (endIndex - beginIndex)));
            }
            else
            {
                int delta = (endIndex - beginIndex) / subArraysCount; //размер подсписка
                int currentBegin = beginIndex;
                while ((endIndex - currentBegin) >= 2 * delta)
                {
                    result.Add(new MinMax(currentBegin, currentBegin + delta));
                    currentBegin += delta;
                }
                result.Add(new MinMax(currentBegin, endIndex));
            }
            return result;
        }
    }
}
