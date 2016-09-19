using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model.Interface
{
    class MaxyYatzee : IGameRules
    {

        int Sum;

        public int DiceScore(List<int> ListOfDice, int PlayerSelectValues)
        {
            var allAreSame = ListOfDice.All(x => x == ListOfDice.First());
            Sum = 100;
            return Sum;
    }

    }
}
