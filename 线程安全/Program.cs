using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程安全
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "线程锁Demo";
            TestThreadSafe testSafe = new TestThreadSafe();
            Thread t1 = new Thread(testSafe.DoDivide);
            Thread t2 = new Thread(testSafe.DoDivide);
            t1.Start();
            t2.Start();
          

        }
    }

    /// <summary>
    /// 线程安全测试类
    /// </summary>
    class TestThreadSafe
    {
        private static object myLock = new object();
        int num1 = 0;
        int num2 = 0;
        Random rmd = new Random();//生成随机数
        /// <summary>
        /// 做除法
        /// </summary>
        public void DoDivide()
        {
            lock (this)//确保只有一个线程，能够进入代码快
            {
                for (int i = 0; i < 10000000; i++)
                {
                    //返回随机数，随机数在[1，5)之间
                    num1 = rmd.Next(1, 5);
                    num2 = rmd.Next(1, 5);
                    Console.WriteLine("num1/num2={0}", num1 / num2);
                    num1 = 0;
                    num2 = 0;
                }
            }
        }
    }
}
