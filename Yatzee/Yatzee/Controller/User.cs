using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.Model;
using Yatzee.View;

namespace Yatzee.Controller
{
    class MenuController
    {
        ViewStatus show;
        Player player;
        List<Player> PlayerList = new List<Player>();
        Dice roll;
        IReadOnlyCollection<Player> ListOfPlayers;
        
        public MenuController()
        {
            roll = new Dice();
            show = new ViewStatus();
           // PlayerList.Add(player = new Player("Human"));
        }

        public void Register()
        {
            GameController InGameController = new GameController(ListOfPlayers, PlayerList, player, show);
            do
            {
                try
                {
                    
                    show.DisplayRegistration();
                    string Registration = show.GetInput();
                    int RegisterAlt = int.Parse(Registration);
                   
                    
                    switch (RegisterAlt)
                    {
                        case 0:
                            break;
                        case 1:
                          PlayerList.Add(player = new Player(show.ReturnInfo()));
                            break;
                        case 2:

                            break;
                        case 3:
                            RemovePlayer();
                            break;
                        case 4:
                            show.CompactList(DAL.getMemberList());
                            break;
                        case 5:
                            DAL.SaveToFile();
                            break;

                        case 6:
                            PlayerList = DAL.Initialize();
                            break;

                        case 7:
                            try
                            {
                                if (!PlayerList.Contains(player))
                                {
                                    throw new ArgumentException();
                                }
                                else
                                {
                                    
                                    InGameController.PerFormFirstRoll();
                                }
                            }
                            catch(ArgumentException e)
                            {
                                throw new ArgumentException("There is no Player available", e);
                            }
                            break;
                    }
                }
                catch(ArgumentException e)
                {
                  
                    show.CatchArgument(e);
                    
                }
            }
            while (show.returnInput());
        }

        public void RemovePlayer()
        {
            try
            {
                ListOfPlayers = DAL.getMemberList();
                show.CompactList(ListOfPlayers);
                int choice = int.Parse(show.GetInput());
                if (choice == 0)
                {
                    return;
                }
                choice--;
                player = ListOfPlayers.ElementAt(choice);
                DAL.removeMember(choice);
            }
            catch
            {
                show.Catch();
            }
        }
    }
}
