using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.Controller;
using Yatzee.Model;
using Yatzee.Model.Interface;

namespace Yatzee.View
{
    class GameController 
    {
        //DiceRule Rules;
        Player player;
        ViewStatus show;
        Dice roll;
        bool perforReRoll = false;
        bool RerollView = false;
        int Tossthree = 0;
        int dicenumber;

        List<int> ListaAvRoll;

        public GameController(Player player, ViewStatus show, List<int> ListaAvRoll)
        {
            this.ListaAvRoll = ListaAvRoll;
           
            this.player = player;
            this.show = show;

        }

        public void MainMenu()
        {
            try
            {
                show.DisplayFirstPage();
                string choices = show.GetInput();                                      // Hämtar input button från view 
                int Choice = int.Parse(choices);

                switch (Choice)
                {
                    case 0:
                        return;

                    case 1:
                        this.ListaAvRoll = roll.Roll();
                      //  perforReRoll = true;
                        show.DisplayRoll(ListaAvRoll, RerollView);
                        ChoiceOfReRoll();
                        break;
                }
            }
            catch
            {
                show.Catch();
            }
        }
        public void ChoiceOfReRoll()
        {
            Tossthree = 0;
            bool RerollView = true;
            show.DisplayRoll(ListaAvRoll, RerollView);

            try
            {
                GameController YatzeeList = new GameController(player, show, ListaAvRoll);
                show.showDiceAlternative(player);
                string NewReRoll = show.GetInput();
                int DiceChoice = int.Parse(NewReRoll);
                switch (DiceChoice)
                {
                    case 0:
                        return;
                    case 1:
                        dicenumber = 0;
                        roll.ReRoll(dicenumber, ListaAvRoll, player);
                        break;
                    case 2:
                        dicenumber = 1;
                        roll.ReRoll(dicenumber, ListaAvRoll, player);
                        break;
                    case 3:
                        dicenumber = 2;
                        roll.ReRoll(dicenumber, ListaAvRoll, player);
                        break;
                    case 4:
                        dicenumber = 3;
                        roll.ReRoll(dicenumber, ListaAvRoll, player);
                        break;
                    case 5:
                        dicenumber = 4;
                        roll.ReRoll(dicenumber, ListaAvRoll, player);
                        break;

                    case 6:
                        if (Tossthree < 2)
                        {
                            show.DisplayRoll(ListaAvRoll, perforReRoll);
                            Tossthree++;
                        }
                        else
                        {
                            player.HoldState = true;
                        }
                        break;
                    case 7:

                        YatzeeList.UpperSection();
                        break;
                }
            }
            catch
            {
                show.Catch();
            }
        }

        public bool UpperSection()
        {
            show.DisplayScore(DAL.getMemberList());
           
                try
                {
                    string choices = show.GetInput();   // view
                    int PlayerValue;
                    int RuleChoice = int.Parse(choices);
                  //  player.TOTALSCORE = Rules.TotalScore;
                   // player.GetBonus = Rules.Bonus();
                    switch (RuleChoice)
                    {
                        case 0:
                            return false;
                        case 1:
                            PlayerValue = 1;
                            //player.GetOne = Rules.AddUpDice(ListaAvRoll, PlayerValue);                                         
                            break;
                        case 2:
                            PlayerValue = 2;
                            //player.GetTwo = Rules.AddUpDice(ListaAvRoll, PlayerValue);

                            break;

                        case 3:
                            PlayerValue = 3;
                            //player.GetThree = Rules.AddUpDice(ListaAvRoll, PlayerValue);
                            break;

                        case 4:
                            PlayerValue = 4;
                          //  player.GetFour = Rules.AddUpDice(ListaAvRoll, PlayerValue);
                            break;

                        case 5:
                            PlayerValue = 5;
                            //player.GetFive = Rules.AddUpDice(ListaAvRoll, PlayerValue);
                            break;

                        case 6:
                            PlayerValue = 6;
                            //player.GetSix = Rules.AddUpDice(ListaAvRoll, PlayerValue);
                            break;

                        case 7:
                            show.showLowerSection();
                            LowerSection();
                            break;
                    }
                }
                catch
                {
                    show.Catch();
                }
               // show.showResult(Rules);
                return true;
        }
        public void LowerSection()
        {
            
                string lowerchoices = show.GetInput();
                int LowerChoice = int.Parse(lowerchoices);
                

           
              //  player.GetBonus = Rules.Bonus();

                switch (LowerChoice)
                {
                    case 0:
                        return;
                    case 1:
                       // player.GetThreeOfAKind = Rules.ThreeOfAKind(ListaAvRoll);
                        break;

                    case 2:
                        //player.GetFourOfAKind = Rules.FourOfAKind(ListaAvRoll);
                        break;

                    case 3:
                        //player.GetFullHouse = Rules.FullHouse(ListaAvRoll);
                        break;

                    case 4:
                        //player.GetSmallStraight = Rules.SmallStraight(ListaAvRoll);
                        break;
                    case 5:
                        //player.GetLargeStraight = Rules.LargeStraight(ListaAvRoll);
                        break;

                    case 6:
                        //player.GetChance = Rules.Chance(ListaAvRoll);
                        break;

                    case 7:
                        //player.GetYatzee = Rules.Yatzee(ListaAvRoll);
                        break;

                    default:
                        return;
                }
             //   show.showResult(Rules);
            }
    }
}

