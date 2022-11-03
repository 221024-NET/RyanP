using System.IO;
using System;
namespace Wordle{
    public class Program{
        public static void Main(){
            string pathin = "./wordOptions.txt";
           // var read = File.ReadAllLines(path);
            //var rand = new Random();

            //string randomWord = read[rand.Next(0,read.Length-1)];
            //randomWord.Substring(0,5);
            //Console.WriteLine(randomWord);
            string randomWord = "hello";
            string name = "bob";
            int wins =0;
            int correct =0;
            Dictionary<char,int> letters = new Dictionary<char,int>();
            for(int w=0;w<26;w++){
               letters.Add(Convert.ToChar(97+w),0);
            }
            for(int w=0;w<5;w++){
            letters[randomWord[w]]++;
            }
            

            //Console.WriteLine(letters[5]);
            //string alreadyLocated="";
            Console.WriteLine("Welcome to Wordle!");
            
            for(int k=0;k<5;k++){
                Console.WriteLine("Type in 5 letters:");
            string guess = Console.ReadLine().ToLower();
            if(guess.Length == 5){
                correct=0;
                for(int i=0;i<5;i++){
                    if(guess[i] == randomWord[i]){
                        Console.WriteLine("The letter {0} was in the correct spot", randomWord[i]);
                        letters[guess[i]]--;
                        correct++;
                        continue;
                    }
                }
                //if(correct !=5){
                for(int i=0;i<5;i++){
                    //else{
                        for(int j=0;j<5;j++){
                            if(guess[i]==randomWord[j] && letters[guess[i]]>0){//&& letters[guess[i]]!=0
                                Console.WriteLine("The letter {0} is correct but in the wrong space",guess[i]);
                                //letters[guess[i]]--;
                                break;
                            }
                        }
                    }
                //}
            }
            else{
                Console.WriteLine("Error, must be 5 letters");
                //k--;
            }
            if(correct==5){
                wins++;
                string add = "Name: " + name+", Number of wins: " + wins;

                string path = "./testFile.txt";
                // string[] text = {"hi","Hello","There","Hows","It","Going"};
                if(!File.Exists(path)){
                    File.WriteAllText(path,add);
                }
                else{
                    File.AppendAllText(path,add); 
                }
                    // Console.WriteLine("Name: {0}",name);
                    // Console.WriteLine("Number of wins: {0}",++wins);
                    break;
                }
            }

            // string path = "./testFile.txt";

            // // string[] text = {"hi","Hello","There","Hows","It","Going"};
            // if(!File.Exists(path)){
            //     File.WriteAllLines(path,add);
            // }
            // else{
            //     File.AppendAllLines(path,add); 
            // }
            // File.WriteAllLines(path,text); //overrides existing file, good for creating
            //adds to exisiting file
            // string[] content = File.ReadAllLines(path);

            // foreach (string s in content){
            //     Console.WriteLine(s);
            // }
            
        }
    }

}