using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程阻塞
{
    class Program
    {
        static Thread t1 = null;
        static Thread t2 = null;

        static void DoWork1()
        {
            Console.WriteLine("在方法DoWork1中,线程一的状态是:{0}",t1.ThreadState);
            Console.WriteLine("在方法DoWork1中，线程二的状态是:{0}",t2.ThreadState);

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("DoWork1:"+i);
            }
        }

        static void DoWork2()
        {
            Console.WriteLine("在方法DoWork2中，线程一的状态是:{0}",t1.ThreadState);
            Console.WriteLine("在方法DoWork2中，线程二的状态是:{0}",t2.ThreadState);

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("DoWork2"+i);
            }
        }

        static int DoWork3()
        {
            Thread.Sleep(1000);
            return 5;
        }

        static void TestJoin()
        {
            Console.WriteLine(Environment.NewLine+"Testing Join");
            t1 = new Thread(DoWork1);
            t2 = new Thread(DoWork2);
            t1.Start();
            t1.Join();
            t2.Start();


        }

        static void TestSleep()
        {
            Console.WriteLine(Environment.NewLine+"Testing Sleep");
            Console.WriteLine("Thread sleep started time:{0}",DateTime.Now);
            Thread.Sleep(2000);
            Console.WriteLine("Thread sleep ended time:{0}", DateTime.Now);
        }

        static void TestTaskWait()
        {
            Console.WriteLine(Environment.NewLine+"Testing Task.Wait");
            Console.WriteLine("Task Start Time:{0}",DateTime.Now);
            var task = Task.Factory.StartNew<int>(DoWork3);
            task.Wait();
            Console.WriteLine("Task ended Time:{0},Result:{1}",DateTime.Now,task.Result);
        }

        static void Main(string[] args)
        {
            Console.Title = "线程同步Demo";
            TestSleep();
            TestJoin();
            TestTaskWait();


        }
    }
}
