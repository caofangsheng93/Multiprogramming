using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程池
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "线程池Demo";
            //ThreadPool.QueueUserWorkItem(PrintMessage);
            //ThreadPool.QueueUserWorkItem(PrintMessage, "CFS");
            //声明一个有string类型的参数，并有int类型的返回值的委托
            Func<string,int> MethodName=GetStringLength;
            IAsyncResult result=MethodName.BeginInvoke("测试异步委托", null, null);
            int stringLength = MethodName.EndInvoke(result);
            Console.WriteLine("字符串的长度是:{0}",stringLength);
          
            //Console.WriteLine("当前委托所表示的方法:{0}", MethodName.Method);
           // Console.ReadKey();
           
        }
        static void PrintMessage(object obj)
        {
            Console.WriteLine("我是使用一个QueueUserWorkItem的线程池，我的值是:{0}",obj);
        }

        static int GetStringLength(string inputString)
        {
            Console.WriteLine("我是一个使用异步委托的线程池，我的值是:{0}",inputString);
            Console.WriteLine("是否是后台线程池？{0}", Thread.CurrentThread.IsBackground);
            Console.WriteLine("是否是托管线程池?{0}",Thread.CurrentThread.IsThreadPoolThread);
            return inputString.Length;
        }



    }
}
