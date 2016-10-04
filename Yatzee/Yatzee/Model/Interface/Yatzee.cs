using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model.Interface
{
    class Yatzee : IGameRules
    {

        int Sum;
        bool m_Yatzee;

 

        public int DiceScore(List<int> ListOfDice, int PlayerSelectValues)
        {
            Sum = 0;
            m_Yatzee = false;

            for (int i = 1; i <= 6; i++)
            {
                int Count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (ListOfDice[j] == i)
                    {
                        Count++;
                    }
                    if (Count > 4)
                    {

                        m_Yatzee = true;
                    }
                }
            }
            if (m_Yatzee)
            {
                Sum = 50;
            }
            return Sum;
        }

        public int TotalScore()
        {
            return 0;
        }
    }
}
