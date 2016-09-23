using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程的Join方法学习
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread t1 = new Thread(Print);
            t1.Name = "线程一";
            t1.Start();
            t1.Join();

            Thread t2 = new Thread(Print);
            t2.Name = "线程二";
            t2.Start();

        }

        static void Print()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("我是线程{0}", Thread.CurrentThread.Name);
            }
           
        }
    }
}
