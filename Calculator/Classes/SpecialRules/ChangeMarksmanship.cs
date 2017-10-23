using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    class ChangeMarksmanship : ChangeStrength
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
                return "Represents an effect which temporarily affects a character's Marksmanship.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Affected characters make a Might test. If they fail, their Marksmanship is reduced or increased by C, to a maximum of 10 and a minimum of 2.  The effects of this rules cannot"+
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
                return "Change Marksmanship";
            }
        }

        public override string SyntaxSample
        {
            get
            {
                return "+/- C Marksmanship D";
            }
        }

        public override string SyntaxActual
        {
            get
            {
                if (variables["C"].Value < 0) return variables["C"].Value + " Marksmanship " + variables["D"].Value;
                return "+" + variables["C"].Value + " Marksmanship " + variables["D"].Value;
            }
        }

        public override string listIncompatibleRules()
        {
            throw new NotImplementedException();
        }
    }
}
