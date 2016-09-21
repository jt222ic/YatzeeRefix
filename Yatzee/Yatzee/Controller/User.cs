using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.Model;
using Yatzee.View;

namespace Yatzee.View
{
    class User
    {
        ViewStatus show;
        Player player;
        List<Player> PlayerList = new List<Player>();
        Dice roll;
   
        List<int> ListaAvRoll;
        IReadOnlyCollection<Player> ListOfPlayers;
        private const char PLAY_KEY = 'p';
        
       
        int choice;

        public enum Options
        {
            Play
        }
        public  Options GetOptions()
        {
            switch (System.Console.In.Read())
            {
                case PLAY_KEY:
                    return Options.Play;
            }
            return Options.Play;

        }
        public User()
        {
            roll = new Dice();
            show = new ViewStatus();
            
            PlayerList.Add(player = new Player("Human", ListaAvRoll));
        }
       
        public void Register()
        {

            do
            {
                try
                {
                    show.Register();
                    string Registration = show.GetInput();
                    int RegisterAlt = int.Parse(Registration);

                    switch (RegisterAlt)
                    {
                        case 0:
                            break;
                        case 1:
                            PlayerList.Add(player = new Player(show.ReturnInfo(), ListaAvRoll));
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
                    }
                }
                catch
                {
                    show.Catch();
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
                choice = int.Parse(show.GetInput());
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
        public void ChangePlayer()
        {
            ListOfPlayers = DAL.getMemberList();
            show.CompactList(ListOfPlayers);
            choice = int.Parse(show.GetInput());
            if (choice == 0)
            {
                return;
            }
            choice--;
            player = PlayerList.ElementAt(choice);
        }
   
         
    }
}
