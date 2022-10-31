using System;

namespace HotAndCold
{
    public class program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Number Guesser started:");
            
            Guessing n = new Guessing();
            int secretNum = n.GenerateSecretNumber();
            int userNum =-1;

            do{
               userNum = n.GetUserNumber();

                Console.WriteLine(n.printResult(secretNum,userNum));

            } while(secretNum != userNum);
            Console.WriteLine("Thanks for playing");
        }
    }
}
