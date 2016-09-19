using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model.Interface
{
    class FullHouse : IGameRules
    {
        int Sum;
        int TotalScore;

        public int DiceScore(List<int> ListOfDice, int PlayerSelectValues)
        {
            Sum = 0;
            int[] ArrayHouse = new int[5];

            for (int i = 0; i < ListOfDice.Count; i++)
            {
                ArrayHouse[0] = ListOfDice[0];
                ArrayHouse[1] = ListOfDice[1];
                ArrayHouse[2] = ListOfDice[2];
                ArrayHouse[3] = ListOfDice[3];
                ArrayHouse[4] = ListOfDice[4];
            }
            Array.Sort(ArrayHouse);
            if ((((ArrayHouse[0] == ArrayHouse[1]) && (ArrayHouse[1] == ArrayHouse[2])) &&
                 (ArrayHouse[3] == ArrayHouse[4]) &&
                 (ArrayHouse[2] != ArrayHouse[3])) ||
                ((ArrayHouse[0] == ArrayHouse[1]) &&
                 ((ArrayHouse[2] == ArrayHouse[3]) && (ArrayHouse[3] == ArrayHouse[4])) &&
                 (ArrayHouse[1] != ArrayHouse[2])))
            {
                Sum = 25;
                TotalScore += 25;

            }

            return Sum;
        }
    }
}
