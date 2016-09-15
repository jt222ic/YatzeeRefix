using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.Model;

namespace Yatzee.View
{
    class ViewStatus
    {

        public void DisplayFirstPage()
        {
            System.Console.Clear();
            System.Console.WriteLine("==========================================");
            System.Console.WriteLine("1.Roll a dice ");
            System.Console.WriteLine("==========================================");
        }

        public void showLowerSection()
        {
            System.Console.WriteLine("LowerSection");
        }
        public void showResult(DiceRule rule)
        {
            System.Console.WriteLine("!!!!!You get {0} !!!!!!", rule.Sum);
        }
        public void showDiceAlternative(Player player, ViewYatzee YatzeeList)
        {
            if (!player.HoldState)
            {
                System.Console.WriteLine("============================");
                System.Console.WriteLine("Pick Dices to change");
                System.Console.WriteLine("=========================== ");
            }
            else
            {
                System.Console.WriteLine("YOU HAVE USED ALL YOUR CHANCE");
            }
        }
        public void Catch()
        {
            System.Console.WriteLine("enter a key number and press 0 to return");
        }
        public void DisplayRoll(List<int> ListaOverDice, bool Diceroll)
        {
            Console.Clear();

            int DifferentDice = 0;
           
            foreach (int dice in ListaOverDice)
            {
                DifferentDice++;
                System.Console.WriteLine("Dice {1}: {0}", dice, DifferentDice);
            }
            if (Diceroll)
            {
                System.Console.WriteLine("======================================================");
                System.Console.WriteLine("Press 1- 5 to switch each Dices and press Enter");
                System.Console.WriteLine("Press 6 to perform re-roll");
                System.Console.WriteLine("Press 0 to return to first page");
                System.Console.WriteLine("======================================================");
            }
        }

        public void DisplayScore(IReadOnlyCollection<Player> list)
        {
            Console.Clear();
            foreach (Player member in list)
            {
                System.Console.WriteLine("                                     ");
                System.Console.WriteLine("                                     ");
                System.Console.WriteLine("                                     ");
                System.Console.WriteLine("                                     ");
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine(" ****Yatzee****||{0}               ||", member.GetName);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("============UpperSection=============");
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Ones         ||{0}       ||", member.GetOne);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Twos         ||{0}       ||", member.GetTwo);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Threes       ||{0}       ||", member.GetThree);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Fours        ||{0}       ||", member.GetFour);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Five         ||{0}       ||", member.GetFive);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Sixes        ||{0}       ||", member.GetSix);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Sum          ||          ||");
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Bonus        ||{0}       ||", member.GetBonus);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("============LowerSection=============");
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("Three of a Kind       ||{0}          ||", member.GetThreeOfAKind);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("Four of a Kind        ||{0}          ||", member.GetFourOfAKind);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("Full House            ||{0}          ||", member.GetFullHouse);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("Small Straight        ||{0}          ||", member.GetSmallStraight);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("Large Straight        ||{0}          ||", member.GetLargeStraight);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("Chance                ||{0}          ||", member.GetChance);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("YAHTZEE               ||{0}          ||", member.GetYatzee);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("TOTALSCORE            ||{0}          ||", member.GetTotalScore);
            }
        }
        public void Register()
        {
            System.Console.Clear();
            System.Console.WriteLine("======================================================");
            System.Console.WriteLine("Yatzee");
            System.Console.WriteLine("======================================================");
            System.Console.WriteLine("1. Register Player");
            System.Console.WriteLine("2. Register Comp--removed");
            System.Console.WriteLine("3. Remove Player");
            System.Console.WriteLine("4. Available Characters");
            System.Console.WriteLine("5.  Save Game");
            System.Console.WriteLine("6.  Load Game");
            System.Console.WriteLine("7.  Game Start");
            System.Console.WriteLine("======================================================");
        }
        public string ReturnInfo()
        {
            System.Console.Clear();
            System.Console.WriteLine("==============PLease write your name down===========================");
            return System.Console.ReadLine();
        }
        public void CompactList(IReadOnlyCollection<Player> list)  // spara in listan först
        {
            int i = 1;
            Console.WriteLine("Player: ");
            foreach (Model.Player member in list)
            {
                System.Console.WriteLine("Name :{0}, Date {1}, TotalScore : {2}  MemberID : {3} ",
                member.GetName, member.date, member.GetTotalScore, i++);
            }
        }
       
    }
}
    
