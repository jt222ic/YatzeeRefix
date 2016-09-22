using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model.Interface
{
    class AddupDice : IGameRules
    {

        int playerValue;
        int Sum;
        int TotalScore;
        int BonusSum;

        public int DiceScore(List<int> ListOfDice, int PlayerSelectValue)
        {
            playerValue = PlayerSelectValue;
            Sum = 0;
            
            for (int i = 0; i < ListOfDice.Count; i++)
            {
                if (ListOfDice[i] == playerValue)
                {
                    Sum += playerValue;
                    TotalScore += playerValue;
                    BonusSum += playerValue;
                }
            }
            return Sum;
        }

  
    }
}
