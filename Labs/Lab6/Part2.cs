using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    class Card
    {
        public String name;
        public int id;
        public string currency;
        private double money;

        public Card() { }
        public Card(String str, int id) { }
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
}
