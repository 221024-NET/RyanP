using System;
using CoinFlip;
using Figgle;
namespace HotAndCold
{
    public class program 
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Number Guesser started:");
            
            Guessing n = new Guessing();
            CoinFlipper d = new CoinFlipper();
            int secretNum = n.GenerateSecretNumber();
            int userNum =-1;
            Console.WriteLine(d.ToString());
            //Console.WriteLine(FiggleFont.)
            

            do{
               userNum = n.GetUserNumber();

                Console.WriteLine(n.printResult(secretNum,userNum));

            } while(secretNum != userNum);
            Console.WriteLine("Thanks for playing");
            //Console.ReadLine();
        }
    }
}
