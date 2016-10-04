using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model.Interface
{
    class GetRule
    {
        internal Chance Chance
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal FullHouse FullHouse
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal Bonus Bonus
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal AddupDice AddupDice
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

   

        internal FourOfaKind FourOfaKind
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal LargeStraight LargeStraight
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal SmallStraight SmallStraight
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal MaxyYatzee MaxyYatzee
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal ThreeOfaKind ThreeOfaKind
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        internal Yatzee Yatzee
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public IGameRules getYatzee()
        {
            return new Yatzee();
        }
        public IGameRules GetMaxyYatzee()
        {
            return new MaxyYatzee();
        }
        public IGameRules getFullHouse()
        {
            return new FullHouse();
        }
        public IGameRules getFourOfaKind()
        {
            return new FourOfaKind();
        }
        public IGameRules getThreeOfaKind()
        {
            return new ThreeOfaKind();
        }

        public IGameRules getAddupDice()
        {
            return new AddupDice();
        }
        public IGameRules getLargeStraight()
        {
            return new LargeStraight();
        }
        public IGameRules getSmallStraight()
        {
            return new SmallStraight();
        }
        public IGameRules getBonus()
        {
            return new Bonus();
        }
        public IGameRules getChance()
        {
            return new Chance();
        }
    

    }

        
    }

