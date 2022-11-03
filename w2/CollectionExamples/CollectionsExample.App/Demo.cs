namespace CollectionExample.App{

    public class Demo{
        DateTime[] arr = new DateTime[2000005];

        public Demo(){
            for (int i=0; i<this.arr.Length;i++){
                arr[i] = DateTime.Now;

            }
        }
        public TimeSpan[] getDifferences(){
            TimeSpan[] ts = new TimeSpan[this.arr.Length -1];
            for (int i=0; i < this.arr.Length-1; i++){
                DateTime start = arr[i];
                DateTime end = arr[i+1];

                ts[i] = end - start;
            }
            return ts;
        }
    }
}