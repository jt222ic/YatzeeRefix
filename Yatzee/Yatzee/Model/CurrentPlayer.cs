using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model
{
    class CurrentPlayer
    {

        Player currentplayer;

        public Player getcurrentPlayer(List<Player> playerList)
        {
            foreach (Player player in playerList)
            {
                currentplayer = player;
            }
            return currentplayer;
        }
    }
}
