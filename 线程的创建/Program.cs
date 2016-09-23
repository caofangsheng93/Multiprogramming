using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程的创建
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个线程[方式一]
            Thread t1 = new Thread(Print);
            t1.Start();

            //创建一个线程[方式二]
            Thread t2 = new Thread(new ThreadStart(Print2));
            t2.Start();

            //创建一个线程[方式三]
            Thread t3 = new Thread(new ParameterizedThreadStart(Print3));
            t3.Start("ParameterizedThreadStart delegate");

            //创建一个线程【方式四】
            Thread t4 = new Thread(delegate()
                {
                    Print3("哇哈哈哈");
                }
            );
            t4.Start();

            //创建一个线程【方式五】
            Thread t5 = new Thread(() => Print3("lambda expression"));
            t5.Start();

        }
        static void Print()
        {
            Console.WriteLine("我通过Thread类创建的");
        }

        static void Print2()
        {
            Console.WriteLine("我通过ThreadStart delegate创建");
        }

        static void Print3(object obj)
        {
            Console.WriteLine("我通过{0}创建",obj);
        }
    }
}
