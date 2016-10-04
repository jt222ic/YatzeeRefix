using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzee.Model.Interface
{
    class GetRule
    {
       

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

