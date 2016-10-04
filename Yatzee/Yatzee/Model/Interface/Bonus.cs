using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model.Interface
{
    class Bonus : IGameRules
    {

        int BonusSum;
        int TotalScore;
        int BonusPoint;

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

        public int DiceScore(List<int> ListOfDice, int PlayerSelectValues)
        {
            if (BonusSum > 75)
            {
                BonusPoint = 50;
                TotalScore += BonusPoint;
            }
            return BonusPoint;
        }


    }
}
