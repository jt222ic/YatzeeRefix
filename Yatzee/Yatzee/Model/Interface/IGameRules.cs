using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model.Interface
{
    interface IGameRules
    {
        

          int DiceScore(List<int> ListOfDice, int PlayerSelectValues);
          

    }
}
