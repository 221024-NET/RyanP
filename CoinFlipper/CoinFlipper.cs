using System;
namespace coinFlipGame{
public class Program
{
	// Fields
	public int test = 0;
	
	// public enum headTail{
	// 	Heads,
	// 	Tails
	// }
	// Constructor
	// Methods
	//[access modifier] [modifier] [return type] [method name] ([parameters])
	public static void Main()
	{
		bool loop = true;
		while(loop){
			CoinFlipper(); //models the Entire behavior
			
			Console.WriteLine("Would you like to flip more coins?");
			Console.WriteLine("Enter 'y' or 'Y' to run again, or anything else to exit: ");
			string playAgain = Console.ReadLine().ToUpper();

			//playAgain.ToUpper();
			// if (playAgain.Equals("Y")){
			// 	loop = false;
			// }
			// else{
			// 	loop = false;
			// }
			// int[] num;
			// int number;
			// int n[];
			// int new nn[];
			// int nume = int[];

			// int[] run = {1,2,3};
			// int [] r = new int[5];

			if (playAgain != "Y"){
				loop = false;
			}

		}
	}

	public static void CoinFlipper()
	{
		Console.WriteLine("Starting Coin Flipper:");
		
		Console.WriteLine("Enter the number of coins to flip: ");
		
		string UserNumber = Console.ReadLine();
		int Num = 0;
		
		try
		{
			Num = Int32.Parse(UserNumber);
			if ( Num <= 0 )
			{
				throw new Exception("Argument may not be negative");
			}
		}
		catch( InvalidOperationException e )
		{
			Console.WriteLine("A less specific catch: " + e.Message);
		}
		catch( ArgumentException e)
		{
			Console.WriteLine(e.Message);
		}
		catch( Exception e )
		{
			Console.WriteLine("The least specific catch: " + e.Message);
		}
		
		Flip(Num);
	}
	
	//[access modifier] [modifier] [return type] [method name] ([parameters])
	public static void Flip(int Num)
	{
		var rand = new Random();
		
		for (int i = 0; i < Num; i++)
		{
			int coin = rand.Next(2);
			HoT(coin);
		}
	}
	
	public static void HoT(int coin)
	{
		
		if (coin == 0)
		{
			Console.WriteLine("Heads");	
		}
		else
		{
			Console.WriteLine("Tails");
		}
	}
}
}