namespace CollectionExample.App{
    public class Timer{

        public Timer(){}

        public TimeSpan run(){
            DateTime start= DateTime.Now;

            Demo tmp = new Demo();
            tmp.getDifferences();
            
            DateTime stop = DateTime.Now;

            TimeSpan ts = stop - start;

            return ts;
        }

    }
}