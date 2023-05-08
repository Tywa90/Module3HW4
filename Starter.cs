using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumEvent
{
    public class Starter
    {
        public void Run()
        {
            Console.WriteLine("\tTask 1:");
            var task1 = new Task1Events();
            task1.Run(10, 2);

            Console.WriteLine("\n\tTask 2:");
            var task2 = new Task2Linq();
            task2.Run();
        }
    }
}
