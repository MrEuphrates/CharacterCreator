using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CharacterCreator.AbstractClasses;
using CharacterCreator.Classes.SpecialRuleVariables;

namespace CharacterCreator.Classes.SpecialRules
{
    public class GreaterAcid : Acid
    {
        #region Properties

        public override string Description
        {
            get
            {
                return "Represents a particularly persistent physically material harm, usually but not exclusively caused by a chemical reaction. Examples: Acid or Fire.  Greater "+
                    "Acid is more difficult to remove than ordinary Acid.";
            }
        }

        public override List<SpecialRule> IncompatibleRules
        {
            get
            {
                //Greater versions are incompatible with their ordinary ones.
                var rules = base.IncompatibleRules;
                rules.Add(new Acid());
                return rules;
            }
        }

        public override string Name
        {
            get
            {
                return "Greater Acid";
            }
        }

        public override string NegationAndDuration
        {
            get
            {
                return "A character may sacrifice 4 Time to negate one instance of this effect; otherwise, this effect persists until it is negated. "+
                    "Note that ordinary Acid costs 3 Time to negate one stack.  "+
                    "Instances of this effect still stack.";
            }
        }

        #endregion

        #region Methods
        public override decimal calculateEnergyCost(decimal baseDamage)
        {
            //Note: in classic terminology, 1 Energy Modifier is represented as 0.2m here, so 2 modifiers would be 0.4m, etc.
            return variables["M"].Value * 5;
        }
        
        #endregion
    }
}
