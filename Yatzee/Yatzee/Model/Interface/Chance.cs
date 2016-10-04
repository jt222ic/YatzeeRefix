using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model.Interface
{
    class Chance : IGameRules
    {

        int Sum;

        public int DiceScore(List<int> ListOfDice, int PlayerSelectValues)
        {
            Sum = 0;
            Sum += ListOfDice.Sum();
            return Sum;
        }

     
    }
}
