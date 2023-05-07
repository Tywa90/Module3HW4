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
            var task1 = new Task1Events();

            var task2 = new Task2Linq();
            task2.Run();
        }
    }
}
