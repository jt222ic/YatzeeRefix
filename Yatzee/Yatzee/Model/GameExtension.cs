using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yatzee.Model.Interface;

namespace Yatzee.Model
{
    public abstract class GameExtension
    {
        GetRule Rules = new GetRule();

        internal GetRule GetRule
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal GetRule GetRule1
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public int SubmitScore(List<int> ListofDice, int PlayerSelectValue)
        {
            return Rules.getAddupDice().DiceScore(ListofDice, PlayerSelectValue);
        }
        public int SubmitThreeOfAKind(List<int> ListofDice, int PlayerSelectValue)
        {
            return Rules.getThreeOfaKind().DiceScore(ListofDice, 0);
        }
        public int SubmitFourOfaKind(List<int> ListofDice, int PlayerSelectValue)
        {
            return Rules.getFourOfaKind().DiceScore(ListofDice, 0);
        }
        public int SubmitFullHouse(List<int> ListofDice, int PlayerSelectValue)
        {
            return Rules.getFullHouse().DiceScore(ListofDice, 0);
        }
        public int SubmitSmallStraight(List<int> ListofDice, int PlayerSelectValue)
        {
            return Rules.getSmallStraight().DiceScore(ListofDice, 0);
        }
        public int SubmitLargeStraight(List<int> ListofDice, int PlayerSelectValue)
        {
            return Rules.getLargeStraight().DiceScore(ListofDice, 0);
        }
        public int SubmitChance(List<int> ListofDice, int PlayerSelectValue)
        {
            return Rules.getChance().DiceScore(ListofDice, 0);
        }
        public int SubmitYatzee(List<int> ListofDice, int PlayerSelectValue)
        {
            return Rules.getYatzee().DiceScore(ListofDice, 0);
        }

        //  public int SubmitMaxyYatzee(List<int>ListofDice, int PlayerSelectValue)    include this if you want maxyYatzy
        // {
        //     return Rules.GetMaxyYatzee().DiceScore(ListofDice, 0);
        // }

    }
}
