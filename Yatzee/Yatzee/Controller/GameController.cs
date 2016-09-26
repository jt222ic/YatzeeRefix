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
        IReadOnlyCollection<Player> ListOfPlayers;
        List<Player> PlayerList;

        public GameController( List<Player> PlayerList, Player player, ViewStatus show)
        {
           
            this.player = player;
            this.show = show;
            this.PlayerList = PlayerList;
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
                    game.Dices = game.performFirstRoll();
                   ChoiceOfReRoll();
                }
            }
            catch(ArgumentException e)
            {

                show.CatchArgument(e);
              
            }
        }
        public void ChoiceOfReRoll()
        {
            show.DisplayRoll(game.Dices, game.idle());
            try
            {
                do
                {
                    
                   

                   
                    if (!game.LockDiceToss)
                    {
                        string NewReRoll = show.ReturnDicePicks();
                        int DiceChoice = int.Parse(NewReRoll);

                        if (DiceChoice == 7)
                        {
                            player = GameChoices(PlayerList, player);
                        }

                        switch (DiceChoice)
                        {
                            case 0:
                               return;
                            case 1:
                                dicenumber = 0;
                                game.performReroll(dicenumber, game.Dices, player);
                                break;
                            case 2:
                                dicenumber = 1;
                                game.performReroll(dicenumber, game.Dices, player);
                                break;
                            case 3:
                                dicenumber = 2;
                                game.performReroll(dicenumber, game.Dices, player);
                                break;
                            case 4:
                                dicenumber = 3;
                                game.performReroll(dicenumber, game.Dices, player);
                                break;
                            case 5:
                                dicenumber = 4;
                                game.performReroll(dicenumber, game.Dices, player);
                                break;
                            case 6:
                                game.ChangetwoTimes();
                                show.DisplayRoll(game.Dices, game.ChangetwoTimes());
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
        public Player GameChoices(List<Player> PlayerList,Player player)
        {
            show.DisplayScore(DAL.getMemberList());
            show.SectionPick();
            ViewStatus.Options input = show.GetOptions();
          

            if (input == ViewStatus.Options.UpperSection)
            {
                UpperSection();
            }
            else if (input == ViewStatus.Options.LowerSection)
            {
                LowerSection();
            }
            if (input == ViewStatus.Options.SUBMIT)
            {
                player = ChangePlayer(PlayerList,player);

            }
            return player;
            
        }
        public void UpperSection()
        {
            
                try
                {
                    string choices = show.GetInput();
                    int PlayerValue;
                    int RuleChoice = int.Parse(choices);

                    switch (RuleChoice)
                    {
                        case 1:
                            PlayerValue = 1;
                            player.GetOne = game.SubmitScore(game.Dices, PlayerValue);                         // to be able to store information in Playerclass to save it to DAL
                            player.GetSum = player.GetOne;
                            // the collection of sum of each ruule6
                            break;
                        case 2:
                            PlayerValue = 2;
                            player.GetTwo = game.SubmitScore(game.Dices, PlayerValue);
                            player.GetSum = player.GetTwo;
                            break;

                        case 3:
                            PlayerValue = 3;
                            player.GetThree = game.SubmitScore(game.Dices, PlayerValue);
                            player.GetSum = player.GetThree;
                            break;

                        case 4:
                            PlayerValue = 4;
                            player.GetFour = game.SubmitScore(game.Dices, PlayerValue);
                            player.GetSum = player.GetFour;
                            break;

                        case 5:
                            PlayerValue = 5;
                            player.GetFive = game.SubmitScore(game.Dices, PlayerValue);
                            player.GetSum = player.GetFive;
                            break;
                        case 6:
                            PlayerValue = 6;
                            player.GetSix = game.SubmitScore(game.Dices, PlayerValue);
                            player.GetSum = player.GetSix;
                            break;
                        default: return;


                    }
                }
                catch
                {
                    show.Catch();
                }

                show.showResult(player.GetSum);
            }                            // GEt input from view, then send it to model class player to inform the change in result, then return to view to read it out
        
        public void LowerSection()
        {
            string lowerchoices = show.GetInput();
            int LowerChoice = int.Parse(lowerchoices);

            switch (LowerChoice)
            {
                case 0:
                    return;
                case 1:

                    player.GetThreeOfAKind = game.SubmitThreeOfAKind(game.Dices, 0);                // the score for each indivduel score 
                    player.GetSum = player.GetThreeOfAKind;                                             // to save and to send it to view 
                    break;

                case 2:
                    player.GetFourOfAKind = game.SubmitFourOfaKind(game.Dices, 0);
                    player.GetSum = player.GetFourOfAKind;
                    break;

                case 3:
                    player.GetFullHouse = game.SubmitFullHouse(game.Dices, 0);
                    player.GetSum = player.GetFullHouse;
                    break;

                case 4:
                    player.GetSmallStraight = game.SubmitSmallStraight(game.Dices, 0);
                    player.GetSum = player.GetSmallStraight;
                    break;
                case 5:
                    player.GetLargeStraight = game.SubmitLargeStraight(game.Dices, 0);
                    player.GetSum = player.GetLargeStraight;
                    break;

                case 6:
                    player.GetChance = game.SubmitChance(game.Dices, 0);
                    player.GetSum = player.GetChance;
                    break;

                case 7:
                    player.GetYatzee = game.SubmitYatzee(game.Dices, 0);
                    player.GetSum = player.GetYatzee;
                    break;

                default:
                    return;
            }
            show.showResult(player.GetSum);
        }
        public Player ChangePlayer(List<Player> PlayerList,Player player)
        {

            Player ChangePlayer = player;
            ListOfPlayers = DAL.getMemberList();
            show.CompactList(ListOfPlayers);
            var choice = int.Parse(show.GetInput());
            choice--;
            ChangePlayer = PlayerList.ElementAt(choice);
           

            return ChangePlayer;
        }

    }
}

