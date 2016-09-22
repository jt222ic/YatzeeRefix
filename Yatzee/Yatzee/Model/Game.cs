using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.Model.Interface;

namespace Yatzee.Model
{
    class Game :  GameExtension
    {

        int MaximumToss = 2;
        public bool LockDiceToss = false;
        Dice Dice = new Dice();
        
        
        public bool Stand()
        {
            return true;
        }
        public int ReturnDiceNumber1()
        {
            return 1;
        }
        public bool SwitchToNextPlayer()
        {
            return true;
        }
        public List<int> performFirstRoll()
        {
            return Dice.Roll();
        }

        public List<int> performReroll(int Dicenumber, List<int> Dices, Player player)
        {
            return Dice.ReRoll(Dicenumber, Dices, player);

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

