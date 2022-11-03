using System;
namespace CollectionExample.App{

    public class Program{
        public static void Main(){
            Console.WriteLine("Collection Example Starting!");
            Timer timer = new Timer();
            TimeSpan runTime = timer.run();
            Console.WriteLine("Total elaped time is: {0} ms", runTime.TotalMilliseconds);
            DateTime start= DateTime.Now;
            DateTime stop = DateTime.Now;
            TimeSpan test = stop - start;
            Console.WriteLine(test.TotalMilliseconds);

        }
    }
}