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

        Player player;
        ViewStatus show;
        Game game;
        int dicenumber;
        List<int> ListaAvRoll;

        public GameController(Player player, ViewStatus show, List<int> ListaAvRoll)
        {
            this.ListaAvRoll = ListaAvRoll;
            this.player = player;
            this.show = show;
            game = new Game();
        }

        public void PerFormFirstRoll()
        {
            try
            {
                show.DisplayFirstPage();
                string choices = show.GetInput();                                      // Hämtar input button från view 
                int Choice = int.Parse(choices);

                if (Choice == 1)
                {
                    this.ListaAvRoll = game.performFirstRoll();
                    ChoiceOfReRoll();
                }
            }
            catch
            {
                show.Catch();
            }
        }
        public void ChoiceOfReRoll()
        {
            show.DisplayRoll(ListaAvRoll, game.idle());

            try
            {
                do
                {
                    string NewReRoll = show.GetInput();
                    int DiceChoice = int.Parse(NewReRoll);
                    if (DiceChoice == 7)
                    {
                        UpperSection();
                    }

                    if (!game.LockDiceToss)                 // made the variable field public 
                    {
                        switch (DiceChoice)
                        {
                            case 0:
                                return;
                            case 1:
                                dicenumber = 0;
                                game.performReroll(dicenumber, ListaAvRoll, player);
                                break;
                            case 2:
                                dicenumber = 1;
                                game.performReroll(dicenumber, ListaAvRoll, player);
                                break;
                            case 3:
                                dicenumber = 2;
                                game.performReroll(dicenumber, ListaAvRoll, player);
                                break;
                            case 4:
                                dicenumber = 3;
                                game.performReroll(dicenumber, ListaAvRoll, player);
                                break;
                            case 5:
                                dicenumber = 4;
                                game.performReroll(dicenumber, ListaAvRoll, player);
                                break;
                            case 6:
                                game.ChangetwoTimes();
                                show.DisplayRoll(ListaAvRoll, game.ChangetwoTimes());
                                break;
                        }
                    }
                }
                while (show.returnInput());
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
                // Taking Totalscore from player and add in from the game

                switch (RuleChoice)
                {
                    case 0:
                        return false;
                    case 1:
                        PlayerValue = 1;
                        player.GetOne = game.SubmitScore(ListaAvRoll, PlayerValue);                         // to be able to store information in Playerclass to save it to DAL
                        player.GetSum = player.GetOne;                                                        // the collection of sum of each ruule6
                        break;
                    case 2:
                        PlayerValue = 2;
                        player.GetTwo = game.SubmitScore(ListaAvRoll, PlayerValue);
                        player.GetSum = player.GetTwo;
                        break;

                    case 3:
                        PlayerValue = 3;
                        player.GetThree = game.SubmitScore(ListaAvRoll, PlayerValue);
                        player.GetSum = player.GetThree;
                        break;

                    case 4:
                        PlayerValue = 4;
                        player.GetFour = game.SubmitScore(ListaAvRoll, PlayerValue);
                        player.GetSum = player.GetFour;
                        break;

                    case 5:
                        PlayerValue = 5;
                        player.GetFive = game.SubmitScore(ListaAvRoll, PlayerValue);
                        player.GetSum = player.GetFive;

                        break;

                    case 6:
                        PlayerValue = 6;
                        player.GetSix = game.SubmitScore(ListaAvRoll, PlayerValue);
                        player.GetSum = player.GetSix;
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
            show.showResult(player.GetSum);            // GEt input from view, then send it to model class player to inform the change in result, then return to view to read it out
            return true;
        }
        public void LowerSection()
        {
            string lowerchoices = show.GetInput();
            int LowerChoice = int.Parse(lowerchoices);


            switch (LowerChoice)
            {
                case 0:
                    return;
                case 1:


                    player.GetThreeOfAKind = game.SubmitThreeOfAKind(ListaAvRoll, 0);
                    player.GetSum = player.GetThreeOfAKind;
                    break;

                case 2:
                    player.GetFourOfAKind = game.SubmitFourOfaKind(ListaAvRoll, 0);
                    player.GetSum = player.GetFourOfAKind;
                    break;

                case 3:
                    player.GetFullHouse = game.SubmitFullHouse(ListaAvRoll, 0);
                    player.GetSum = player.GetFullHouse;
                    break;

                case 4:
                    player.GetSmallStraight = game.SubmitSmallStraight(ListaAvRoll, 0);
                    player.GetSum = player.GetSmallStraight;
                    break;
                case 5:
                    player.GetLargeStraight = game.SubmitLargeStraight(ListaAvRoll, 0);
                    player.GetSum = player.GetLargeStraight;
                    break;

                case 6:
                    player.GetChance = game.SubmitChance(ListaAvRoll, 0);
                    player.GetSum = player.GetChance;
                    break;

                case 7:
                    player.GetYatzee = game.SubmitYatzee(ListaAvRoll, 0);
                    player.GetSum = player.GetYatzee;
                    break;

                default:
                    return;
            }
            show.showResult(player.GetSum);
        }
    }
}

