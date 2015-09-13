using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comda.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var dir = @"c:\tmp";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            var file = Path.Combine(dir, Guid.NewGuid().ToString());

            File.Create(file);

            Console.WriteLine("Press any key for stop services ....");
            Console.ReadLine();
        }
    }
}
