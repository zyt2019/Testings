using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TestingThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 线程池的解释
            //Console.WriteLine(string.Format("当前线程号为：{0}", Thread.CurrentThread.ManagedThreadId));
            ////线程池的优点 不用自己创建线程 节省CPU资源 适用于大量短时间线程
            //ThreadPool.QueueUserWorkItem((pa) =>
            //{
            //    Console.WriteLine(pa.ToString());
            //    Console.WriteLine(string.Format("当前线程号为：{0}", Thread.CurrentThread.ManagedThreadId));
            //},
            //"我就是线程池这个线程的参数");

            //Console.ReadLine(); 
            #endregion
            #region 异步委托
            Console.WriteLine("主线程所在的线程为：" + Thread.CurrentThread.ManagedThreadId);
            Func<int, int, string> func = new Func<int, int, string>(FuncMethod);
            //异步委托的方法就是新开一个线程去执行这个方法 不占用主线程的时间
            func.BeginInvoke(10, 50, MyAsyncCallback, "我就是那个回调函数的参数");
            Console.WriteLine("我是主线程，我已经执行完了");
            Console.ReadLine();
            #endregion
            
        }
        /// <summary>
        /// 在这个方法执行完后把数据拿到
        /// </summary>
        /// <param name="ar"></param>
        private static void MyAsyncCallback(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar;
            string str= ((Func<int, int, string>)result.AsyncDelegate).EndInvoke(result);
            Console.WriteLine($"这个耗时的方法得到的值是：{str}");
            Console.WriteLine($"回调函数的参数是{result.AsyncState}");
            Console.WriteLine("回调函数在的线程为："+Thread.CurrentThread.ManagedThreadId);
        }

        /// <summary>
        /// 模拟一个耗时的方法
        /// </summary>
        /// <param name="arg1"></param>
        /// <param name="arg2"></param>
        /// <returns></returns>
        private static string FuncMethod(int arg1, int arg2)
        {
            Thread.Sleep(5000);
            Console.WriteLine("异步委托的方法所在的线程为：" + Thread.CurrentThread.ManagedThreadId);
            return (arg1 * arg2).ToString();
        }
    }
}
