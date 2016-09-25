using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model
{
    [Serializable]
    public class Player  
    {
        public int TOTALSCORE;
        private int BonusScore;
        private string Name;
        private bool m_bHoldState = false;
        private int Addup;
        private int ThreeOfAKind;
        private int FourOfAKind;
        private int Yatzee;
        private int SmallStraight;
        private int LargeStraight;
        private int FullHouse;
        private int chance;
        DateTime Datum;
       
        private int NumberOne;
        private int NumberTwo;
        private int NumberThree;
        private int NumberFour;
        private int NumberFive;
        private int NumberSix;
        private int Sum;

        public int GetSum
        {
            get
            {
                return Sum;
            }
            set
            {
                Sum = value;
            }
        }
        public int GetChance
        {
            get
            {

                return chance;
            }
            set
            {
                chance = value;
            }
        }
        public int GetTotalScore
        {
            get
            {
                return TOTALSCORE;
            }
            set
            {
                TOTALSCORE = value;
            }
        }
        public int GetAddup
        {
            get
            {
                return Addup;
            }
            set
            {
                Addup = value;
            }
        }
        public int GetBonus
        {
            get
            { return BonusScore; }
            set
            {
                BonusScore = value;
            }
        }
        public int GetThreeOfAKind
        {
            get
            {
                return ThreeOfAKind;
            }
            set
            {
                ThreeOfAKind = value;
            }
        }
        public int GetFourOfAKind
        {
            get
            {
                return FourOfAKind;
            }
            set
            {
                FourOfAKind = value;
            }
        }
        public int GetYatzee
        {
            get
            {
                return Yatzee;
            }
            set
            {
                Yatzee = value;
            }
        }
        public int GetSmallStraight
        {
            get
            {
                return SmallStraight;
            }
            set
            {
                SmallStraight = value;
            }
        }
        public int GetLargeStraight
        {
            get
            {
                return LargeStraight;
            }
            set
            {
                LargeStraight = value;
            }
        }
        public int GetFullHouse
        {
            get
            {
                return FullHouse;
            }
            set
            {
                FullHouse = value;
            }
        }
        public int GetOne
        {
            get
            {
                return NumberOne;
            }
            set
            {
                NumberOne = value;
            }
        }
        public int GetTwo
        {
            get
            {
                return NumberTwo;
            }
            set
            {
                NumberTwo = value;
            }
        }
        public int GetThree
        {
            get
            {
                return NumberThree;
            }
            set
            {
                NumberThree = value;
            }
        }
        public int GetFour
        {
            get
            {
                return NumberFour;
            }
            set
            {
                NumberFour = value;
            }
        }
        public int GetFive
        {
            get
            {
                return NumberFive;
            }
            set
            {
                NumberFive = value;
            }
        }
        public int GetSix
        {
            get
            {
                return NumberSix;
            }
            set
            {
                NumberSix = value;
            }
        }
        public DateTime date
        {
            get
            {
                return Datum;
            }
            set
            {
                Datum = value;
            }
        }
        public Player(string name)
        {
            
            Name = name;
            Datum = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            sendToMemberList(this);

        }
        public void sendToMemberList(Player member)
        {
            DAL.AddMemberToList(member);
        }
        public bool HoldState
        {
            get { return m_bHoldState; }
            set { m_bHoldState = value; }
        }
        public string GetName
        {
            get
            {
                return Name;
            }
            set
            {
                if (Name.Length <= 0)
                {
                    throw new ArgumentException("Character needs to be more than 1 char");
                }
                Name = value;
            }
        }
    }
}
