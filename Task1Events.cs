using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SumEvent
{
    public class Task1Events
    {
        public delegate int SumHandler(int a, int b);
        public event SumHandler SumHandlerEvent;

        public Task1Events()
        {
            SumHandlerEvent += Sum;
            SumHandlerEvent += Sum;
        }

        public void Run(int a, int b)
        {
            int result;
            result = CalcSums(a, b);
            Console.WriteLine($"x = {a}, y = {b}");
            Console.WriteLine("(x + y) * 2 = " + result);
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int CalcSums(int a, int b)
        {
            int result = 0;
            SumHandler method = SumHandlerEvent;
            var invokeList = SumHandlerEvent.GetInvocationList();
            foreach ( var list in invokeList )
            {
                result += TryMethod(method, a, b); 
            }

            return result;
        }

        public int TryMethod(SumHandler method, int a, int b)
        {
            try
            {
                return method(a, b);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
