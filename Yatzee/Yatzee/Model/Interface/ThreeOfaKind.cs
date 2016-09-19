using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model.Interface
{
    class ThreeOfaKind : IGameRules
    {
        int Sum;
        bool m_ThreeOfAKind;

        public int DiceScore(List<int> Dice, int PlayerSelectValues)
        {
            Sum = 0;
            m_ThreeOfAKind = false;

            for (int i = 1; i <= 6; i++)
            {
                int Count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (Dice[j] == i)
                    {
                        Count++;
                    }
                    if (Count > 2)
                    {
                        m_ThreeOfAKind = true;
                    }
                }
            }
            if (m_ThreeOfAKind)
            {
                for (int k = 0; k < 5; k++)
                {
                    Sum += Dice[k];
                }

            }
            return Sum;
        }
    }
}
