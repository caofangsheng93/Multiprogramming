using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 多线程之__Monitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Monitor Demo";  
            TestMonitor monitor = new TestMonitor();
            Thread t1 = new Thread(monitor.DoDivide);
            Thread t2 = new Thread(monitor.DoDivide);
            t1.Start();
            t2.Start();
        }

    }

    class TestMonitor
    {
        int num1 = 0;
        int num2 = 0;
        Random rmd = new Random();
        private static object myLock = new object();

        /// <summary>
        /// 做除法
        /// </summary>
        public void DoDivide()
        {
            bool isLockTaken = false;
                try
                {
                    Monitor.Enter(myLock,ref isLockTaken);//确保只有一个线程，能够访问代码块
                    for (int i = 0; i < 100; i++)
                    {
                        num1 = rmd.Next(1, 5);
                        num2 = rmd.Next(1, 5);
                        Console.WriteLine("num1/num2={0}",num1/num2);
                        num1 = 0;
                        num2 = 0;
                    }
                }
                finally 
                {
                    if (isLockTaken)
                    {
                        Monitor.Exit(myLock);//释放锁
                    }
                   
                }
            
           

        }

    }
}
