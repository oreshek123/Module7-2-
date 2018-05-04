using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace module7
{

    public class Money
    {
        //индексация
        public  Random random = new Random();
        public List<int> curency = new List<int>();
        public int this[int index]
        {
            get { return curency[index]; }
        }
        public Money(decimal amount, string unit)
        {
            Amount = amount;
            Unit = unit;
            for (int i = 0; i < random.Next() ; i++)
            {
                curency.Add((random.Next(0,100)));
            }
        }
        public decimal Amount { get; set; }
        public string Unit { get; set; }

        public static Money operator +(Money a, Money b)
        {
            if (b.Unit == "USD")
            {
                a.Amount += b.Amount * 330;
            }
            else
            if (b.Unit == "RUB")
            {
                a.Amount += b.Amount * 5;
            }
            else
            if (b.Unit == "EUR")
            {
                a.Amount += b.Amount * 420;
            }
            else Console.WriteLine("Неизвестная валюта");

            return new Money(a.Amount+b.Amount, a.Unit);
        }

        public static bool operator ==(Money a, Money b)
        {
            if (a.Amount == b.Amount && a.Unit == b.Unit)
            {
                return true;
            }
            else return false;
        }
        public static bool operator !=(Money a, Money b)
        {
            if (a.Amount == b.Amount && a.Unit == b.Unit)
            {
                return false;
            }
            else return true;
        }

        public override string ToString()
        {
            return string.Format("Amount = {0} ({1})", this.Amount, this.Unit);
        }
    }

    public class Pointer:IComparable
    {
        public int CompareTo(object o)
        {
            if (o is Pointer)
            {
                Pointer p = (Pointer) o;
                if (this.X > p.X)
                    return 1;
                if (this.X < p.X)
                    return -1;
                else
                    return 0;
            }
            else throw new ArgumentException();
        }
        public int X { get; set; }
        public int Y { get; set; }

        public Pointer(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return string.Format("[{0},{1}]", this.X, this.Y);
        }

        public static Pointer operator +(Pointer p1, Pointer p2)
        {
            return new Pointer(p1.X+p2.X, p1.Y+p2.Y);
        }

        public static Pointer operator +(Pointer p, int change)
        {
            return new Pointer(p.X +change, p.Y+change);
        }

        public static Pointer operator ++(Pointer p)
        {
            return new Pointer(p.X+1, p.Y+1);
        }

        public override bool Equals(object obj)
        {
            return obj.ToString() == this.ToString();
        }// идет всегда вместе с gethashcode и сравнивает объекты
        public override int GetHashCode()
        {
            var test = this.ToString().GetHashCode();
            return this.ToString().GetHashCode();
        }

        public static bool operator ==(Pointer p, Pointer p2)
        {
            if (p.X > p2.X) return true;
            else return false;

        }
        public static bool operator !=(Pointer p, Pointer p2)
        {
            if (p.X < p2.X) return true;
            else return false;

        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Money kzt = new Money(100, "KZT");

            Money usd = new Money(100, "KZT");

            if (kzt == usd)
            {
                Console.WriteLine("нормас");
            }
            else if (kzt != usd) Console.WriteLine("плохо");
            //Money m = new Money(100, "KZT");
            //Console.WriteLine(m.curency[1]);

            //Console.WriteLine(sum());

            //Pointer p1 = new Pointer(100,100);
            ////p1 = p1 + 5;
            //Pointer p2 = new Pointer(100,100);
            //if (p1.CompareTo(p2)== 0)
            //{
            //    Console.WriteLine("Классы идентичны");
            //}
            //p1.GetHashCode();
            //Pointer pRresult = p1 + p2;
            //Console.WriteLine(pRresult);
            Console.ReadLine();
        }

        static Money sum(Money usd = null, Money kzt = null)
        {
            if (kzt == null)
            kzt = new Money(100,"KZT");
            if (usd == null)
            usd = new Money(30000, "USD");


            return kzt + usd;
         
        }
    }
}
