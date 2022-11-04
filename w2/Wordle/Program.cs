using System.IO;
using System.Linq;
using System;
namespace Wordle{
    public class Program{
        public static void Main(){
            string pathin = "./wordOptions.txt";
            string playerHistory = "./.history";

            string[] read = File.ReadAllLines(pathin);
            var rand = new Random();

            string randomWord = read[rand.Next(0,read.Length-1)];
            //randomWord.Substring(0,5);
            //Console.WriteLine(randomWord);
            //string randomWord = "hello";

            //user created
            Console.WriteLine("Please enter your username:");
            string username = Console.ReadLine();
            Console.WriteLine("Please enter your password:");
            string password = Console.ReadLine();

            User player = new User(username,password);

            bool playAgain=true;
            List<User> records = player.readFromXml();

            while(playAgain){
            bool wins =false;
            int correct =0;
            int turns=0;

            randomWord = read[rand.Next(0,read.Length-1)];
            
            Console.WriteLine(randomWord);
            Dictionary<char,int> letters = new Dictionary<char,int>();
            for(int w=0;w<26;w++){
               letters.Add(Convert.ToChar(97+w),0);
            }
            for(int w=0;w<5;w++){
            letters[randomWord[w]]++;
            }
            //Dictionary<char,int> localTemp = new Dictionary<char, int>(letters);

            //Console.WriteLine(letters[5]);
            //string alreadyLocated="";
            Console.WriteLine("Welcome to Wordle!");
            
            for(int k=0;k<5;k++){
                turns++;
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
                //Dictionary<char,int> localTemp = letters.ToDictionary(entry=>entry.Key, entry=>entry.value);//new Dictionary<char,int>();
                //Dictionary<char,int> localTemp = new Dictionary<char, int>(letters);
                Dictionary<char,int> localTemp = new Dictionary<char, int>();
                foreach (KeyValuePair<char,int> kvp in letters){
                    localTemp.Add(kvp.Key,kvp.Value);
                }
                //localTemp = letters;
                for(int i=0;i<5;i++){
                    //else{
                        for(int j=0;j<5;j++){
                            if(guess[i]==randomWord[j] && letters[guess[i]]>0 && localTemp[guess[i]]>0){//&& letters[guess[i]]!=0
                                Console.WriteLine("The letter {0} is correct but in the wrong space",guess[i]);
                                localTemp[guess[i]]--;
                                break;
                            }

                        }
                    }
                }
            //}
            else{
                Console.WriteLine("Error, must be 5 letters");
                //k--;
            }
            if(correct==5){
                wins = true;
                // string add = "Name: " + name+", Number of wins: " + wins;

                // string path = "./testFile.txt";
                // // string[] text = {"hi","Hello","There","Hows","It","Going"};
                // if(!File.Exists(path)){
                //     File.WriteAllText(path,add);
                // }
                // else{
                //     File.AppendAllText(path,add); 
                // }

                    // Console.WriteLine("Name: {0}",name);
                    // Console.WriteLine("Number of wins: {0}",++wins);
                    break;
                }
            }
            //
            //player.saveRecord(playerHistory);
            player.updateRecord(wins,turns);
            //Console.WriteLine(player.displayRecord(playerHistory));
            Console.WriteLine("Play Again? enter y");

            if(Console.ReadLine().ToLower() != "y"){
                playAgain = false;
            }
            }
            //end of loop (playagain)

            //want to replace adding player to the records list with checking if player is already on the list
            //we should be able to use some method call to accomplish this
            //records.Add(player);
            //recordsUpdate(records, player);

            if(records.Exists(x =>x.username == player.username)){
               //int index = records.FindIndex(x =>x.username == player.username);
               // records[index].update(player);
               records.Find(x=>x.username == player.username).update(player);

            }
            else{
                records.Add(player);
            }
            
            player.SerializeAsXml(records);
            //player.saveRecord(playerHistory);
            Console.WriteLine(player.displayRecord(playerHistory,records));
            
        }
        public static void recordsUpdate(List<User> records, User player){
            if(records.Exists(x =>x.username == player.username)){
               //int index = records.FindIndex(x =>x.username == player.username);
               // records[index].update(player);
               records.Find(x=>x.username == player.username).update(player);

            }
            else{
                records.Add(player);
            }
        }
    }

}