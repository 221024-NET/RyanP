using System;

namespace HotAndCold{
    public class Guessing{
        
        //<summary> this is a summary </summary>
        /// <summary>
        /// This method generates a value from a random number generator
        /// </summary>
        /// <returns> int secretNum</returns>
        public int GenerateSecretNumber(){
            var rand = new Random();
            return rand.Next(101);

        }

        public int GetUserNumber(){
            int userNum = -1;
            Console.WriteLine("Enter a guess for the secret number:");
                
            string userChoice = Console.ReadLine();
            while(!Int32.TryParse(userChoice,out userNum)){
                Console.WriteLine("Please enter only numberical values");
                userChoice = Console.ReadLine();
            }
            // if(!Int32.TryParse(userChoice,out int x)){
            //     Console.WriteLine("Not a valid input try again");
            //     continue;
            // }
            return userNum;

        }

        public string printResult(int secretNum, int userNum){
        if (secretNum == userNum){
            return "Congratulations, you've guessed the secret number!";
                //Console.WriteLine("Congratulations, you've guessed the secret number!");
                //loop =false;
                //break;
                //continue; //not good in this case. use when want to skip the rest of the loop but continue loop
                //return; //does not run anything else even stuff after the while loop
            }
            else if(secretNum > userNum){
                return "Oops, you've guessed too low!";
                //Console.WriteLine("Oops, you've guessed too low!");
            }
            else{
                return "Oops, you've guessed too high!";
                //Console.WriteLine("Oops, you've guessed too high!");
            }
        }
    }
}