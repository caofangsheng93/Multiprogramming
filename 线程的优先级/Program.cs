using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程的优先级
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "线程的优先级Demo";
            //创建线程
            Thread t1 = new Thread(new ThreadStart(DoWork1));
            Thread t2 = new Thread(new ThreadStart(DoWork2));

            //设置线程的优先级
            t1.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Lowest;
          //启动线程
            t2.Start();
            t1.Start();
          
          

           // Console.ReadKey();
          

        }
        static void DoWork1()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("DoWork1:"+i);
            }
        }

        static void DoWork2()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("DoWork2:" + i);
            }
        }
    }
}
