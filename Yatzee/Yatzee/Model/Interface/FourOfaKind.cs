using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model.Interface
{
    class FourOfaKind : IGameRules
    {
        int Sum;
        int Totalscore
        bool m_FourOfAKind;

        public int DiceScore(List<int> Dice, int PlayerSelectValues)
        {
            Sum = 0;
            m_FourOfAKind = false;

            for (int i = 1; i <= 6; i++)
            {
                int Count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (Dice[j] == i)
                    {
                        Count++;

                    }
                    if (Count > 3)
                    {
                        m_FourOfAKind = true;
                    }
                }
            }
            if (m_FourOfAKind)
            {
                for (int k = 0; k < 5; k++)
                {
                    Sum += Dice[k];
                }

            }
            Totalscore += Sum;
            return Sum;
        }

        public int TotalScore()
        {
            return 0;
        }
    }
}
