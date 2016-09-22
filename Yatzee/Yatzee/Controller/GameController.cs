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

        public void MainMenu()
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
                    if(DiceChoice == 7)
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
                        player.GetOne = game.SubmitScore(ListaAvRoll,PlayerValue);                         // to be able to store information in Playerclass to save it to DAL
                        player.GetSum = game.SubmitScore(ListaAvRoll, PlayerValue);                       // the collection of sum of each ruule6
                        break;
                    case 2:
                        PlayerValue = 2;
                        player.GetTwo = game.SubmitScore(ListaAvRoll, PlayerValue);
                        player.GetSum = game.SubmitScore(ListaAvRoll, PlayerValue);
                        break;

                    case 3:
                        PlayerValue = 3;
                        player.GetThree = game.SubmitScore(ListaAvRoll,PlayerValue);
                        player.GetSum = game.SubmitScore(ListaAvRoll, PlayerValue);
                        break;

                    case 4:
                        PlayerValue = 4;
                        player.GetFour = game.SubmitScore(ListaAvRoll, PlayerValue);
                        player.GetSum = game.SubmitScore(ListaAvRoll, PlayerValue);
                        break;

                    case 5:
                        PlayerValue = 5;
                        player.GetFive = game.SubmitScore(ListaAvRoll, PlayerValue);
                        player.GetSum = game.SubmitScore(ListaAvRoll, PlayerValue);
                        break;

                    case 6:
                        PlayerValue = 6;
                        player.GetSix = game.SubmitScore(ListaAvRoll, PlayerValue);
                        player.GetSum = game.SubmitScore(ListaAvRoll, PlayerValue);
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
            show.showResult(player.GetSum);


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
            // show.showResult(Rules);
        }
    }
}

