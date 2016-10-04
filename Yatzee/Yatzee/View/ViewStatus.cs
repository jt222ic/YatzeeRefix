using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.Model;
using Yatzee.Model.Interface;

namespace Yatzee.View
{
    class ViewStatus
    {


        private const char UPPER_KEY = 'q';
        private const char LOWER_KEY = 'w';
        private const char SUBMIT_KEY = 's';

      

        public enum Options
        {

            UpperSection ,
            LowerSection ,
            SUBMIT,
            Escape
        }
        public Options GetOptions()
        {
            switch (System.Console.In.Read())
            {
                case UPPER_KEY:
                    return Options.UpperSection;

                case LOWER_KEY:
                    return Options.LowerSection;

                case SUBMIT_KEY:
                    return Options.SUBMIT;

                 default:
                    return Options.Escape;
            }
        }
        public string GetInput()                                         // Controller reads lines from view class, Console belongs to view class. For Controller
        {
            return System.Console.ReadLine();
        }
        public bool returnInput()
        {
            if(Console.ReadKey(true).Key != ConsoleKey.Escape)                            // reads inputKey if not on Key Escape then continue looping the switch case. For controller

            {
                return true;
            }
            return false;
        }
        public void DisplayFirstPage()
        {
            System.Console.Clear();
            System.Console.WriteLine("==========================================");
            System.Console.WriteLine("1.Roll a dice ");
            System.Console.WriteLine("==========================================");
        }
        public void showLowerSection()                           // write out lower section of brackets Yatzee
        {
            System.Console.WriteLine("LowerSection");
        }
     
        public void DisplayRoll(List<int> ListaOverDice)        //                    // from model bool // hidden dependencies?
        {
            Console.Clear();
            int DifferentDice = 0;
            foreach (int dice in ListaOverDice)
            {
                DifferentDice++;
                System.Console.BackgroundColor = ConsoleColor.Blue;
                System.Console.WriteLine("Dice {1}: {0}", dice, DifferentDice);          // write out the dices tossed
            }
            Console.ResetColor();
            System.Console.WriteLine("======================================================");                           // screen to perform re-roll
            System.Console.WriteLine("Press 1~5 select a dice for reroll");
            System.Console.WriteLine("Press 6 to perform re-roll");
            System.Console.WriteLine("Press 7 to submit to scoresheet");
            System.Console.WriteLine("Press 0 to return to first page");
            System.Console.WriteLine("======================================================");


            System.Console.ResetColor();
        }

        public void DisplayReroll(Game game)
        {
            
            if (game.RerolltwoTimes())
            {
                System.Console.BackgroundColor = ConsoleColor.DarkRed;
                System.Console.WriteLine("YOU have Used All YOUR REROLL press 7 for Submit available score sheet");
            }
            Console.ResetColor();
        }

        public void showResult(int sum, Player player)
        {

            System.Console.WriteLine("!!!!!{0} get  {1} !!!!!!", player.GetName,sum);
        }
        public void DisplayScore(Player player)                   // view Ireads from Model
        {
            Console.Clear();


                System.Console.WriteLine("                                     ");
                System.Console.WriteLine("=====================================");
                System.Console.ForegroundColor = ConsoleColor.Green;
                System.Console.WriteLine(" ****Yatzee****||{0}               ||", player.GetName);
                 System.Console.ResetColor();
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("============UpperSection=============");
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Ones         ||{0}       ||", player.GetOne);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Twos         ||{0}       ||", player.GetTwo);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Threes       ||{0}       ||", player.GetThree);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Fours        ||{0}       ||", player.GetFour);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Five         ||{0}       ||", player.GetFive);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Sixes        ||{0}       ||", player.GetSix);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Sum          ||          ||");
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("         Bonus        ||{0}       ||", player.GetBonus);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("============LowerSection=============");
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("1.Three of a Kind       ||{0}          ||", player.GetThreeOfAKind);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("2.Four of a Kind        ||{0}          ||", player.GetFourOfAKind);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("3.Full House            ||{0}          ||", player.GetFullHouse);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("4.Small Straight        ||{0}          ||", player.GetSmallStraight);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("5.Large Straight        ||{0}          ||", player.GetLargeStraight);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("6.Chance                ||{0}          ||", player.GetChance);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("7.YAHTZEE               ||{0}          ||", player.GetYatzee);
                System.Console.WriteLine("=====================================");
                System.Console.WriteLine("TOTALSCORE            ||{0}          ||", player.GetTotalScore);
            
        }
        public void DisplayRegistration()
        {
            System.Console.Clear();
            System.Console.WriteLine("======================================================");
            System.Console.WriteLine("Yatzee   ");
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
        public void SectionPick()
        {
            System.Console.WriteLine("===============================================");
            System.Console.WriteLine("Press button,choose a number and then press Enter");
            System.Console.WriteLine("===============================================");
            System.Console.WriteLine("Press {0} to Pick UpperSection", UPPER_KEY);
            System.Console.WriteLine("Press {0} to Pick LowerSection", LOWER_KEY);
            System.Console.WriteLine("Press {0} to Pick Switch Character", SUBMIT_KEY);

        }
        public string ReturnDicePicks()
        {

          System.Console.WriteLine("===Dice selected==");
           return System.Console.ReadLine();
        }
        public string ReturnInfo()
        {
            System.Console.Clear();
            System.Console.WriteLine("==============PLease write your name down===========================");
            return System.Console.ReadLine();
        }
        public void CompactList(IReadOnlyCollection<Player> list)  
        {
            int i = 1;
            Console.WriteLine("Player: ");
            foreach (Model.Player member in list)
            {
                System.Console.WriteLine("Name :{0}, Date {1}, TotalScore : {2}  MemberID : {3} ",
                member.GetName, member.date, member.GetTotalScore, i++);
            }
        }



        // error handling //  

        public void CatchArgument()                            // occasion use finding hidden fault in function
        {
            System.Console.WriteLine("There are no players registered");                
        }
        public void CatchNullArgument()                          // occasion use finding hidden fault in function
        {
            System.Console.WriteLine("No legit input value, return one page");
        }
    }
}
    
