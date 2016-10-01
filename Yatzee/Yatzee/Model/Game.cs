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
        Player player;


        public Game(Player p_player)
        {
           player = p_player;
        }
        public int getscore(int PlayerValue)                                                    // alternative solution 2//  // low cohesion//
        {
            if (PlayerValue == 1)
            {
                player.GetOne = SubmitScore(Dices, PlayerValue);                                     
                player.GetSum = player.GetOne;
            }
            else if(PlayerValue == 2)
            {
                player.GetTwo = SubmitScore(Dices, PlayerValue);
                player.GetSum = player.GetTwo;
            }
            else if(PlayerValue == 3)
            {
                player.GetThree = SubmitScore(Dices, PlayerValue);
                player.GetSum = player.GetThree;
            }
            else if (PlayerValue == 4)
            {
                player.GetFour = SubmitScore(Dices, PlayerValue);
                player.GetSum = player.GetFour;
            }
            else if (PlayerValue == 5)
            {
                player.GetFive = SubmitScore(Dices, PlayerValue);
                player.GetSum = player.GetFive;
            }
            else if (PlayerValue == 6)
            {
                player.GetSix = SubmitScore(Dices, PlayerValue);
                player.GetSum = player.GetSix; 
            }

            GatherScore(player.GetSum);
            return SubmitScore(Dices, PlayerValue);
        }                                                                                      // cluster fuck because there are 2 many rules // // alternative solution 1 //  
        
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

