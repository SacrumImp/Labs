using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Card //класс дл карт
    {
        public String name;
        [MyAttribute("Описание для номера карты")] //атрибут для карты
        public int id { get; set; } //свойство (выводится, так как есть атрибут)
        public int paramWithoutAttr { get; set; } //свойство для тестирования (не выводится, так как нет атрибута)
        public string currency;
        private double money = 0;

        public Card() { }
        public Card(String str, int id) 
        {
            this.name = str;
            this.id = id;
        }
        public void setValue(int val, string cur) 
        {
            this.currency = cur.ToUpper();
            this.money = val;
        }
        public void ChangetoUSD()
        {
            if(this.currency == "RUB")
            {
                this.currency = "USD";
                this.money *= 64;
            }
            else
            {
                Console.WriteLine("Ошибка!");
            }
        }
        public void ChangetoRUB()
        {
            if (this.currency == "USD")
            {
                this.currency = "RUB";
                this.money /= 64;
            }
            else
            {
                Console.WriteLine("Ошибка!");
            }
        }
        public void Print() 
        {
            Console.WriteLine("\tВладилец карты: {0}\n\tВалюта: {1}\n\tОбщая сумма: {2}", this.name, this.currency, this.money);
        }
    }

    public class MyAttribute : Attribute //класс атрибутов
    {
        public MyAttribute() { }
        public MyAttribute(string DescriptionParam) { Description = DescriptionParam; }
        public string Description { get; set; }
    }
}
