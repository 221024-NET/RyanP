using System;

namespace coinFlipper2{

    class Coin{

        public static string Flip()
        {
            var rand = new Random();
            
                int coin = rand.Next(2);
                return HoT(coin);
            
        }
        
        private static string HoT(int coin)
        {
            if (coin == 0)
            {
                return "h";	
            }
            else
            {
                return "t";
            }
        }
    }

}