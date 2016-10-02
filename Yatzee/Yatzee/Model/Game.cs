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
        int choice = 0;
        public List<int> performFirstRoll()
        {
            return Dice.Roll();
        }
        public Player ChangePlayer(List<Player> PlayerList, Player player)
        {

            Player ChangePlayer = player;
            ChangePlayer = PlayerList.ElementAt(choice);
            choice++;
            if(choice == PlayerList.Count)
            {
                choice = 0;
            }
            return ChangePlayer;
        }

    
    public int getscore(int PlayerValue, Player player)
                                                                // alternative solution 2//  // low cohesion//
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

            GatherScore(player, player.GetSum);
            return SubmitScore(Dices, PlayerValue);
        }

        public int GetThreeOfAKind(Player player)
        {
            player.GetThreeOfAKind = SubmitThreeOfAKind(Dices, 0);
            player.GetSum = player.GetThreeOfAKind;
            GatherScore(player, player.GetSum);
            return SubmitScore(Dices, 0);
        }
        public int GetFourOfAKind(Player player)
        {
            player.GetFourOfAKind = SubmitFourOfaKind(Dices, 0);
            player.GetSum = player.GetFourOfAKind;
            GatherScore(player, player.GetSum);
            return SubmitScore(Dices, 0);
        }
        public int GetFullHouse(Player player)
        {
            player.GetFullHouse = SubmitFullHouse(Dices, 0);
            player.GetSum = player.GetFullHouse;
            GatherScore(player, player.GetSum);
            return SubmitScore(Dices, 0);

        }
        public int GetSmallStraight(Player player)
        {
            player.GetSmallStraight = SubmitSmallStraight(Dices, 0);
            player.GetSum = player.GetSmallStraight;
            GatherScore(player, player.GetSum);
            return SubmitScore(Dices, 0);

        }
        public int GetLargeStraight(Player player)
        {
            player.GetLargeStraight = SubmitLargeStraight(Dices, 0);
            player.GetSum = player.GetLargeStraight;
            GatherScore(player, player.GetSum);
            return SubmitScore(Dices, 0);

        }
        public int Getchance(Player player)
        {
            player.GetChance = SubmitChance(Dices, 0);
            player.GetSum = player.GetChance;
            GatherScore(player, player.GetSum);
            return SubmitScore(Dices, 0);

        }
        public int GetYatzee(Player player)
        {
            player.GetYatzee = SubmitYatzee(Dices, 0);
            player.GetSum = player.GetYatzee;
            GatherScore(player,player.GetSum);
            return SubmitScore(Dices, 0);
        }


        public void GatherScore(Player player,int score)
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

    }

    }

