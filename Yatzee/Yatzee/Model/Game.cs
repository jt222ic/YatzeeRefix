using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.Model.Interface;
using Yatzee.View;

namespace Yatzee.Model
{
    class Game :  GameExtension
    {
      
        int MaximumToss = 2;
        public bool LockDiceToss = false;
        Dice Dice = new Dice();
        public List<int> Dices;
        
        Player player;

        public List<int> performFirstRoll()
        {
            return Dice.Roll();
        }

        public Game(Player player)
        {
            this.player = player;
        }

       
        public List<int> performReroll(int Dicenumber, List<int> Dices)
        {
            return Dice.ReRoll(Dicenumber, Dices);
        }
        public bool ChangetwoTimes()
        {
            if (MaximumToss > 0)
            {
                MaximumToss--;
                return false;
            }
            else
            {
                LockDiceToss = true;
                return true;
            }
        }
        public bool idle()
        {
            return false;
        }

    }

    }

