using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class GreaterIndirect : Indirect
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
                return "Represents an effect which doesn't require a clear line of sight to its target in order to affect it, even targets which would normally be unreachable. "+
                    "Examples: mortar weapons lob their shots over intervening " +
                    "terrain; seeker weapons capable of navigating obstacles.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Abilities with Greater Indirect do not need line of site to target or affect a character.  Unlike Indirect, this ability may be used on targets that are unreachable, "+
                    "such as one in a closed space, not simply targets which are out of line of sight.  This still does not enable the ability to target characters which are out of range or " +
                    "invisible.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                var rules = base.IncompatibleRules;
                rules.Add(new Indirect());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Greater Indirect";
            }
        }

        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal energyModifier)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return energyModifier * 2;
        }
        public override string howIsEnergyCostCalculated()
        {
            return "2 energy modifiers";
        }
        #endregion
    }
}
