using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model.Interface
{
    class LargeStraight : IGameRules
    {

        int Sum;

    

        //int TotalScore;

        public int DiceScore(List<int> ListOfDice, int PlayerSelectValues)
        {
            Sum = 0;
            int[] ArrayLarge = new int[5];

            for (int i = 0; i < ListOfDice.Count; i++)
            {
                ArrayLarge[0] = ListOfDice[0];
                ArrayLarge[1] = ListOfDice[1];
                ArrayLarge[2] = ListOfDice[2];
                ArrayLarge[3] = ListOfDice[3];
                ArrayLarge[4] = ListOfDice[4];
            }
            Array.Sort(ArrayLarge);

            if (((ArrayLarge[0] == 1) &&
                 (ArrayLarge[1] == 2) &&
                 (ArrayLarge[2] == 3) &&
                 (ArrayLarge[3] == 4) &&
                 (ArrayLarge[4] == 5)) ||
                 ((ArrayLarge[0] == 2) &&
                 (ArrayLarge[1] == 3) &&
                 (ArrayLarge[2] == 4) &&
                 (ArrayLarge[3] == 5) &&
                 (ArrayLarge[4] == 6)))
            {
                Sum = 40;
                //TotalScore += 40;

            }

            return Sum;
        }


    }
}
