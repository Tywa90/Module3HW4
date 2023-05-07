namespace SumEvent
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            ClassCounter counter = new ClassCounter();

            counter.onCount += counter.SumTogether;
            counter.onCount += counter.SumTogether;

            counter.Sum(5, 10);
        }
    }
}