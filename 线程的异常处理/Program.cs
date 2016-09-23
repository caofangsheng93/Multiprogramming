using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程的异常处理
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "线程异常处理Demo";
            try
            {
                Action MethodName = DoWork;
                IAsyncResult result = MethodName.BeginInvoke(null, null);
                MethodName.EndInvoke(result);
                //new Thread(DoWork).Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine("异常信息:{0}",ex.Message);
               // throw;
            }



        }
        static void DoWork()
        {
         throw new ArgumentNullException();
        }
    }
}
