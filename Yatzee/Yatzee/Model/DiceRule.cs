using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.View;

namespace Yatzee.Model
{
    class DiceRule
    {
        public List<int> DiceList;
        public int Sum = 0;
        public int TotalScore = 0;
        public int BonusSum;
        public int playerValue;
        public int BonusPoint;
        
        public bool m_Yatzee = false;
        public bool m_FourOfAKind = false;
        public bool m_ThreeOfAKind = false;
        public DiceRule()
        {
            
            
        }
        public int AddUpDice(List<int> ListOfDice, int PlayerSelectValues)
        {

            playerValue = PlayerSelectValues;
            Sum = 0;
            DiceList = ListOfDice;
            for (int i = 0; i < DiceList.Count; i++)
            {
                if (DiceList[i] == playerValue)
                {
                    Sum += playerValue;
                    TotalScore += playerValue;
                    BonusSum += playerValue;
                }
            }
            return Sum;
        }
        public int ThreeOfAKind(List<int> Dice)
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

        public int FourOfAKind(List<int> Dice)
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
            return Sum;
        }
        public int Yatzee(List<int> Dice)
        {
            Sum = 0;
            m_Yatzee = false;

            for (int i = 1; i <= 6; i++)
            {
                int Count = 0;
                for (int j = 0; j < 5; j++)
                {
                    if (Dice[j] == i)
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

        public int SmallStraight(List<int> ListOfDice)
        {
            Sum = 0;
            int[] ArrayLarge = new int[5];

            for (int i = 0; i < ListOfDice.Count; i++)    // looping to sort out the array
            {
                ArrayLarge[0] = ListOfDice[0];
                ArrayLarge[1] = ListOfDice[1];
                ArrayLarge[2] = ListOfDice[2];
                ArrayLarge[3] = ListOfDice[3];
                ArrayLarge[4] = ListOfDice[4];
            }
            Array.Sort(ArrayLarge);

            if ((ArrayLarge[0] == 1) &&
                 (ArrayLarge[1] == 2) &&
                 (ArrayLarge[2] == 3) &&
                 (ArrayLarge[3] == 4) ||
                 ((ArrayLarge[0] == 2) &&
                 (ArrayLarge[1] == 3) &&
                 (ArrayLarge[2] == 4) &&
                 (ArrayLarge[3] == 5) ||
                 (ArrayLarge[0] == 3) &&
                 (ArrayLarge[1] == 4) &&
                 (ArrayLarge[2] == 5) &&
                 (ArrayLarge[3] == 6))
                 )
            {
                Sum = 30;

                TotalScore += 30;
                
            }

            return Sum;
        }

        public int LargeStraight(List<int> ListOfDice)
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
                TotalScore += 40;
              
            }

            return Sum;
        }

        public int FullHouse(List<int> ListOfDice)
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
        public int Bonus()
        {
            if (BonusSum > 75)
            {
                BonusPoint = 50;
                TotalScore += BonusPoint;
            }
            return BonusPoint;
        }
        public int Chance(List<int> ListOfDice)
        {
            Sum = 0;
            Sum += ListOfDice.Sum();
            return Sum;
        }
        public int MaxyYatzy(List<int> ListOfDice)
        {
            var allAreSame = ListOfDice.All(x=> x == ListOfDice.First());
            Sum = 100;
            return Sum;
        }
    }
}
