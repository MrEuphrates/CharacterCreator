using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class GreaterNoDodge : NoDodge
    {
        #region Properties
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
                return "Represents an effect with characteristics making evasion impossible. Examples: seeker weapons too accurate to evade; explosions which cause damage through "+
                    "spheric pressure waves.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Abilities with this special rule cannot be dodged, not even by a target with Greater Dodge.  If the target does not deflect, the ability will hit them.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                var rules = base.IncompatibleRules;
                rules.Add(new NoDodge());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Greater No Dodge";
            }
        }
        

        public override string SyntaxSample
        {
            get
            {
                return "Greater NDo";
            }
        }
        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal energyModifier)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return energyModifier * 4;
        }
        public override string howIsEnergyCostCalculated()
        {
            return "4 energy modifiers";
        }
        #endregion
    }
}
