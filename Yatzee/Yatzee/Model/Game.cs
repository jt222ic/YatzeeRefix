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
        //int total;
        public List<int> performFirstRoll()
        {
            return Dice.Roll();
        }
        Player player = new Player("");
        public Game()
        {
        
        }
        public int getscore(int PlayerValue)
        {
            player.GetOne = SubmitScore(Dices, PlayerValue);                         // to be able to store information in Playerclass to save it to DAL
            player.GetSum = player.GetOne;

            return SubmitScore(Dices, PlayerValue);
        }

        public void GatherScore(int score)
        {
            player.GetTotalScore += score;
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

