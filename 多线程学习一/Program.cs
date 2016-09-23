using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 多线程学习一
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "前/后台线程的例子";
            Thread t1 = new Thread(PrintThread1);
            t1.Name = "前台";//设置线程的名字
            t1.Start();


            Thread t2 = new Thread(PrintThread2);
            t2.Name = "后台";//设置线程的名字
            t2.IsBackground = true;//设置线程t2为后台线程
            t2.Start();

            Console.WriteLine("主线程退出！");
            Console.WriteLine("主线程ID：{0}", Thread.CurrentThread.ManagedThreadId);
            //Console.ReadKey();


        }


        static void PrintThread1()
        {
            for (int i = 0; i < 5; i++)
            {
                //打印当前线程的名称
                Console.WriteLine("我是一个{0}线程,线程ID是：{1}", Thread.CurrentThread.Name, Thread.CurrentThread.ManagedThreadId);
                //线程阻塞的时间
                Thread.Sleep(1000);
            }
        }


        static void PrintThread2()
        {
            for (int i = 0; i < 5; i++)
            {
                //打印当前线程的名称
                Console.WriteLine("我是一个{0}线程,线程ID是：{1}",Thread.CurrentThread.Name,Thread.CurrentThread.ManagedThreadId);
               //线程阻塞的时间
                Thread.Sleep(1000);
            }
        }
    }
}
