using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    class ChangeSpeed : AbstractClasses.SpecialRule
    {
        public override int CalculationOrder
        {
            get
            {
                return 0;
            }
        }

        public override string Description
        {
            get
            {
                return "Represents an effect which temporarily affects a character's Speed.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Affected characters make a Might test. If they fail, their Speed is reduced or increased by C, to a maximum of 10 and a minimum of 2.  The effects of this rules cannot"+
                    " stack for the same stat, but they can counteract one another, and they can combine or offset other effects like Fear and Stun.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string Name
        {
            get
            {
                return "Change Speed";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "This effect lasts D rounds.";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "+/- C Speed D";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                if (variables["C"].Value < 0) return variables["C"].Value + " Speed " + variables["D"].Value;
                return "+" + variables["C"].Value + " Speed " + variables["D"].Value;
            }
        }

        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            return 25 * Math.Abs(variables["C"].Value) * variables["D"].Value;
        }

        public override string listIncompatibleRules()
        {
            throw new NotImplementedException();
        }
    }
}
