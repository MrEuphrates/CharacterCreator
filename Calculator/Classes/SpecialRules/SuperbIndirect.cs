using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;

namespace CharacterCreator.Classes.SpecialRules
{
    public class SuperbIndirect : GreaterIndirect
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
                return "Represents an effect which doesn't require a clear line of sight to its target in order to affect it, even targets which would normally be unreachable or invisible.";
            }
        }

        public override string Effects
        {
            get
            {
                return "Abilities with Superb Indirect do not need line of site to target or affect a character.  Unlike Indirect, this ability may be used on targets that are unreachable, " +
                    "such as one in a closed space, not simply targets which are out of line of sight.  Unlike Greater Indirect, this ability can also target characters which are invisible." +
                    "  When targeting an invisible target, the target must have been visible during the current or previous round.  This ability cannot attack targets which are out of range, " +
                    " so if the target is invisible, this ability must first be invoked before determining if the target is in range.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                List<SpecialRule> rules = base.IncompatibleRules;
                rules.Add(new GreaterIndirect());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Superb Indirect";
            }
        }

        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return baseDamage * 1.0m;
        }
        #endregion
    }
}
