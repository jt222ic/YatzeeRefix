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

        internal IGameRules IGameRules
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal IGameRules IGameRules1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int DiceScore(List<int> ListOfDice, int PlayerSelectValues)
        {
            Sum = 0;
            Sum += ListOfDice.Sum();
            return Sum;
        }

     
    }
}
