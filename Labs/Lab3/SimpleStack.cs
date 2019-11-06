using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.SimpleList;

namespace Lab3
{
    class SimpleStack<T> : SimpleList<T> where T : IComparable  //стек
    {
        public void Push(T elem) //добавление нового элемента
        {
            Add(elem); //использование метода класса SimpleList
        }

        public T Pop()
        {
            T elem = default(T); //значение элемента в случае если список стек пуст

            if (this.Count == 0) return elem; //результат при пустом стеке
            if (this.Count == 1) //результат при стеке сосотящем из одного элемента
            {
                elem = this.first.data;
                this.first = null;
                this.last = null;
            }
            else //резульат при стеке, содержащим несколько элементов
            {
                SimpleListItem<T> newLast = this.GetItem(this.Count - 2);
                elem = newLast.next.data;
                this.last = newLast; //удаление извлеченного элемента
                newLast.next = null;
            }
            this.Count--;
            return elem;
        }
    }
}
