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
        DiceRule Rules;
        List<int> ListaAvRoll;
        IReadOnlyCollection<Player> ListOfPlayers;
        private const char PLAY_KEY = 'p';

        bool perforReRoll = false;
        bool RerollView = false;
        int Tossthree = 0;
        int dicenumber;
        int choice;


        public User()
        {
            roll = new Dice();
            show = new ViewStatus();
            Rules = new DiceRule(show);
            PlayerList.Add(player = new Player("Human", ListaAvRoll));    
        }
        public void MainMenu()
        {
           
            do
            {
                try
                {
                    show.DisplayFirstPage();
                    string choices = System.Console.ReadLine();
                    int Choice = int.Parse(choices);

                    switch (Choice)
                    {

                        case 0:
                            return;

                        case 1:
                            ListaAvRoll = roll.Roll();
                            perforReRoll = true;
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
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
            
        }
        public void Register()
        {

            do
            {
                show.Register();
                string Registration = System.Console.ReadLine();
                

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
                    case 7:
                         this.MainMenu();
                        break;
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
           
        }

        public void RemovePlayer()
        {
            try
            {
                ListOfPlayers = DAL.getMemberList();
                show.CompactList(ListOfPlayers);
                choice = int.Parse(Console.ReadLine());
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
            choice = int.Parse(Console.ReadLine());
            if (choice == 0)
            {
                return;
            }
            choice--;
            
            player = PlayerList.ElementAt(choice);
        }

        public void ChoiceOfReRoll()
        {
            Tossthree = 0;
            bool RerollView = true;
            show.DisplayRoll(ListaAvRoll, RerollView);
            do
            {
                try
                {
                    ViewYatzee YatzeeList = new ViewYatzee(Rules, player, show, ListaAvRoll);
                    show.showDiceAlternative(player, YatzeeList);
                    string NewReRoll = System.Console.ReadLine();
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

                            YatzeeList.YatzeeScoreSheet();
                            break;
                    }
                }
                catch
                {
                    show.Catch();
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}
