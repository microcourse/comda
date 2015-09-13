using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Comda.Host
{
    public class Program
    {
        private static EventWaitHandle ewh;

        public void Main(string[] args)
        {
            ewh = new EventWaitHandle(false, EventResetMode.ManualReset);
            for (int i = 0; i <= 10; i++)
            {
                var t = new Thread(ThreadProc);
                t.Start(i);
            }

            Console.WriteLine("Press any ke....");
            Console.ReadLine();
            ewh.Set();

            Console.WriteLine("Press any ke....");
            Console.ReadLine();
        }

        public static void ThreadProc(object data)
        {
            int index = (int)data;
            var current = Thread.CurrentThread;

            // Wait on the EventWaitHandle.
            ewh.WaitOne();

            Console.WriteLine("Thread {0} : {1} {2} exits.", data, current.ManagedThreadId, current.Name );
        }
    }
}
