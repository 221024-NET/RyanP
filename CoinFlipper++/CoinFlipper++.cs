using System;
namespace coinFlipper2{
public class Program
{
	// Fields
	public int test = 0;
	
	// Constructor
	// Methods
	//[access modifier] [modifier] [return type] [method name] ([parameters])
	public static void Main()
	{
        Console.WriteLine("Starting Coin Flipper:");
        Console.WriteLine("Try to guess if it is heads or tails!");
		bool loop = true;
		while(loop){
            

			CoinFlipper(); //models the Entire behavior
			
			Console.WriteLine("Would you like to keep playing?");
			Console.WriteLine("Enter 'y' or 'Y' to run again, or anything else to exit: ");
			string playAgain = Console.ReadLine().ToUpper();

			if (playAgain != "Y"){
				loop = false;
			}

		}
	}

	public static void CoinFlipper()
	{
		Console.Write("Pick either h for Heads or t for Tails: ");
		
		string userChoice = Console.ReadLine();
		//int Num = 0;
        userChoice.ToLower();
		bool condition = true;;
		try
		{
			if ( userChoice != "h" && userChoice != "t" )
			{
				throw new Exception("\nInput must be h or t\n");
			}
		}
		catch( Exception e )
		{
			Console.WriteLine(e.Message);
            condition = false;
		}
        if(condition)
        {
            string comChoice = Coin.Flip();
            if (userChoice == comChoice){
                Console.WriteLine("\nCorrect! You guessed the same\n");
            }
            else{
                if (comChoice == "h"){    
                    Console.WriteLine("\nNice Try! But it was Heads\n");
                }
                else{
                    Console.WriteLine("\nNice Try! But it was Tails\n");
                }

            }
        }
	}
}
}