using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4
{
    class ParallelSearchThreadParam //параметры параллельного поиска
    {
        public List<string> tempList { get; set; } //список слов

        public string wordPattern { get; set; } //слово для поиска

        public int maxDist { get; set; } //расстояние Левенштейна

        public int ThreadNum { get; set; } //номер потока
    }
}
