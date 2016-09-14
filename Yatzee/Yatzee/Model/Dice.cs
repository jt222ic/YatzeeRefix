﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model
{
    class Dice
    {
        Random random = new Random();
        private int i;
        public int RollNumber;
        List<int> unique;
        List<int> newDices = new List<int>();
        
      public Dice()
        {
            
        }
        public List<int> Roll()
        {
            unique = new List<int>();
            for (i = 1; i < 6; i++)
            {
                unique.Add(RollNumber = random.Next(1, 7));
            }
            return unique;
        }
        public List<int> ReRoll(int whichdice,List<int>OldDice, Player Prayer)    
        {
            if (!Prayer.HoldState)
            {
                OldDice[whichdice] = random.Next(1, 7);
            }
            return OldDice;
        }

        public List<int> BotReRoll(List<int> BotDice)
        {
            for (i = 0; i < BotDice.Count; i++)
            {
                BotDice[i] = random.Next(1, 7);
            }

            return BotDice;
        }
    }
}
     




           
    

