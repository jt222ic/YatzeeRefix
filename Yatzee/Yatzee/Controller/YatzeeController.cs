using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.Controller;
using Yatzee.Model;

namespace Yatzee.View
{
    class YatzeeController 
    {
        DiceRule Rules;
        Player player;
        ViewStatus show;
        List<int> ListaAvRoll;

        public YatzeeController(DiceRule Rules, Player player, ViewStatus show, List<int> ListaAvRoll)
        {
            this.ListaAvRoll = ListaAvRoll;
            this.Rules = Rules;
            this.player = player;
            this.show = show;

        }
        // Showing Yatzee ScoreSheet // 
        public bool YatzeeScoreSheet()
        {
            show.DisplayScore(DAL.getMemberList());
           
                try
                {
                    string choices = show.GetInput();   // view
                    int PlayerValue;
                    int RuleChoice = int.Parse(choices);
                    player.TOTALSCORE = Rules.TotalScore;
                    player.GetBonus = Rules.Bonus();
                    switch (RuleChoice)
                    {
                        case 0:
                            return false;
                        case 1:
                            PlayerValue = 1;
                            player.GetOne = Rules.AddUpDice(ListaAvRoll, PlayerValue);                                         
                            break;
                        case 2:
                            PlayerValue = 2;
                            player.GetTwo = Rules.AddUpDice(ListaAvRoll, PlayerValue);

                            break;

                        case 3:
                            PlayerValue = 3;
                            player.GetThree = Rules.AddUpDice(ListaAvRoll, PlayerValue);
                            break;

                        case 4:
                            PlayerValue = 4;
                            player.GetFour = Rules.AddUpDice(ListaAvRoll, PlayerValue);
                            break;

                        case 5:
                            PlayerValue = 5;
                            player.GetFive = Rules.AddUpDice(ListaAvRoll, PlayerValue);
                            break;

                        case 6:
                            PlayerValue = 6;
                            player.GetSix = Rules.AddUpDice(ListaAvRoll, PlayerValue);
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
                show.showResult(Rules);
                return true;
        }
        public void LowerSection()
        {
            
                string lowerchoices = show.GetInput();
                int LowerChoice = int.Parse(lowerchoices);
                player.GetBonus = Rules.Bonus();

                switch (LowerChoice)
                {
                    case 0:
                        return;
                    case 1:
                        player.GetThreeOfAKind = Rules.ThreeOfAKind(ListaAvRoll);
                        break;

                    case 2:
                        player.GetFourOfAKind = Rules.FourOfAKind(ListaAvRoll);
                        break;

                    case 3:
                        player.GetFullHouse = Rules.FullHouse(ListaAvRoll);
                        break;

                    case 4:
                        player.GetSmallStraight = Rules.SmallStraight(ListaAvRoll);
                        break;
                    case 5:
                        player.GetLargeStraight = Rules.LargeStraight(ListaAvRoll);
                        break;

                    case 6:
                        player.GetChance = Rules.Chance(ListaAvRoll);
                        break;

                    case 7:
                        player.GetYatzee = Rules.Yatzee(ListaAvRoll);
                        break;

                    default:
                        return;
                }
                show.showResult(Rules);
            }
    }
}

