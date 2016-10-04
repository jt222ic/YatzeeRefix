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
        int score;
        bool inMenu;
        bool InUpper;
        bool inLower;


        public GameController(List<Player> PlayerList, Player player, ViewStatus show)
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
                do
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
                while (true);
            }
            catch
            {
                show.CatchNullArgument();
            }
        }

        private void ChoiceOfRerollMenuHandler(int DiceChoice)
        {

        }
        public void ChoiceOfReRoll()
        {
            
            do
            {
                try
                {
                    show.DisplayRoll(game.Dices);
                    string NewReRoll = show.ReturnDicePicks();
                    int DiceChoice = int.Parse(NewReRoll);

                    if (DiceChoice == 7)
                    {
                        player = GameChoices(PlayerList, player);
                    }

                    if (!game.LockDiceToss)
                    {
                        switch (DiceChoice)
                        {

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
                                game.RerolltwoTimes();
                                show.DisplayRoll(game.Dices);
                                show.DisplayReroll(game);
                                break;
                        }
                    }
                }
                catch
                {
                    show.CatchNullArgument();
                }
            }
                while (true);
        }

        public Player GameChoices(List<Player> PlayerList,Player player)
        {
            
            do
            {
                //show.DisplayScore(DAL.getMemberList());
                show.DisplayScore(player);
                ListOfPlayers = DAL.getMemberList();
                show.CompactList(ListOfPlayers);
                show.SectionPick();
                ViewStatus.Options input = show.GetOptions();
                inMenu = true;
                if (input == ViewStatus.Options.UpperSection)
                { 
                    UpperSection();
                    player = game.NextPlayer(PlayerList, player);
                    inMenu = false;
                    break;
                }
                else if (input == ViewStatus.Options.LowerSection)
                {
                    LowerSection();
                    player = game.NextPlayer(PlayerList, player);
                    inMenu = false;
                    break;
                  
                }
               
            }
            while (inMenu);
            return player;
        }
        public void UpperSection()
        {
            do
            {
               
                try
                {
                    string choices = show.GetInput();
                    int PlayerValue;
                    int RuleChoice = int.Parse(choices);


                    switch (RuleChoice)
                    {

                        
                        case 1:
                                                                      // solution alternative 1
                            PlayerValue = 1;
                            score = game.getscore(PlayerValue, player);
                            InUpper = false;

                            break;
                        case 2:
                            PlayerValue = 2;

                            score = game.getscore(PlayerValue, player);
                            InUpper = false;

                            break;

                        case 3:
                            PlayerValue = 3;
                            score = game.getscore(PlayerValue,player);
                            InUpper = false;
                            break;

                        case 4:
                            PlayerValue = 4;
                            score = game.getscore(PlayerValue, player);
                            InUpper = false;
                            break;

                        case 5:
                            PlayerValue = 5;
                            score = game.getscore(PlayerValue, player);
                            InUpper = false;
                            break;
                        case 6:
                            PlayerValue = 6;
                            score = game.getscore(PlayerValue, player);
                            InUpper = false;
                            break;
                        
                    }
                }
                catch
                {
                    show.CatchNullArgument();
                }
                show.showResult(score,player);
            }
           
            while (InUpper);
            }                                                                          // GEt input from view, then send it to model class player to inform the change in result, then return to view to read it out
        
        public void LowerSection()                                                                   // solution alternative 2
        {
            do
            {
                string lowerchoices = show.GetInput();
                int LowerChoice = int.Parse(lowerchoices);

                switch (LowerChoice)
                {
                    case 0:
                        return;
                    case 1:

                        score = game.GetThreeOfAKind(player);
                        inLower = false;                                 // to save and to send it to view 
                        break;

                    case 2:
                        score = game.GetFourOfAKind(player);
                        inLower = false;
                        break;

                    case 3:
                        score = game.GetFullHouse(player);
                        inLower = false;
                        break;

                    case 4:
                        score = game.GetSmallStraight(player);
                        inLower = false;


                        break;
                    case 5:
                        score = game.GetLargeStraight(player);
                        inLower = false;
                        break;

                    case 6:
                        score = game.Getchance(player);
                        inLower = false;
                        break;

                    case 7:
                        score = game.GetYatzee(player);
                        inLower = false;
                        break;

                    default:
                        return;
                }
                show.showResult(score,player);
            }
            while (true);
        }
     
    }
}

