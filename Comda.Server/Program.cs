using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Comda.Server
{
    public class Program
    {
        private static EventWaitHandle ewh;
        private static FileSystemWatcher watcher;

        public static void Main(string[] args)
        {
            var dir = @"c:\tmp";
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            ewh = new EventWaitHandle(false, EventResetMode.ManualReset);

            for (int i = 0; i <= 10; i++)
            {
                var t = new Thread(ThreadProc);
                t.Start(i);
                Console.WriteLine("Tread {0} started", i);
            }



            watcher = new FileSystemWatcher()
            {
                Path = dir,
                IncludeSubdirectories = false,
                EnableRaisingEvents = true,
            };

            watcher.Created += (sender, eventArgs) =>
            {
                 ewh.Set();
            };

            Console.WriteLine("Press any key....");
            Console.ReadLine();
        }

        public static void ThreadProc(object data)
        {
            int index = (int)data;
            var current = Thread.CurrentThread;

            // Wait on the EventWaitHandle.
            ewh.WaitOne();

            Console.WriteLine("Thread {0} : {1} {2} exits.", data, current.ManagedThreadId, current.Name);
        }
    }
}
